using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KitchenIntranetSystem.Models
{
    public class Expenses
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public decimal BeerExpense { get; set; }
        public decimal FoodExpense { get; set; }
        public decimal ShoppingExpense { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
