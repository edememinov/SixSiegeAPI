using RSixSiegeHUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RSixSiegeHUD.ViewModel
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
