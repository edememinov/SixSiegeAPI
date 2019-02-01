using RSixSiegeHUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSixSiegeHUD.Infrastructure
{
    public class KillFactory
    {
        public async void CreateKillAsync(dynamic jsonObject, Round round, User user)
        {
            var killJson = jsonObject.GetValue("kill");
            var headshot = killJson.GetValue("headshot");


            Kill kill = new Kill()
            {
                 Headshot = headshot, RoundId = round.RoundId, UserId = user.UserId
            };

            Persistor persistor = new Persistor();
            await persistor.PersistObject(kill);
        }
    }
}
