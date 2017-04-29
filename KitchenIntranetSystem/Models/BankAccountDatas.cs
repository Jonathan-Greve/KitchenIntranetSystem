using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitchenIntranetSystem.Models
{
    public class BankAccountDatas
    {
        public int Id { get; set; }
        public int KitchenBankAccountId { get; set; }
        public decimal Total { get; set; }
        public decimal Debt { get; set; }

        public KitchenBankAccounts KitchenBankAccount { get; set; }
    }
}
