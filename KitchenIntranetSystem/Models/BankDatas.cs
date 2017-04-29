using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitchenIntranetSystem.Models
{
    public class BankDatas
    {
        public int Id { get; set; }
        public int KitchenAccountId { get; set; }
        public decimal Total { get; set; }
        public decimal Debt { get; set; }

        public KitchenAccounts KitchenAccount { get; set; }
    }
}
