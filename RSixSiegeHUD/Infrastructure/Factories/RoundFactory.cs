using RSixSiegeHUD.Data;
using RSixSiegeHUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSixSiegeHUD.Infrastructure
{
    public class RoundFactory
    {
        public Round CreateRound(dynamic jsonObject, Match match)
        {
            RoundProvider roundProvider = new RoundProvider();
            var round = roundProvider.GetRound(jsonObject, match);

            return round;
        }

    }
}
