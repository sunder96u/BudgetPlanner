using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BudgetPlanner.Models;

namespace BudgetPlanner.ViewModels
{
    public class BudgetViewModel
    {
        public int? HouseHoldId { get; set; }
        public string Name { get; set; }
        public decimal SpendingTarget { get; set; }
        public decimal CurrentBalance { get; set; }
        public List<BudgetItem> BudgetItems { get; set; }

    }
}