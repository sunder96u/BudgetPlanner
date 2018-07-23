using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BudgetPlanner.Models;

namespace BudgetPlanner.ViewModels
{
    public class AccountsViewModel
    {
        public int Type { get; set; }
        public List<Bank> Banks { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AccountNumber { get; set; }
        public string RoutingNumber { get; set; }
        public decimal StartingBalance { get; set; }
        public decimal CurrentBalance { get; set; }
    }
}