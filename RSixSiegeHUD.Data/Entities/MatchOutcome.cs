using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RSixSiegeHUD.Data.Entities
{
    public class MatchOutcome : TimeStampObject
    {
        [Key]
        public int MatchOutcomeId { get; set; }
        public int UserId { get; set; }
        public int MatchId { get; set; }
        public string Outcome { get; set; }
    }
}
