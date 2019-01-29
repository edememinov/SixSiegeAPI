using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSixSiegeHUD.Infrastructure
{
    public class GeneralObjectCreator
    {
        public void SeperateObjects(dynamic jsonObject)
        {
            var gameInfo = jsonObject.GetValue("game_info");
            var players = jsonObject.GetValue("players");
            var player = jsonObject.GetValue("player");
            var round = jsonObject.GetValue("round");
            var match = jsonObject.GetValue("match");
            var matchToken = jsonObject.GetValue("matchToken");

            MatchProvider matchProvider = new MatchProvider();
            RoundFactory roundFactory = new RoundFactory();

            var matches = matchProvider.GetMatches();
            if (matches.Count() > 0)
            {
                var currentMatch = matches.Where(x => x.MatchToken == matchToken).FirstOrDefault();

                if (currentMatch != null)
                {
                    roundFactory.CreateRound(jsonObject, currentMatch);
                }

            }
            

            

            
            


        }
    }
}
