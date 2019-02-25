using RSixSiegeHUD.Data;
using RSixSiegeHUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSixSiegeHUD.Infrastructure
{
    public class RoundOutcomeFactory
    {
        public RoundOutcome CreateRoundOutcome(dynamic jsonObject, Round round, User user)
        {
            var killJson = jsonObject.GetValue("events");
          

            if(killJson == null)
            {
                return null;
            }

            var outcome = killJson[0].GetValue("data");

            return new RoundOutcome()
            {
                UserId = user.UserId,
                RoundId = round.RoundId,
                Outcome = outcome
            };
             

        }
    }
}
