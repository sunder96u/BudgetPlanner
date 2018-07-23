using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BudgetPlanner.Models;

namespace BudgetPlanner.ViewModels
{
    public class AddAccountViewModel
    {
        public List<Bank> Banks { get; set; }
        public List<AccountType> Types { get; set; }
    }
}