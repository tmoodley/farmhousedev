using FarmHouseDeliveryApp.Data;
using FarmHouseDeliveryApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FarmHouseDeliveryApp.Helpers
{ 
        public class CartAccessor : IDisposable
        {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;
        private UserManager<ApplicationUser> _userManager;
        private ApplicationDbContext _db;
        public CartAccessor(IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _db = db;
        }

        public string ShoppingCartId { get; set; }

        public const string CartSessionKey = "CartId";

        public void AddToCart(Guid guid, int id, int qty)
        {
            var cartItem = _db.ShoppingCartItem.SingleOrDefault(
                    c => c.CartId == guid
                    && c.ProductId == id);
            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists.                 
                cartItem = new ShoppingCartItem
                {
                    Id = Guid.NewGuid(),
                    ProductId = id,
                    CartId = guid,
                    Quantity = qty,
                    DateCreated = DateTime.Now
                };

                _db.ShoppingCartItem.Add(cartItem);
            }
            else
            {
                // If the item does exist in the cart,                  
                // then add one to the quantity.                 
                cartItem.Quantity = qty;
            }
            _db.SaveChanges();
        }

        public void Dispose()
            {
                if (_db != null)
                {
                    _db.Dispose();
                    _db = null;
                }
            }

        public List<ShoppingCartItem> GetCartItems(Guid guid)
        {
            return _db.ShoppingCartItem.Where(
                c => c.CartId == guid).ToList();
        }
    }
  
}
