using RSixSiegeHUD.Data;
using RSixSiegeHUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSixSiegeHUD.Infrastructure
{
    public class KillFactory
    {
        public Kill CreateKill(dynamic jsonObject, Round round, User user)
        {
            var killJson = jsonObject.GetValue("kill");
            var headshot = killJson.GetValue("headshot");


            Kill kill = new Kill()
            {
                 Headshot = headshot, RoundId = round.RoundId, UserId = user.UserId
            };

            return kill;
        }
    }
}
