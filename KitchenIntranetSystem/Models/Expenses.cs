using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitchenIntranetSystem.Models
{
    public class Expenses
    {
        public int ID { get; set; }
        public ApplicationUser ApplicationUserID { get; set; }
        public decimal BeerExpense { get; set; }
        public decimal FoodExpense { get; set; }
        public decimal ShoppingExpense { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
