using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetPlanner.ViewModels
{
    public class InviteViewModel
    {
        public int Id { get; set; }
        public int? HouseholdId { get; set; }
        public string Email { get; set; }
        public string House { get; set; }
        public string UserFirst { get; set; }
        public string UserLast { get; set; }
        public string SendEmail { get; set; }

    }
}