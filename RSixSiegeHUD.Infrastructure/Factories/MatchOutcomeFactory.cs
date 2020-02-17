using RSixSiegeHUD.Data.Entities;

namespace RSixSiegeHUD.Infrastructure.Factories
{
    public class MatchOutcomeFactory
    {
        public MatchOutcome CreateMatchOutcome(dynamic jsonObject, Round round, User user)
        {
            var matchOutcome = jsonObject.GetValue("events");
            

            if(matchOutcome == null)
            {
                return null;  
            }
            var outcome = matchOutcome[0].GetValue("data");

            return new MatchOutcome()
            {
                MatchId = round.MatchId,
                Outcome = outcome,
                UserId = user.UserId
            };

        }
    }
}
