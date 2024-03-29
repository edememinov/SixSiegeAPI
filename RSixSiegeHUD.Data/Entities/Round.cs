﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RSixSiegeHUD.Data.Entities
{
    public class Round : TimeStampObject
    {
        [Key]
        public int RoundId { get; set; }
        public int MatchId { get; set; }
        public int RoundNumber { get; set; }
        public int UserId { get; set; }
        public int BlueTeamScore { get; set; }
        public int OrangeTeamScore { get; set; }
    }
}
