using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BudgetPlanner.Extension_Methods;
using BudgetPlanner.Models;
using Microsoft.AspNet.Identity;
using BudgetPlanner.Action_Filters;

namespace BudgetPlanner.Controllers
{
    [RequireHttps]
    [CustomAuthorization]
    public class InvitationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Invitations
        public ActionResult Index()
        {
            return View(db.Invitations.ToList());
        }

        public ActionResult Join(string email, string code, int? householdId)
        {
            return View();
        }

        public ActionResult MemberJoin(string email, string code, int? householdId)
        {
            return View();
        }

        // GET: Invitations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invitation invitation = db.Invitations.Find(id);
            if (invitation == null)
            {
                return HttpNotFound();
            }
            return View(invitation);
        }

        // GET: Invitations/Create
        public ActionResult Create(int houseId)
        {
            ViewBag.HouseholdId = houseId;
            return View();
        }

        // POST: Invitations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "HouseholdId,Email,Code,LifeSpan")] Invitation invitation, string UserFirst, string UserLast, string House, string SendEmail)
        {

            var oldInvitation = db.Invitations.AsNoTracking().FirstOrDefault(i => i.Id == invitation.Id);

            if (ModelState.IsValid)
            {

                invitation.Created = DateTime.Now;
                invitation.Code = Guid.NewGuid().ToString();
                invitation.LifeSpan = 5;

                if (!db.Users.Any(u => u.Email == invitation.Email))
                {
                    var callbackUrl = Url.Action("Join", "Invitations", new { email = invitation.Email, code = invitation.Code, householdId = invitation.HouseholdId }, protocol: Request.Url.Scheme);
                    await invitation.NewInvitation(oldInvitation, callbackUrl, UserFirst, UserLast, House, SendEmail);
                }
                if (db.Users.Any(u => u.Email == invitation.Email))
                {
                    var callbackUrl = Url.Action("MemberJoin", "Invitations", new { email = invitation.Email, code = invitation.Code, householdId = invitation.HouseholdId }, protocol: Request.Url.Scheme);
                    await invitation.MemberInvitation(oldInvitation, callbackUrl, UserFirst, UserLast, House, SendEmail);
                }
                db.Invitations.Add(invitation);
                db.SaveChanges();
                return RedirectToAction("Index","Households");
            }
            else
            {
                ViewBag.HouseholdId = invitation.HouseholdId;
                var message = string.Join(" | ", ModelState.Values
                                                 .SelectMany(v => v.Errors)
                                                 .Select(e => e.ErrorMessage));

                ModelState.AddModelError("", message);
                return View(invitation);
            }

        }

        // GET: Invitations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invitation invitation = db.Invitations.Find(id);
            if (invitation == null)
            {
                return HttpNotFound();
            }
            return View(invitation);
        }

        // POST: Invitations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,HouseholdId,Created,Email,Code,LifeSpan,Accepted")] Invitation invitation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invitation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(invitation);
        }

        // GET: Invitations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invitation invitation = db.Invitations.Find(id);
            if (invitation == null)
            {
                return HttpNotFound();
            }
            return View(invitation);
        }

        // POST: Invitations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Invitation invitation = db.Invitations.Find(id);
            db.Invitations.Remove(invitation);
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
