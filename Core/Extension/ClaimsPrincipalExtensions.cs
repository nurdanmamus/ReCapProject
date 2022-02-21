using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Extension
{
    public static class ClaimsPrincipalExtensions  
    {
        //ClaimsPrincipal jwt daki claimleri bulmaya yarayan class. bunu extend ediyoruz. 
        //direkt olarak gönderdiiğimiz tipte claim var mı?
        public static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            var result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();
            return result;
        }
        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.Claims(ClaimTypes.Role); //role claimini getir.
        }
    }
}
