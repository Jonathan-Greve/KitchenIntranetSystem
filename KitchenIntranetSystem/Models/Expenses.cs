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
        public decimal FoodIncome { get; set; }
        public decimal ShoppingIncome { get; set; }
        public decimal Subscription { get; set; }
        public decimal KitchenAccountIncome { get; set; }
        public decimal StartBalance { get; set; }
        public decimal EndBalance { get; set; }
        public DateTime Date { get; set; }

        public ApplicationUser User { get; set; }
    }
}
