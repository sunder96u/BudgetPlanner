using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BudgetPlanner.Models;

namespace BudgetPlanner.ViewModels
{
    public class AccountEditViewModel
    {
        public List<Bank> Banks { get; set; }
        public List<AccountType> AccountType { get; set; }
    }
}