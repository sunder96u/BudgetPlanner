using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialApp.Models
{
    class Transactions
    {
        public string AccountName { get; set; }
        public string Amount { get; set; }
        public string Memo { get; set; }
        public string Created { get; set; }
        public string Type { get; set; }

        public Transactions()
        {
            AccountName = "";
            Amount = "";
            Memo = "";
            Created = "";
            Type = "";
        }
    }
}
