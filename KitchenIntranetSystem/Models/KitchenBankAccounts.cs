using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KitchenIntranetSystem.Models
{
    public class KitchenBankAccounts
    {
        public int Id { get; set; }
        public string UserId { get; set; } //Owner of the bank account.
        public string NameOfBank { get; set; } //Eg. Danske Bank, Jyske Bank...
        public bool? IsActive { get; set; } //Is the bank account still being used.

        public ApplicationUser User { get; set; }
        public ICollection<BankAccountDatas> BankAccountDatas { get; set; }
    }
}
