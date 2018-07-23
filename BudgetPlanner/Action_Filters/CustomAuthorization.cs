using BudgetPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace BudgetPlanner.Action_Filters
{
    public class CustomAuthorization : ActionFilterAttribute
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var userId = HttpContext.Current.User.Identity.GetUserId();
            var user = db.Users.FirstOrDefault(i => i.Id == userId);

            if (userId == null || user.HouseholdId == null)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary { { "Controller", "Home" }, { "action", "oops" } });
            }
            
        }
    }

    public class AccountAuthorization : ActionFilterAttribute
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var userId = HttpContext.Current.User.Identity.GetUserId();
            var user = db.Users.FirstOrDefault(i => i.Id == userId);
            var accountId = Convert.ToInt32(filterContext.ActionParameters.SingleOrDefault(p => p.Key == "Id").Value);
            var account = db.Accounts.Find(accountId);

            if (account.Bank.HouseholdId != user.HouseholdId)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary { { "Controller", "Home" }, { "action", "oops" } });
            }
        }
    }
}