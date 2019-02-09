using RSixSiegeHUD.Data;
using RSixSiegeHUD.Infrastructure.Factories;
using RSixSiegeHUD.Infrastructure.Providers;
using RSixSiegeHUD.Models;
using RSixSiegeHUD.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSixSiegeHUD.Infrastructure
{
    public class GeneralObjectCreator
    {
        public SiegeViewModel SeperateObjects(dynamic jsonObject)
        {
            //set all the json objects from Overwolf API into objects
            var gameInfo = jsonObject.GetValue("game_info");
            var players = jsonObject.GetValue("players");
            var player = jsonObject.GetValue("player");
            var round = jsonObject.GetValue("round");
            var match = jsonObject.GetValue("match");
            var matchToken = jsonObject.GetValue("matchToken");

            //Define ViewModel
            SiegeViewModel viewModel = new SiegeViewModel();


            //Define all factories
            RoundFactory roundFactory = new RoundFactory();
            MatchFactory matchFactory = new MatchFactory();
            DeathFactory deathFactory = new DeathFactory();
            KillFactory killFactory = new KillFactory();
            LocalPlayerFactory localPlayerFactory = new LocalPlayerFactory();
            MatchOutcomeFactory matchOutcomeFactory = new MatchOutcomeFactory();
            PlayerFactory playerFactory = new PlayerFactory();
            RoundOutcomeFactory roundOutcomeFactory = new RoundOutcomeFactory();
            UserFactory userFactory = new UserFactory();

            //get user
            viewModel.CurrentUser = userFactory.CreateUser(jsonObject);

            //get match
            viewModel.CurrentMatch = matchFactory.CreateMatch(jsonObject, viewModel.CurrentUser);

            //get round
            viewModel.CurrentRound = roundFactory.CreateRound(jsonObject, viewModel.CurrentMatch);

            //get match outcome
            //viewModel.CurrentMatchOutcome = matchOutcomeFactory.CreateMatchOutcome(jsonObject, viewModel.CurrentRound, viewModel.CurrentUser);

            //get local player
            viewModel.CurrentLocalPlayer = localPlayerFactory.CreateLocalPlayer(jsonObject, viewModel.CurrentRound, viewModel.CurrentUser);
            
            //get all players
            viewModel.CurrentPlayers = playerFactory.CreatePlayers(jsonObject, viewModel.CurrentRound, viewModel.CurrentUser);

            //get round outcome
            //viewModel.CurrentRoundOutcome = roundOutcomeFactory.CreateRoundOutcome(jsonObject, viewModel.CurrentRound, viewModel.CurrentUser);

            //get death
            //viewModel.PlayerDeath = deathFactory.CreateDeath(jsonObject, viewModel.CurrentRound, viewModel.CurrentUser);

            //get kill
            //viewModel.PlayerKill = killFactory.CreateKill(jsonObject, viewModel.CurrentRound, viewModel.CurrentUser);

            return viewModel;




        }
    }
}
