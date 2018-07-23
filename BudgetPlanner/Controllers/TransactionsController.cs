using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BudgetPlanner.Models;
using Microsoft.AspNet.Identity;
using BudgetPlanner.Action_Filters;

namespace BudgetPlanner.Controllers
{
    [RequireHttps]
    [CustomAuthorization]
    public class TransactionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Transactions
        public ActionResult Index()
        {
            var transactions = db.Transactions.Include(t => t.Account);
            return View(transactions.ToList());
        }

        // GET: Transactions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // GET: Transactions/Create
        public ActionResult Create()
        {
            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "Name");
            return View();
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AccountId,Amount,Memo")] Transaction transaction, int Accounts, string BudgetItems)
        {
            if (ModelState.IsValid)
            {
                transaction.Created = DateTime.Now;
                transaction.AccountId = Accounts;
                var account = db.Accounts.AsNoTracking().FirstOrDefault(i => i.Id == Accounts);
                if(BudgetItems == "")
                {
                    account.CurrentBalance = account.CurrentBalance + transaction.Amount;
                }
                if(BudgetItems != "")
                {
                    account.CurrentBalance = account.CurrentBalance - transaction.Amount;
                }

                db.Transactions.Add(transaction);
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "Name", transaction.AccountId);
            return View(transaction);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AccountId,Amount,Memo,Updated,Reconciled")] Transaction transaction, int Accounts, string BudgetItems)
        {
            if (ModelState.IsValid)
            {
                var transactions = db.Transactions.AsNoTracking().FirstOrDefault(i => i.Id == transaction.Id);
                transactions.Updated = DateTime.Now;
                transactions.AccountId = Accounts;
                var account = db.Accounts.AsNoTracking().FirstOrDefault(i => i.Id == Accounts);
                if (BudgetItems == "")
                {
                    account.CurrentBalance = account.CurrentBalance + transaction.Amount;
                }
                if (BudgetItems != "")
                {
                    account.CurrentBalance = account.CurrentBalance - transaction.Amount;
                }

                db.Entry(transactions).State = EntityState.Modified;
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountId = new SelectList(db.Accounts, "Id", "Name", transaction.AccountId);
            return View(transaction);
        }

        // GET: Transactions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transaction transaction = db.Transactions.Find(id);
            db.Transactions.Remove(transaction);
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
