using RSixSiegeHUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSixSiegeHUD.Infrastructure
{
    public class RoundOutcomeFactory
    {
        public async void CreateRoundOutcomeAsync(dynamic jsonObject, Round round, User user)
        {
            var killJson = jsonObject.GetValue("roundOutcome");
            var outcome = killJson.GetValue("data");


            RoundOutcome roundOutcome = new RoundOutcome()
            {
                UserId = user.UserId,
                RoundId = round.RoundId,
                Outcome = outcome
            };

            Persistor persistor = new Persistor();
            await persistor.PersistObject(roundOutcome);
        }
    }
}
