using RSixSiegeHUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSixSiegeHUD.Infrastructure
{
    public class RoundFactory
    {
        public async void CreateRoundAsync(dynamic jsonObject, Match match)
        {
            RoundProvider roundProvider = new RoundProvider();
            var round = roundProvider.GetRound(jsonObject, match);
            Persistor persistor = new Persistor();
            await persistor.PersistObject(round);
        }

    }
}
