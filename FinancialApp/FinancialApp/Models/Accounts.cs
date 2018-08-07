using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialApp.Models
{
    class Accounts
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CurrentBalance { get; set; }
        public string AccountTypeId { get; set; }
        public string AccountNumber { get; set; }
        public string RoutingNumber { get; set; }

        public Accounts()
        {
            Name = "";
            Description = "";
            CurrentBalance = "";
            AccountTypeId = "";
            AccountNumber = "";
            RoutingNumber = "";
        }
    }
}
