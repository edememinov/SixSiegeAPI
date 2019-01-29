using RSixSiegeHUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSixSiegeHUD.Infrastructure
{
    public class MatchFactory
    {
        public void CreateMatch(dynamic jsonObject)
        {
            var matchJson = jsonObject.GetValue("match");
            var score = matchJson.GetValue("score");
            Match match = new Match()
            {
                ScoreBlueTeam = score.GetValue("blue"), ScoreOrangeTeam = score.GetValue("orange")
            };

            RoundFactory roundFactory = new RoundFactory();
            roundFactory.CreateRound(jsonObject, match.ScoreBlueTeam, match.ScoreOrangeTeam, match.MatchId);
        }
    }
}
