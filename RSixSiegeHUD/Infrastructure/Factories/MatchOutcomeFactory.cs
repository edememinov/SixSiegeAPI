using RSixSiegeHUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSixSiegeHUD.Infrastructure
{
    public class MatchOutcomeFactory
    {
        public async void CreateKillAsync(dynamic jsonObject, Round round, User user)
        {
            var killJson = jsonObject.GetValue("matchOutcome");
            var outcome = killJson.GetValue("data");


            MatchOutcome matchOutcome = new MatchOutcome()
            {
                MatchId = round.MatchId, Outcome = outcome, UserId = user.UserId
            };

            Persistor persistor = new Persistor();
            await persistor.PersistObject(matchOutcome);
        }
    }
}
