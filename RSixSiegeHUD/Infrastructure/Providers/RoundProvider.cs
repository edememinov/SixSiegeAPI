﻿using RSixSiegeHUD.Models;

namespace RSixSiegeHUD.Infrastructure
{
    public class RoundProvider
    {
        public Round GetRound(dynamic jsonObject, Match match)
        {
            var roundJson = jsonObject.GetValue("round");
            var number = roundJson.GetValue("number");

            Round round = new Round()
            {
                MatchId = match.MatchId,
                BlueTeamScore = match.ScoreBlueTeam,
                OrangeTeamScore = match.ScoreOrangeTeam,
                RoundNumber = number
            };

            return round;
        }
    }
}