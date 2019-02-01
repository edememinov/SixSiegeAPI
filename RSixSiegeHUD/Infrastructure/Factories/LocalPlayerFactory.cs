using RSixSiegeHUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSixSiegeHUD.Infrastructure
{
    public class LocalPlayerFactory
    {
        public async void CreateLocalPlayerAsync(dynamic jsonObject, Round round, User user)
        {
            var killJson = jsonObject.GetValue("player");
            var kills = killJson.GetValue("kills");
            var deaths = killJson.GetValue("deaths");
            var health = killJson.GetValue("health");
            var score = killJson.GetValue("score");



            LocalPlayer player = new LocalPlayer()
            {
                Deaths = deaths, Kills = kills, Health = health, IsLocal = true, Name = user.UserName, RoundId = round.RoundId, Score = score, UbisoftAccountToken = user.UbisoftId
            };

            Persistor persistor = new Persistor();
            await persistor.PersistObject(player);
        }
    }
}
