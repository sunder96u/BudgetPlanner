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

        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Budget> Budgets { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }
        public virtual ICollection<Invitation> Invitations { get; set; }

        public Household()
        {
            Accounts = new HashSet<Account>();
            Budgets = new HashSet<Budget>();
            Users = new HashSet<ApplicationUser>();
            Invitations = new HashSet<Invitation>();

        }
    }
}