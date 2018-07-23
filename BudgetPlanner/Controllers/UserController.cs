using BudgetPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BudgetPlanner.Action_Filters;

namespace BudgetPlanner.Controllers
{
    [Authorize]
    [RequireHttps]
    [CustomAuthorization]
    public class UserController : Controller
    {
        private ApplicationDbContext Db = new ApplicationDbContext();

        // GET: User
        public ActionResult Index()
        {
            return View(Db.Users.ToList());
        }

        //Post: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email,PhoneNumber,DisplayName")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                applicationUser.UserName = applicationUser.Email;

                Db.Users.Attach(applicationUser);
                Db.Entry(applicationUser).Property(p => p.FirstName).IsModified = true;
                Db.Entry(applicationUser).Property(p => p.LastName).IsModified = true;
                //Db.Entry(applicationUser).Property(p => p.Email).IsModified = true;
                //Db.Entry(applicationUser).Property(p => p.UserName).IsModified = true;
                Db.Entry(applicationUser).Property(p => p.DisplayName).IsModified = true;
                Db.Entry(applicationUser).Property(p => p.PhoneNumber).IsModified = true;
                Db.SaveChanges();

                return RedirectToAction("MyProfile", "Account", new { Id = applicationUser.Id });
            }
            return View(applicationUser);
        }
    }
}