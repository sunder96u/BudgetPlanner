using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BudgetPlanner.Helpers;
using BudgetPlanner.Models;
using Microsoft.AspNet.Identity;
using BudgetPlanner.Action_Filters;

namespace BudgetPlanner.Controllers
{
    [RequireHttps]
    [CustomAuthorization]
    public class HouseholdsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private RoleHelper roleHelper = new RoleHelper();
        private HouseHelper houseHelper = new HouseHelper();

        // GET: Households
        public ActionResult Index()
        {
            return View(db.Households.ToList());
        }

        // GET: Households/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Household household = db.Households.Find(id);
            if (household == null)
            {
                return HttpNotFound();
            }
            return View(household);
        }

        // GET: Households/Create
        public ActionResult Create()
        {
            var userId = User.Identity.GetUserId();
            var Member = db.Users.Find(userId).HouseholdId != null;
            if (Member)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // POST: Households/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description")] Household household)
        {
            if (ModelState.IsValid)
            {
                db.Households.Add(household);
                var userId = User.Identity.GetUserId();
                foreach (var role in roleHelper.ListUserRoles(userId))
                {
                    roleHelper.RemoveUserFromRole(userId, role);
                }
                roleHelper.AddUserToRole(userId, "HeadofHousehold");

                var user = db.Users.Find(userId);
                user.HouseholdId = household.Id;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(household);
        }

        //Post: LeaveHousehold
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LeaveHouse([Bind(Include = "Id,Name,HouseholdId")] Household household, int MemberCount)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                var user = db.Users.Find(userId);

                foreach (var role in roleHelper.ListUserRoles(userId))
                {
                        roleHelper.RemoveUserFromRole(userId, role);
                }
                roleHelper.AddUserToRole(userId, "Guest");
                user.HouseholdId = null;
                
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(household);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LeavehouseandDelete([Bind(Include = "Id,Name,HouseholdId")] Household household, int MemberCount)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                var user = db.Users.Find(userId);

                foreach (var role in roleHelper.ListUserRoles(userId))
                {
                    roleHelper.RemoveUserFromRole(userId, role);
                }
                roleHelper.AddUserToRole(userId, "Guest");
                user.HouseholdId = null;
                household.IsDeleted = true;

                db.Households.Attach(household);
                db.Entry(household).Property(p => p.IsDeleted).IsModified = true;

                //The field is not actually changing.. Will need to change before the save changes
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View(household);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LeaveHouseHeadofHousehold([Bind(Include ="Id,Name,HouseholdId")] Household household, int MemberCount, string Members)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                var user = db.Users.Find(userId);
                var UsersinHouse = houseHelper.UsersInHouse(household.Id).ToList();

                roleHelper.RemoveUserFromRole(userId, "HeadofHousehold");
                roleHelper.RemoveUserFromRole(Members, "Member");
                roleHelper.AddUserToRole(Members, "HeadofHousehold");
                roleHelper.AddUserToRole(userId, "Guest");

                user.HouseholdId = null;

                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(household);
        }

        // GET: Households/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Household household = db.Households.Find(id);
            if (household == null)
            {
                return HttpNotFound();
            }
            return View(household);
        }

        // POST: Households/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] Household household)
        {
            if (ModelState.IsValid)
            {
                db.Entry(household).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(household);
        }

        // GET: Households/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Household household = db.Households.Find(id);
            if (household == null)
            {
                return HttpNotFound();
            }
            return View(household);
        }

        // POST: Households/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Household household = db.Households.Find(id);
            db.Households.Remove(household);
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
