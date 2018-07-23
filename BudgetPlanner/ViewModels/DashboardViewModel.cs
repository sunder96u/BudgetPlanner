using BudgetPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetPlanner.ViewModels
{
    public class DashboardViewModel
    {
        public List<Transaction> Transactions { get; set; }
    }
}