using BudgetPlanner.Models;
using BudgetPlanner.Helpers;
using BudgetPlanner.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace BudgetPlanner.Controllers
{
    
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        HouseHelper houseHelper = new HouseHelper();
        RoleHelper roleHelper = new RoleHelper();

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [RequireHttps]
        [AllowAnonymous]
        public ActionResult oops()
        {
            return View();
        }

        [RequireHttps]
        [Authorize]
        public PartialViewResult InviteModal()
        {
            var userId = User.Identity.GetUserId();
            var user = db.Users.Find(userId);
            var houseId = user.HouseholdId;
            var housename = "";
            if (user.Household == null)
            {
                housename = "NoHouse";
            }
            if (user.Household != null)
            {
                housename = user.Household.Name;
            }
            var house = housename;
            var HouseInfo = new InviteViewModel
            {
                HouseholdId = houseId,
                UserFirst = user.FirstName,
                UserLast = user.LastName,
                House = house,
                SendEmail = user.Email
            };

            return PartialView("~/Views/Shared/_InviteModal.cshtml", HouseInfo);
        }

        [RequireHttps]
        [Authorize]
        public PartialViewResult LeaveHouseModal()
        {
            var userId = User.Identity.GetUserId();
            var user = db.Users.Find(userId);
            var houseId = user.HouseholdId;
            int? HouseId = houseId;
            //var data = new LeaveHouseViewModel();

            var myHouse = houseHelper.UsersInHouse(HouseId);
            //data.LeavehouseCount = myHouse.Count();

            var housename = "";
            if (user.Household == null)
            {
                housename = "NoHouse";
            }
            if (user.Household != null)
            {
                housename = user.Household.Name;
            }
            var house = housename;
            var HouseInfo = new LeaveHouseViewModel
            {
                HouseholdId = houseId,
                Household = house,
                LeavehouseCount = myHouse.Count()             
            };

            //Use roleHelper in conjunction with a foreach loop to grab only the users that
            //occupy the role of Member
            var members = new List<ApplicationUser>();
            var occupants = db.Users.Where(u => u.HouseholdId == houseId).ToList();
            foreach(var person in occupants)
            {
                if(roleHelper.IsUserInRole(person.Id,"Member"))
                {
                    members.Add(person);
                }
            }
            ViewBag.Members = new SelectList(members, "Id", "Email");
            return PartialView("~/Views/Shared/_LeaveHouseModal.cshtml", HouseInfo);
        }

        [RequireHttps]
        [Authorize]
        public PartialViewResult HouseMembers()
        {
            var userId = User.Identity.GetUserId();
            var user = db.Users.Find(userId);
            var houseId = user.HouseholdId;
            int? HouseId = houseId;
            var data = new HouseMembersViewModel();

            var myHouse = houseHelper.UsersInHouse(HouseId);
            data.HouseMembersCount = myHouse.Count();
            var occupants = db.Users.Where(u => u.HouseholdId == houseId).ToList();
            var members = new List<ApplicationUser>();
            foreach (var person in occupants)
            {
                members.Add(person);
            }

            var housename = "";
            if (user.Household == null)
            {
                housename = "NoHouse";
            }
            if (user.Household != null)
            {
                housename = user.Household.Name;
            }
            var house = housename;
            var houseMembers = new HouseMembersViewModel
            {
                HouseholdId = houseId,
                HouseMembersCount = myHouse.Count(),
                Members = members,
                House = house
            };

            return PartialView("~/Views/Shared/_HouseMembers.cshtml", houseMembers);
        }

        [RequireHttps]
        [Authorize]
        public PartialViewResult AddAccount()
        {
            var userId = User.Identity.GetUserId();
            var user = db.Users.Find(userId);
            var HouseId = user.HouseholdId;
            var Bank = new List<Bank>();
            var Banks = db.Banks.Where(i => i.HouseholdId == HouseId).ToList();
            foreach (var bank in Banks)
            {
                Bank.Add(bank);
            }
            var Type = new List<AccountType>();
            var Types = db.AccountTypes.ToList();
            foreach (var type in Types)
            {
                Type.Add(type);
            }
            var add = new AddAccountViewModel
            {
                Banks = Bank,
                Types = Type
            };

            ViewBag.Banks = new SelectList(Bank, "Id", "Name");
            ViewBag.Type = new SelectList(Type, "Id", "Type");


            return PartialView("~/Views/Shared/_AddAccount.cshtml", add);
        }

        [RequireHttps]
        [Authorize]
        public PartialViewResult AddTransaction()
        {
            var userId = User.Identity.GetUserId();
            var user = db.Users.Find(userId);
            var bank = new List<Account>();
            var account = db.Accounts.Where(b => b.Bank.HouseholdId == user.HouseholdId).ToList();
            foreach (var Account in account)
            {
                bank.Add(Account);
            }
            var Catagory = new List<BudgetItem>();
            var Budgetitems = db.budgetItems.Where(b => b.Budget.HouseholdId == user.HouseholdId).ToList();
            foreach (var Item in Budgetitems)
            {
                Catagory.Add(Item);
            }

            var transaction = new AddTransactionViewModel
            {
                Accounts = account,
                BudgetItems = Catagory
            };
            ViewBag.Accounts = new SelectList(account, "Id", "Name");
            ViewBag.BudgetItems = new SelectList(Catagory, "Name", "Name");

            return PartialView("~/Views/Shared/_AddTransaction.cshtml", transaction);
        }

        [RequireHttps]
        [Authorize]
        public PartialViewResult ReconcileFunds()
        {
            var userId = User.Identity.GetUserId();
            var user = db.Users.Find(userId);
            var bank = new List<Account>();
            var account = db.Accounts.Where(b => b.Bank.HouseholdId == user.HouseholdId).ToList();
            foreach (var Account in account)
            {
                bank.Add(Account);
            }
            var Catagory = new List<BudgetItem>();
            var Budgetitems = db.budgetItems.Where(b => b.Budget.HouseholdId == user.HouseholdId).ToList();
            foreach (var Item in Budgetitems)
            {
                Catagory.Add(Item);
            }

            var reconcileFunds = new ReconcileFundsViewModel
            {
                Accounts = account,
                BudgetItems = Catagory
            };
            ViewBag.Accounts = new SelectList(account, "Id", "Name");
            ViewBag.BudgetItems = new SelectList(Catagory, "Name", "Name");

            return PartialView("~/Views/Shared/_Reconcile.cshtml", reconcileFunds);
        }

        [RequireHttps]
        [Authorize]
        public PartialViewResult EditAccount()
        {
            var userId = User.Identity.GetUserId();
            var user = db.Users.Find(userId);
            var banks = new List<Bank>();
            var Banks = db.Banks.Where(b => b.HouseholdId == user.HouseholdId).ToList();
            foreach (var Bank in Banks)
            {
                banks.Add(Bank);
            }
            var accountType = new List<AccountType>();
            var AccountTypes = db.AccountTypes.ToList();
            foreach (var Item in AccountTypes)
            {
                accountType.Add(Item);
            }

            var EditAccount = new AccountEditViewModel
            {
                Banks = banks,
                AccountType = accountType
            };
            ViewBag.Banks = new SelectList(banks, "Id", "Name");
            ViewBag.AccountType = new SelectList(accountType, "Id", "Type");
            

            return PartialView("~/Views/Shared/_EditAccount.cshtml", EditAccount);
        }



    }
}