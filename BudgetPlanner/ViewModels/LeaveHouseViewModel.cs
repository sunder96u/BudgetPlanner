using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BudgetPlanner.Models;

namespace BudgetPlanner.ViewModels
{
    public class LeaveHouseViewModel
    {
        public int Id { get; set; }
        public int? HouseholdId { get; set; }
        public string Household { get; set; }
        public int LeavehouseCount { get; set; }
       
    }
}