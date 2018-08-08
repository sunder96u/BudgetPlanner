using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialApp.Models
{
    class Accounts
    {
        public string BankId { get; set; }
        public string Name { get; set; }
        public string BankName { get; set; }
        public string Description { get; set; }
        public string CurrentBalance { get; set; }
        public string AccountTypeId { get; set; }
        public string AccountNumber { get; set; }
        public string RoutingNumber { get; set; }

        public Accounts()
        {
            Name = "";
            BankName = "";
            Description = "";
            CurrentBalance = "";
            AccountTypeId = "";
            AccountNumber = "";
            RoutingNumber = "";
        }
    }
}
