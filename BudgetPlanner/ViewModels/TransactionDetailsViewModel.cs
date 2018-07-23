using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BudgetPlanner.Models;

namespace BudgetPlanner.ViewModels
{
    public class TransactionDetailsViewModel
    {
        public List<Transaction> Transactions { get; set; }
    }
}