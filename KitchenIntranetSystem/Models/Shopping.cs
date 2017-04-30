using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace KitchenIntranetSystem.Models
{
    public class Shopping
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [DisplayName("Item(s) Bought")]
        public string ItemBought { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }

        public ApplicationUser User { get; set; }
    }
}
