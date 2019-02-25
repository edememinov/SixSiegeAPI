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
            var killJson = jsonObject.GetValue("events");
            

            if(killJson == null)
            {
                return null;
            }

            var name = killJson[0].GetValue("name");
            var headshot = false;

            if (name.ToString().Equals("kill"))
            {
                headshot = false;
            }
            else
            {
                headshot = true;
            }

            return new Kill()
            {
                Headshot = headshot,
                RoundId = round.RoundId,
                UserId = user.UserId
            };

        }
    }
}
