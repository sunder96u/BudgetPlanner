using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BudgetPlanner.Models;

namespace BudgetPlanner.Helpers
{
    public class HouseHelper
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private RoleHelper rolehelper = new RoleHelper();

        public bool IsUserInHouse(string userId, int HouseholdId)
        {
            var house = db.Households.Find(HouseholdId);
            var flag = house.Users.Any(u => u.Id == userId);
            return (flag);
        }

        //public ICollection<Household> ListUserHouse(string userId)
        //{
        //    ApplicationUser user = db.Users.Find(userId);
        //    var house = user.Households.ToList();
        //    return (house);
        //}

        public void AddUserToHouse(string userId, int houseId)
        {
            if (!IsUserInHouse(userId, houseId))
            {
                Household house = db.Households.Find(houseId);
                var newUser = db.Users.Find(userId);

                house.Users.Add(newUser);
                db.SaveChanges();
            }
        }

        public void RemoveUserFromHouse(string userId, int houseId)
        {
            if (IsUserInHouse(userId, houseId))
            {
                Household house = db.Households.Find(houseId);
                var delUser = db.Users.Find(userId);

                house.Users.Remove(delUser);
                db.SaveChanges();
            }
        }

        internal IEnumerable<object> ListUserRoles(string roles)
        {
            throw new NotImplementedException();
        }

        //public ICollection<Household> households(string userId)
        //{
        //    var House = new List<Household>();
        //    var myRole = rolehelper.ListUserRoles(userId).FirstOrDefault();
        //    switch(myRole)
        //    {
        //        case ("Admin"):
        //            House.AddRange(db.Households.ToList());
        //            break;
        //        case ("Member"):
        //            foreach (var house in ListUserHouse(userId))
        //            {
        //                House.AddRange(db.Households.Where(t => t.Id == house.Id).ToList());
        //            }
        //            break;
        //    }
        //    return House;
        //}

        public ICollection<ApplicationUser> UsersInHouse(int? houseId)
        {
            int fakeId = 1;
            
            if (houseId == null)
            {
                return db.Households.Find(fakeId).Users;
            }
            else
            {
                return db.Households.Find(houseId).Users;
            }
        }

    }
}