using FarmHouseDeliveryApp.Data;
using FarmHouseDeliveryApp.Helpers;
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
            var cartId = UserHelpers.GetKey(HttpContext, this.User);

            CartViewModel cvm = new CartViewModel();

            try
            {
                var products = _context.ShoppingCartItem.Where(x => x.CartId == cartId).ToList();

                cvm.CartId = cartId;

                foreach (var product in products)
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
            catch  
            {
                return View(cvm);
            }
           
        }
          
    }
}
