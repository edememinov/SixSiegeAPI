using RSixSiegeHUD.Data.Entities;

namespace RSixSiegeHUD.Infrastructure.Factories
{
    public class RoundOutcomeFactory
    {
        public RoundOutcome CreateRoundOutcome(dynamic jsonObject, Round round, User user)
        {
            var killJson = jsonObject.GetValue("events");
          

            if(killJson == null)
            {
                return null;
            }

            var outcome = killJson[0].GetValue("data");

            return new RoundOutcome()
            {
                UserId = user.UserId,
                RoundId = round.RoundId,
                Outcome = outcome
            };
             

        }
    }
}
