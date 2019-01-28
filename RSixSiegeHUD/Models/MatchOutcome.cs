﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RSixSiegeHUD.Models
{
    public class MatchOutcome
    {
        [Key]
        public int MatchOutcomeId { get; set; }
        public int UserId { get; set; }
        public int MatchId { get; set; }
        public string Outcome { get; set; }
    }
}
