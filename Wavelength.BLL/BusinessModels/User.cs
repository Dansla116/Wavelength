using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wavelength.DAL.DomainModels;

namespace Wavelength.BLL.BusinessModels {
    public class User : Base {
        public string Name { get; set; }
        public Role Role { get; set; }
    }

    public static partial class Translations {
        public static User ToLogic(this UserData Data) {
            User Logic = new User();

            Logic.Name = Data.Name;
            Logic.Role = (Role)Data.Role;

            Logic.id = Data.id;
            Logic.DateAdded = Data.DateAdded;
            Logic.DateUpdated = Data.DateUpdated;
            Logic.UserAdded = Data.UserAdded;
            Logic.UserUpdated = Data.UserUpdated;

            return Logic;
        }

        public static List<User> ToLogicList(this IQueryable<UserData> DataList) {
            List<User> LogicList = new List<User>();
            foreach (UserData Data in DataList) {
                User Logic = new User();

                Logic.Name = Data.Name;
                Logic.Role = (Role)Data.Role;

                Logic.id = Data.id;
                Logic.DateAdded = Data.DateAdded;
                Logic.DateUpdated = Data.DateUpdated;
                Logic.UserAdded = Data.UserAdded;
                Logic.UserUpdated = Data.UserUpdated;

                LogicList.Add(Logic);
            }
            return LogicList;
        }
    }
}