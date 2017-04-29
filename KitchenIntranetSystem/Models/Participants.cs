using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitchenIntranetSystem.Models
{
    public class Participants
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int KitchenDinnerId { get; set; }

        public ApplicationUser User { get; set; }
        public KitchenDinners KitchenDinner { get; set; }
    }
}
