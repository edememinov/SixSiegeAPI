using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RSixSiegeHUD.Models
{
    public class LocalPlayer : Player
    {
        public int MatchId { get; set; }
        public int RoundId { get; set; }
        public int Health { get; set; }
        public int Score { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
    }
}
