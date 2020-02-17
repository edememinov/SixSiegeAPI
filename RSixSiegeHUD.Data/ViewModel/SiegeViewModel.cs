using RSixSiegeHUD.Data.Entities;
using System.Collections.Generic;

namespace RSixSiegeHUD.Data.ViewModel
{
    public class SiegeViewModel
    {
        public Death PlayerDeath { get; set; }
        public Kill PlayerKill { get; set; }
        public LocalPlayer CurrentLocalPlayer { get; set; }
        public Match CurrentMatch { get; set; }
        public MatchOutcome CurrentMatchOutcome { get; set; } 
        public List<Player> CurrentPlayers { get; set; }
        public Round CurrentRound { get; set; }
        public RoundOutcome CurrentRoundOutcome { get; set; }
        public User CurrentUser { get; set; }
    }
}
