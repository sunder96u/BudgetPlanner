using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BudgetPlanner.Action_Filters;
using BudgetPlanner.Models;
using BudgetPlanner.ViewModels;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;

namespace BudgetPlanner.Controllers
{
    [RequireHttps]
    [CustomAuthorization]
    public class DashboardController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();

        // GET: Dashboard
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var user = db.Users.FirstOrDefault(i => i.Id == userId);
            var transactions = new List<Transaction>();
            var transaction = db.Transactions.ToList();
            foreach (var item in transaction.Where(i => i.Account.Bank.HouseholdId == user.HouseholdId))
            {
                transactions.Add(item);
            }

            var dashboard = new DashboardViewModel()
            {
                Transactions = transactions
            };
            

            return View(dashboard);
        }

        public ActionResult BudgetData()
        {
            var userId = User.Identity.GetUserId();
            var user = db.Users.FirstOrDefault(i => i.Id == userId);
            var chartVm = new FusionChartDataViewModel();
            var Budget = new List<BudgetItem>();
            var Catagory = db.budgetItems.Where(i => i.Budget.HouseholdId == user.HouseholdId);
            foreach (var item in Catagory)
            {
                Budget.Add(item);
            }

            foreach (var entry in Budget)
            {
                chartVm.Data.Add(new FusionChartData
                {
                    Label = entry.Name,
                    Value = db.budgetItems.Count().ToString()
                });
            }
            return Content(JsonConvert.SerializeObject(chartVm), "application/json");

        }
    }
}