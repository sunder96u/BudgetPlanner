using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BudgetPlanner.Models;
using BudgetPlanner.ViewModels;
using BudgetPlanner.Action_Filters;

namespace BudgetPlanner.Controllers
{
    [RequireHttps]
    [CustomAuthorization]
    public class AccountsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Accounts
        public ActionResult Index()
        {
            var accounts = db.Accounts.Include(a => a.Bank);
            return View(accounts.ToList());
        }

        // GET: Accounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            var transactions = new List<Transaction>();
            var trans = db.Transactions.Where(a => a.AccountId == id);
            foreach (var Trans in trans)
            {
                transactions.Add(Trans);
            }
            var myTransactions = new TransactionDetailsViewModel
            {
                Transactions = transactions
            };

            return View(myTransactions);
        }

        // GET: Accounts/Create
        public ActionResult Create()
        {
            ViewBag.BankId = new SelectList(db.Banks, "Id", "Name");
            ViewBag.HouseholdId = new SelectList(db.Households, "Id", "Name");
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Created,StartingBalance,AccountNumber,RoutingNumber")] Account account, int Banks, int Type)
        {
            if (ModelState.IsValid)
            {
                account.Created = DateTime.Now;
                account.CurrentBalance = account.StartingBalance;
                account.BankId = Banks;
                account.AccountTypeId = Type;
                db.Accounts.Add(account);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BankId = new SelectList(db.Banks, "Id", "Name", account.BankId);
            ViewBag.HouseholdId = new SelectList(db.Households, "Id", "Name");
            return View(account);
        }

        [AccountAuthorization]
        // GET: Accounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            ViewBag.BankId = new SelectList(db.Banks, "Id", "Name", account.BankId);
            ViewBag.HouseholdId = new SelectList(db.Households, "Id", "Name");
            return View(account);
        }

        [AccountAuthorization]
        // POST: Accounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TypeId,BankId,Name,Description,Created,Updated,StartingBalance,CurrentBalance")] Account account)
        {
            if (ModelState.IsValid)
            {
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BankId = new SelectList(db.Banks, "Id", "Name", account.BankId);
            ViewBag.HouseholdId = new SelectList(db.Households, "Id", "Name");
            return View(account);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete([Bind(Include = "Id")] Account account)
        {
            var Accounts = db.budgetItems.AsNoTracking().FirstOrDefault(i => i.Id == account.Id);
            Accounts.IsDeleted = true;
            db.Entry(Accounts).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
