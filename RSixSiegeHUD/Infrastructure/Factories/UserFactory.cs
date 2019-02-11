using RSixSiegeHUD.Data;
using RSixSiegeHUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSixSiegeHUD.Infrastructure.Factories
{
    public class UserFactory
    {
        public User CreateUser(dynamic jsonObject)
        {
            var userUbisoft = jsonObject.GetValue("userUbisoft");

            User user = new User()
            {
                OverWolfId = jsonObject.GetValue("userId"), UbisoftId = userUbisoft, UserName = jsonObject.GetValue("username")
            };

            return user;
        }
    }
}
