using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitchenIntranetSystem.Models
{
    public class Beers
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int BeerCategoriesId { get; set; }
        public int AmountDrunk { get; set; }
        public DateTime Date { get; set; }

        public ApplicationUser User { get; set; }
        public BeerCategories BeerCategories { get; set; }
    }
}
