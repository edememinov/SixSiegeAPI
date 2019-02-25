using RSixSiegeHUD.Infrastructure.Factories;
using RSixSiegeHUD.ViewModel;


namespace RSixSiegeHUD.Infrastructure
{
    public class GeneralObjectCreator
    {
        public SiegeViewModel SeperateObjects(dynamic jsonObject)
        {
            //set all the json objects from Overwolf API into objects
            if (jsonObject == null)
            {
                return null;
            }


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

            dynamic events = jsonObject.GetValue("events");
            dynamic eventsName = events[0].GetValue("name");

            //get user
            viewModel.CurrentUser = userFactory.CreateUser(jsonObject);

            //get match
            viewModel.CurrentMatch = matchFactory.CreateMatch(jsonObject, viewModel.CurrentUser);

            //get round
            viewModel.CurrentRound = roundFactory.CreateRound(jsonObject, viewModel.CurrentMatch);

            //get match outcome
            if (eventsName.ToString().Equals("matchOutcome")){
                viewModel.CurrentMatchOutcome = matchOutcomeFactory.CreateMatchOutcome(jsonObject, viewModel.CurrentRound, viewModel.CurrentUser);
            }
            

            //get local player
            viewModel.CurrentLocalPlayer = localPlayerFactory.CreateLocalPlayer(jsonObject, viewModel.CurrentRound, viewModel.CurrentUser);
            
            //get all players
            viewModel.CurrentPlayers = playerFactory.CreatePlayers(jsonObject, viewModel.CurrentRound, viewModel.CurrentUser);

            //get round outcome
            if (eventsName.ToString().Equals("roundOutcome")){
                viewModel.CurrentRoundOutcome = roundOutcomeFactory.CreateRoundOutcome(jsonObject, viewModel.CurrentRound, viewModel.CurrentUser);
            }
            

            //get death
            if (eventsName.ToString().Equals("killer")){
                viewModel.PlayerDeath = deathFactory.CreateDeath(jsonObject, viewModel.CurrentRound, viewModel.CurrentUser);
            }
            

            //get kill
            if (eventsName.ToString().Equals("kill") || eventsName.ToString().Equals("headshot"))
            {
                viewModel.PlayerKill = killFactory.CreateKill(jsonObject, viewModel.CurrentRound, viewModel.CurrentUser);
            }
            

            return viewModel;




        }
    }
}
