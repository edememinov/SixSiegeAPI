using RSixSiegeHUD.Data;
using RSixSiegeHUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSixSiegeHUD.Infrastructure
{
    public class DeathFactory
    {
        public Death CreateDeath(dynamic jsonObject, Round round, User user)
        {
            var deathJson = jsonObject.GetValue("death");
            var killer = deathJson.GetValue("killer");
            var name = killer.GetValue("data");

            Death death = new Death()
            {
               KilledBy = name, RoundId = round.RoundId, UserId = user.UbisoftId
            };

            return death;
            
        }
    }
}
