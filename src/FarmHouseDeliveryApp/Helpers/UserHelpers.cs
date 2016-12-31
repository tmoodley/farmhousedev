using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace FarmHouseDeliveryApp.Helpers
{
    public static class UserHelpers
    {
        public static string GetUserId(this IPrincipal principal)
        {
            try
            {
                var claimsIdentity = (ClaimsIdentity)principal.Identity;
                var claim = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
                return claim.Value;
            }
            catch
            {
                return null;
            }
        
        }

        public static Guid GetKey(HttpContext httpContext, IPrincipal principal)
        {
            //check if User is signed in             
            var userId = GetUserId(principal);
            if (string.IsNullOrEmpty(userId))
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
            else
            {
                var _guid = new Guid(userId);
                return _guid;
            }
        }
    }
}
