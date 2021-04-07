using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TelecommunicationDevicesStore.Domain.Data;
using TelecommunicationDevicesStore.WebUI.Models;
using TelecommunicationDevicesStore.WebUI.Infrastructure;
using TelecommunicationDevicesStore.Domain.Filters;

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
        public ViewResult Index(Cart cart, string returnUrl) => View(new CartIndexModel { Cart = cart, ReturnUrl = returnUrl });
        [ActionName("AddToCart")]
        public async Task<RedirectToRouteResult> AddToCartAsync(Cart cart, int productId, string returnUrl)
        {
            Product product = await _tsdbcontxt.GetProductAsync(productId);

            if (product != null)
                    cart.AddItem(product, 1);

            return RedirectToAction("Index", new { returnUrl });
        }

        [ActionName("RemoveFromCart")]
        public async Task<RedirectToRouteResult> RemoveFromCartAsync(Cart cart, int productId, string returnUrl)
        {
            Product product = await _tsdbcontxt.GetProductAsync(productId);

            if (product != null)
                    cart.RemoveLine(product);

            return RedirectToAction("Index", new { returnUrl });
        }

        [HttpGet]
        public ViewResult Checkout() => View(new ShippingDetails());

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Checkout")]
        [UserAuthorizationFilter()]
        public async Task<ViewResult> CheckoutAsync(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
                    ModelState.AddModelError("cart", "Sorry, your cart is empty!");

            shippingDetails.UserId = Convert.ToInt32(Session["customer"]);
            if (ModelState.IsValid)
            {
                Order order = new Order
                {// constructor add
                    City = shippingDetails.City,
                    Country = shippingDetails.Country,
                    Line1 = shippingDetails.Line1,
                    Line2 = shippingDetails.Line2,
                    Line3 = shippingDetails.Line3,
                    UserId =  shippingDetails.UserId,
                    GiftWrap = shippingDetails.GiftWrap,
                    TotalPrice = cart.ComputeTotalValue()
                }; // constructor
                foreach (var line in cart.Lines)
                {
                    var product = await _tsdbcontxt.Products.FindAsync(line.ProductId);
                    product.StockCount -= line.Quantity;
                    _tsdbcontxt.CartLines.Add(new CartLine
                    { // constructor add
                        OrderId = order.Id,
                        ProductId = product.Id,
                        Product = product,
                        Quantity = line.Quantity
                    });
                }
                order.User = await _tsdbcontxt.Customers.GetUserAsync(order.UserId);
				_tsdbcontxt.Orders.Add(order);
                cart.Clear();
                await _tsdbcontxt.SaveChangesAsync();
                return View(nameof(Completed));
            }
            else
            {
                return View(shippingDetails);
            }
        }

        public ViewResult Completed() => View();

        public PartialViewResult Summary(Cart cart) => PartialView(cart);
    }
}