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
        
        public string GetFirstName(string userId)
        {
            return _context.Users.Where(u => u.Id == userId).FirstOrDefault().FirstName;
        }

        public string GetFirstName(ClaimsPrincipal user)
        {
            return _context.Users.Where(u => u.Id == (user.FindFirstValue(ClaimTypes.NameIdentifier))).FirstOrDefault().FirstName;
        }

        public string GetLastName(string userId)
        {
            return _context.Users.Where(u => u.Id == userId).FirstOrDefault().LastName;
        }

        public string GetLastName(ClaimsPrincipal user)
        {
            return _context.Users.Where(u => u.Id == (user.FindFirstValue(ClaimTypes.NameIdentifier))).FirstOrDefault().LastName;
        }

        public string GetFullName(string userId)
        {
            return GetFirstName(userId) + " " + GetLastName(userId);
        }

        public string GetFullName(ClaimsPrincipal user)
        {
            return GetFirstName(user) + " " + GetLastName(user);
        }

        public string GetId(ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public List<string> GetAllUsersId
        {
            get { return _context.Users.Select(u => u.Id).ToList(); }
        }

        public List<string> GetAllUsersFullName
        {
            get {
                var fullNameList = new List<string>();
                foreach (var userId in GetAllUsersId)
                {
                    fullNameList.Add(GetFullName(userId));
                }
                return fullNameList;
                }
        }

        // Constructor
        private readonly ApplicationDbContext _context;
        public User(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
