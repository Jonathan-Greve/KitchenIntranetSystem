using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitchenIntranetSystem.Models
{
    public class KitchenDinners
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Menu { get; set; }
        public decimal Price { get; set; }
        public DateTime SignUpCloseDate { get; set; }
        public DateTime Date { get; set; }

        public ApplicationUser User { get; set; }
        public ICollection<Participants> Participants { get; set; }
    }
}
