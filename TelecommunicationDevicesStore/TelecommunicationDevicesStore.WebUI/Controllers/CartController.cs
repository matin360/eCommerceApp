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
        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }
        public RedirectToRouteResult AddToCart(int productId, string returnUrl)
        {
            Product product = _tsdbcontxt.Products
                .FirstOrDefault(p => p.Id == productId);

            if (product != null)
            {
                GetCart().AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(int productId, string returnUrl)
        {
            Product product = _tsdbcontxt.Products
                 .FirstOrDefault(p => p.Id == productId);

            if (product != null)
            {
                GetCart().RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}