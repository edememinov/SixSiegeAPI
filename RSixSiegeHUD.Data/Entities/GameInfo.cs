using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RSixSiegeHUD.Data.Entities
{
    public class GameInfo
    {
        [Key]
        public int GameInfoId { get; set; }
        public string Phase { get; set; }
        public string MatchId { get; set; }
    }
}
