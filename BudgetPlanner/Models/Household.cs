using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetPlanner.Models
{
    public class Household
    {
        public int Id { get; set; }
        public string Name { get; set; }
         public string Description { get; set; }

        public virtual List<Account> Accounts { get; set; }
        public virtual List<Budget> Budgets { get; set; }
        public virtual List<ApplicationUser> Users { get; set; }
        public virtual List<Invitation> Invitations { get; set; }

        public Household()
        {
            Accounts = new List<Account>();
            Budgets = new List<Budget>();
            Users = new List<ApplicationUser>();
            Invitations = new List<Invitation>();

        }
    }
}