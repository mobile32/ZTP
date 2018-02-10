using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Blog.Extensions
{
    public static class IdentityExtensions
    {
        public static int? GetUserId(this ClaimsPrincipal principal)
        {
            string userId = principal.Claims.FirstOrDefault(x => x.Type == "UserId").Value;
            int id;
            if (int.TryParse(userId,out id))
            {
                return id;
            }
            return null;
        }
    }
}
