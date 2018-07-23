using BudgetPlanner.Models;
using BudgetPlanner.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BudgetPlanner.Action_Filters;

namespace BudgetPlanner.Controllers
{
    [RequireHttps]
    [CustomAuthorization]
    public class BudgetViewModelController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        // GET: BudgetViewModel
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var user = db.Users.Find(userId);
            int? houseId = user.HouseholdId;
            var budget = db.Budgets.FirstOrDefault(i => i.HouseholdId == houseId);
            decimal budgetspending = 0;
            decimal budgetspent = 0;
            var budgetName = "";
            var budgetItems = new List<BudgetItem>();
            if (budget != null)
            {
                budgetspending = budget.SpendingTarget;
                budgetspent = budget.CurrentBalance;
                budgetName = budget.Name;
                budgetItems = new List<BudgetItem>();
                var items = db.budgetItems.Where(b => b.BudgetId == budget.Id).ToList();
                foreach (var budgets in items)
                {
                    budgetItems.Add(budgets);
                }
            }
            if (budget == null)
            {
                budgetspending = 0;
                budgetspent = 0;
                budgetName = "foo";
                budgetItems = new List<BudgetItem>();
            }

            decimal Budgetspending = budgetspending;
            decimal Budgetspent = budgetspent;
            var BudgetName = budgetName;
            var BudgetItems = budgetItems;

            var Budget = new BudgetViewModel()
            {
                HouseHoldId = houseId,
                SpendingTarget = Budgetspending,
                CurrentBalance = Budgetspent,
                BudgetItems = BudgetItems,
                Name = BudgetName
            };


            return View(Budget);
        }
    }
}