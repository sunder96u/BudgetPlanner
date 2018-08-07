using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialApp.Models
{
    class AccountDetails
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Created { get; set; }
        public string CurrentBalance { get; set; }
        public string AccountTypeId { get; set; }
        public string AccountNumber { get; set; }
        public string RoutingNumber { get; set; }

        public AccountDetails()
        {
            Name = "";
            Description = "";
            Created = "";
            CurrentBalance = "";
            AccountTypeId = "";
            AccountNumber = "";
            RoutingNumber = "";
        }
    }
}
