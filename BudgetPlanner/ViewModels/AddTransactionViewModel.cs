using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BudgetPlanner.Models;

namespace BudgetPlanner.ViewModels
{
    public class AddTransactionViewModel
    {
        public List<Account> Accounts { get; set; }
        public List<BudgetItem> BudgetItems { get; set; }
    }
}