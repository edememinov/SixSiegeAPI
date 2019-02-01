using RSixSiegeHUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSixSiegeHUD.Infrastructure
{
    public class MatchProvider
    {
        public object GetMatch(dynamic jsonObject)
        {
            var matchJson = jsonObject.GetValue("match");
            var score = matchJson.GetValue("score");
            Match match = new Match()
            {
                ScoreBlueTeam = score.GetValue("blue"),
                ScoreOrangeTeam = score.GetValue("orange")
            };
            return match;
        }
    }
}
