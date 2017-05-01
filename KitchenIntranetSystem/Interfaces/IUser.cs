using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KitchenIntranetSystem.Interfaces
{
    public interface IUser
    {
        string GetFirstName(string userId);
        string GetFirstName(ClaimsPrincipal user);

        string GetLastName(string userId);
        string GetLastName(ClaimsPrincipal user);

        string GetFullName(string userId);
        string GetFullName(ClaimsPrincipal user);

        string GetId(ClaimsPrincipal user);

        List<string> GetAllUsersId { get; }

        List<string> GetAllUsersFullName { get; }
    }
}
