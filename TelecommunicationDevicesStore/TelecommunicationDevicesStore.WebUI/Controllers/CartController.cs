using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelecommunicationDevicesStore.Domain.Data;
using TelecommunicationDevicesStore.WebUI.Models;

namespace TelecommunicationDevicesStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        private TelecomStoreDbContext _tsdbcontxt;
        public CartController()
        {
            _tsdbcontxt = new TelecomStoreDbContext();
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

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }
    }
}