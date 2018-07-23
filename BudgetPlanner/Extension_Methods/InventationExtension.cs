using BudgetPlanner.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BudgetPlanner.Extension_Methods
{
    public static class InventationExtension
    {
        private static ApplicationDbContext db = new ApplicationDbContext();

        public static async Task NewInvitation(this Invitation invintation, Invitation oldInvitation, string callBackUrl, string UserFirst, string UserLast, string House, string SendEmail)
        {
            var newInvintation = (invintation.Email == invintation.Email);

            var Body = new StringBuilder();
            Body.AppendLine("<br/><p><u><b>Message:</b></u></p>");
            Body.AppendFormat("<p>{0} {1} has invited you to join the Awesomeness</p>", UserFirst, UserLast);
            Body.AppendFormat("<p></p>");
            Body.AppendFormat("<p>Will you join {0} {1}'s Household {2}</p>", UserFirst, UserLast, House);
            Body.AppendFormat("<p>To join please click this link <b><u>{0}</u></b></p>", "<a href=\""+callBackUrl+"\">here</a>");
            Body.AppendFormat("You will have 5 days to reply to this email before the code will no longer work");

            //The email
            IdentityMessage email = null;
            if (newInvintation)
            {
                email = new IdentityMessage()
                {
                    Subject = "You have been invited to join a Household",
                    Body = Body.ToString(),
                    Destination = invintation.Email
                };

                var svc = new EmailService();
                await svc.SendAsync(email);
            }
        }

        public static async Task MemberInvitation(this Invitation invintation, Invitation oldInvitation, string callBackUrl, string UserFirst, string UserLast, string House, string SendEmail)
        {
            var newInvintation = (invintation.Email == invintation.Email);

            var Body = new StringBuilder();
            Body.AppendLine("<br/><p><u><b>Message:</b></u></p>");
            Body.AppendFormat("<p>{0} {1} has invited you to join the Awesomeness</p>", UserFirst, UserLast);
            Body.AppendFormat("<p></p>");
            Body.AppendFormat("<p>Will you join {0} {1}'s Household {2}</p>", UserFirst, UserLast, House);
            Body.AppendFormat("<p>To join please click this link <b><u>{0}</u></b></p>", "<a href=\"" + callBackUrl + "\">here</a>");
            Body.AppendFormat("You will have 5 days to reply to this email before the code will no longer work");

            //The email
            IdentityMessage email = null;
            if (newInvintation)
            {
                email = new IdentityMessage()
                {
                    Subject = "You have been invited to join a Household",
                    Body = Body.ToString(),
                    Destination = invintation.Email
                };

                var svc = new EmailService();
                await svc.SendAsync(email);
            }
        }

    }
}