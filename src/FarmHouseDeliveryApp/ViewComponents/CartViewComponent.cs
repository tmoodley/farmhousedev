using FarmHouseDeliveryApp.Data;
using FarmHouseDeliveryApp.Models;
using FarmHouseDeliveryApp.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmHouseDeliveryApp.ViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
 

        public CartViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var cartId = SaveKey(HttpContext);
            var products = _context.ShoppingCartItem.Where(x => x.CartId == cartId).ToList();

            CartViewModel cvm = new CartViewModel();
            cvm.CartId = cartId;
             
            foreach(var product in products)
            {
                Product prod = _context.Product.Where(x => x.Id == product.ProductId).FirstOrDefault();
                cvm.Total += prod.Price;
                CartItemViewModel civm = new CartItemViewModel();
                civm.Product = prod;
                civm.Quantity = product.Quantity;
                civm.SubTotal = product.Quantity * prod.Price;
                cvm.CartItems = new List<CartItemViewModel>();
                cvm.CartItems.Add(civm); 
            }
             
            return View(cvm);
        }
         
        public Guid SaveKey(HttpContext httpContext)
        {
            const string sessionKey = "cart_id";
            const string dateSeenKey = "dateSeen";
            DateTime dateFirstSeen;
            var value = httpContext.Session.GetString(sessionKey);
            if (string.IsNullOrEmpty(value))
            {
                dateFirstSeen = DateTime.Now;
                var serialisedDate = JsonConvert.SerializeObject(dateFirstSeen);
                httpContext.Session.SetString(dateSeenKey, serialisedDate);
                var cart_id = Guid.NewGuid().ToString();
                httpContext.Session.SetString(sessionKey, cart_id);
                return new Guid(cart_id);
            }
            else
            {
                var _guid = new Guid(value);
                return _guid;
            }
        }
    }
}
