using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RSixSiegeHUD.Models
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }
        public string Name { get; set; }
        public bool IsLocal { get; set; }
        public string UbisoftAccountToken { get; set; }
        public int? UserId { get; set; }
        public int MatchId { get; set; }
        public int RoundId { get; set; }
    }
}
