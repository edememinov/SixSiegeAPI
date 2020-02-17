using RSixSiegeHUD.Data.Entities;

namespace RSixSiegeHUD.Infrastructure
{
    public class RoundProvider
    {
        public Round GetRound(dynamic jsonObject, Match match)
        {
            var roundJson = jsonObject.GetValue("round");

            if(roundJson == null)
            {
                return null;
            }

            var number = roundJson.GetValue("number");


            if (number == null)
            {
                number = 0;
            }

            return new Round()
            {
                MatchId = match.MatchId,
                BlueTeamScore = match.ScoreBlueTeam,
                OrangeTeamScore = match.ScoreOrangeTeam,
                RoundNumber = number
            }; ;
        }
    }
}