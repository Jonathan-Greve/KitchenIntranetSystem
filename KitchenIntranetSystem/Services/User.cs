using KitchenIntranetSystem.Data;
using KitchenIntranetSystem.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KitchenIntranetSystem.Services
{
    public class User : Controller, IUser
    {
        
        public string GetFirstName(ClaimsPrincipal user)
        {
            return _context.Users.Where(u => u.Id == (user.FindFirstValue(ClaimTypes.NameIdentifier))).FirstOrDefault().FirstName;
        }
        public string GetLastName(ClaimsPrincipal user)
        {
            return _context.Users.Where(u => u.Id == (user.FindFirstValue(ClaimTypes.NameIdentifier))).FirstOrDefault().LastName;
        }

        public string GetFullName(ClaimsPrincipal user)
        {
            return GetFirstName(user) + " " + GetLastName(user);
        }

        public string GetId(ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        // Constructor
        private readonly ApplicationDbContext _context;
        public User(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
