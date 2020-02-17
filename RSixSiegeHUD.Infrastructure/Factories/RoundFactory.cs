using RSixSiegeHUD.Data.Entities;

namespace RSixSiegeHUD.Infrastructure.Factories
{
    public class RoundFactory
    {
        public Round CreateRound(dynamic jsonObject, Match match)
        {
            if (jsonObject.GetValue("round") == null)
            {

                return null;
            }

            RoundProvider roundProvider = new RoundProvider();
            var round = roundProvider.GetRound(jsonObject, match);

            return round;

        }

    }
}
