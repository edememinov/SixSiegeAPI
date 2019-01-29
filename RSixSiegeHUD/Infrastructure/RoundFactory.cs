using RSixSiegeHUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSixSiegeHUD.Infrastructure
{
    public class RoundFactory
    {
        public void CreateRound(dynamic jsonObject, Match match)
        {
            var roundJson = jsonObject.GetValue("round");
            var number = roundJson.GetValue("number");

            Round round = new Round()
            {
                MatchId = match.MatchId, BlueTeamScore = match.ScoreBlueTeam, OrangeTeamScore = match.ScoreOrangeTeam, RoundNumber = number
            };


        }
    }
}
