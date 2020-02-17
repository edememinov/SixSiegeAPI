using RSixSiegeHUD.Data.Entities;

namespace RSixSiegeHUD.Infrastructure.Factories
{
    public class DeathFactory
    {
        public Death CreateDeath(dynamic jsonObject, Round round, User user)
        {
            if (jsonObject == null)
            {
                return null;
            }

            var deathJson = jsonObject.GetValue("events");

            if (deathJson == null)
            {
                return null;
            }
            var killer = deathJson[0].GetValue("name");
            var name = deathJson[0].GetValue("data");

            return new Death()
            {
                KilledBy = name,
                RoundId = round.RoundId,
                UserId = user.UserId
            };
            
        }
    }
}
