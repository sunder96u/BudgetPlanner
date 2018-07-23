using BudgetPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetPlanner.ViewModels
{
    public class HouseMembersViewModel
    {
        public int Id { get; set; }
        public int? HouseholdId { get; set; }
        public string House { get; set; }
        public int HouseMembersCount { get; set; }
        public List<ApplicationUser> Members { get; set; }

    }
}