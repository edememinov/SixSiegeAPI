using RSixSiegeHUD.Data;
using RSixSiegeHUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSixSiegeHUD.Infrastructure
{
    public class MatchFactory
    {
        public Match CreateMatch(dynamic jsonObject, User user)
        {
            MatchProvider matchProvider = new MatchProvider();
            var match = matchProvider.GetMatch(jsonObject, user);

            return match;

        }

    }
}
