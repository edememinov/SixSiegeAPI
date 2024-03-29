﻿using RSixSiegeHUD.Data.Entities;

namespace RSixSiegeHUD.Infrastructure.Factories
{
    public class LocalPlayerFactory
    {
        public LocalPlayer CreateLocalPlayer(dynamic jsonObject, Round round, User user)
        {
            var killJson = jsonObject.GetValue("player");
            if (killJson == null)
            {
                return null;
            }

            var kills = killJson.GetValue("kills");
            var deaths = killJson.GetValue("deaths");
            var health = killJson.GetValue("health");
            var score = killJson.GetValue("score");

            if(kills == null)
            {
                kills = 0;
            }
            if(deaths == null)
            {
                deaths = 0;
            }
            if(score == null)
            {
                score = 0;
            }
            if(health == null)
            {
                health = 0;
            }


            return new LocalPlayer()
            {
                Deaths = deaths,
                    Kills = kills,
                    Health = health,
                    IsLocal = true,
                    Name = user.UserName,
                    RoundId = round.RoundId,
                    Score = score,
                    UbisoftAccountToken = user.UbisoftId
                };

        }
    }
}
