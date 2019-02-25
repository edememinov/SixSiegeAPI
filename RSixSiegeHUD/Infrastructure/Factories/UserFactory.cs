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
            if (jsonObject == null)
            {
                return null;
            }
            var userUbisoft = jsonObject.GetValue("userUbisoft");
            if (userUbisoft == null)
            {
                return null;
            }

            return new User()
            {
                OverWolfId = jsonObject.GetValue("userId"),
                UbisoftId = userUbisoft,
                UserName = jsonObject.GetValue("username")
            };

        }
    }
}
