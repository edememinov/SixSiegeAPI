using RSixSiegeHUD.Models;
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
            //set all the json objects from Overwolf API into objects
            var gameInfo = jsonObject.GetValue("game_info");
            var players = jsonObject.GetValue("players");
            var player = jsonObject.GetValue("player");
            var round = jsonObject.GetValue("round");
            var match = jsonObject.GetValue("match");
            var matchToken = jsonObject.GetValue("matchToken");
            // Define all providers
            MatchRepositoryProvider matchRepositoryProvider = new MatchRepositoryProvider();
            MatchProvider matchProvider = new MatchProvider();
            RoundProvider roundProvider = new RoundProvider();


            //Define all factories
            RoundFactory roundFactory = new RoundFactory();
            MatchFactory matchFactory = new MatchFactory();
            DeathFactory deathFactory = new DeathFactory();
            KillFactory killFactory = new KillFactory();
            LocalPlayerFactory localPlayerFactory = new LocalPlayerFactory();
            MatchOutcomeFactory matchOutcomeFactory = new MatchOutcomeFactory();
            PlayerFactory playerFactory = new PlayerFactory();
            RoundOutcomeFactory roundOutcomeFactory = new RoundOutcomeFactory();

            User user = new User();

            //get match
            var newMatch = matchProvider.GetMatch(jsonObject, user);

            //get round
            var newRound = roundProvider.GetRound(jsonObject, newMatch);


            var matches = matchRepositoryProvider.GetMatches();
            if (matches.Count() > 0)
            {
                var currentMatch = matches.Where(x => x.MatchToken == matchToken).FirstOrDefault();

                if (currentMatch != null)
                {
                    roundFactory.CreateRoundAsync(jsonObject, currentMatch);
                }
                else
                {
                    
                    matchFactory.CreateMatchAsync(jsonObject, user);
                    roundFactory.CreateRoundAsync(jsonObject, newMatch);
                }
            }

        }
    }
}
