using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RSixSiegeHUD.Data.Entities
{
    public class RoundOutcome
    {
        [Key]
        public int RoundOutcomeId { get; set; }
        public int UserId { get; set; }
        public int RoundId { get; set; }
        public string Outcome { get; set; }
    }
}
