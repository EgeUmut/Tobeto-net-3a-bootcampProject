using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions;

public static class ClaimPrincipleExtension
{
    public static List<string> Claims(this ClaimsPrincipal principal, string claimType)
    {
        var result = principal.FindAll(claimType)?.Select(p => p.Value).ToList();
        return result;
    }

    public static List<string> ClaimRoles(this ClaimsPrincipal principal)
    {
        return principal?.Claims(ClaimTypes.Role);
    }

    public static Guid GetUserId(this ClaimsPrincipal principal)
    {
        //var userId = principal?.Claims(ClaimTypes.NameIdentifier)?.FirstOrDefault();
        //if (userId != null) {
        //    if (typeof(T) == typeof(Guid)) {
        //        return (T)(object)Guid.Parse(userId); 
        //    } 
        //    if (typeof(T) == typeof(int)) {
        //        return (T)(object)int.Parse(userId); 
        //    } 
        //}
        //return default;

        return Guid.Parse(principal?.Claims(ClaimTypes.NameIdentifier)?.FirstOrDefault());
    }
}
