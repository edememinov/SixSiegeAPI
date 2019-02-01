using RSixSiegeHUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSixSiegeHUD.Infrastructure
{
    public class DeathFactory
    {
        public async void CreateDeathAsync(dynamic jsonObject, Round round, User user)
        {
            var deathJson = jsonObject.GetValue("death");
            var killer = deathJson.GetValue("killer");
            var name = killer.GetValue("data");

            Death death = new Death()
            {
               KilledBy = name, RoundId = round.RoundId, UserId = user.UbisoftId
            };

            Persistor persistor = new Persistor();
            await persistor.PersistObject(death);
        }
    }
}
