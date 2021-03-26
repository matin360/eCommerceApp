using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelecommunicationDevicesStore.Domain.Concrete;
using TelecommunicationDevicesStore.Domain.Data;
using TelecommunicationDevicesStore.WebUI.Models;

namespace TelecommunicationDevicesStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        private TelecomStoreDbContext _tsdbcontxt;
        private EmailOrderProcessor _emordProc;
        public CartController()
        {
            _tsdbcontxt = new TelecomStoreDbContext();
            _emordProc = new EmailOrderProcessor(new EmailSettings
            {
                WriteAsFile = bool.Parse(ConfigurationManager
                    .AppSettings["Email.WriteAsFile"] ?? "false")
            });
        }
        // GET: Cart
        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }
        public RedirectToRouteResult AddToCart(Cart cart, int productId, string returnUrl)
        {
            Product product = _tsdbcontxt.Products
                .FirstOrDefault(p => p.Id == productId);

            if (product != null)
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, string returnUrl)
        {
            Product product = _tsdbcontxt.Products
                 .FirstOrDefault(p => p.Id == productId);

            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        [HttpGet]
        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("cart", "Sorry, your cart is empty!");
            }

            if (ModelState.IsValid)
            {
                _emordProc.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View(nameof(Completed));
            }
            else
            {
                return View(shippingDetails);
            }
        }

        public ViewResult Completed()
		{
            return View();
		}

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }
    }
}