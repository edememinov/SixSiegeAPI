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
            var killJson = jsonObject.GetValue("roundOutcome");
            var outcome = killJson.GetValue("data");


            RoundOutcome roundOutcome = new RoundOutcome()
            {
                UserId = user.UserId,
                RoundId = round.RoundId,
                Outcome = outcome
            };

            return roundOutcome;
        }
    }
}
