using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RSixSiegeHUD.Models
{
    public class Match
    {
        [Key]
        public int MatchId { get; set; }
        public int ScoreBlueTeam { get; set; }
        public int ScoreOrangeTeam { get; set; }
        public byte[] MatchToken { get; set; }

    }
}
