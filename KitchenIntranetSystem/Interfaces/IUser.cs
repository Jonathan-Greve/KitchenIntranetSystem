using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KitchenIntranetSystem.Interfaces
{
    public interface IUser
    {
        string GetFirstName(ClaimsPrincipal user);
        string GetLastName(ClaimsPrincipal user);
        string GetFullName(ClaimsPrincipal user);
        string GetId(ClaimsPrincipal user);
    }
}
