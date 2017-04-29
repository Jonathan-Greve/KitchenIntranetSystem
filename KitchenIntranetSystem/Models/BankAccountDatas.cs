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
        public decimal Total { get; set; } // Amount of money in the bank account
        public decimal Debt { get; set; } // How much the bank owe the kitchens users

        public KitchenBankAccounts KitchenBankAccount { get; set; }
    }
}
