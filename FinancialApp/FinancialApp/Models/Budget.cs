using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialApp.Models
{
    class Budget
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string SpendingTarget { get; set; }
        public string CurrentBalance { get; set; }

        public Budget()
        {
            Name = "";
            Description = "";
            SpendingTarget = "";
            CurrentBalance = "";
        }
    }
}
