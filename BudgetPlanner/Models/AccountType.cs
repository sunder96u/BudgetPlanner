using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetPlanner.Models
{
    public class AccountType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Descrtiption { get; set; }

        public List<Account> Accounts { get; set; }

        public AccountType()
        {
            Accounts = new List<Account>();
        }

    }
}