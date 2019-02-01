using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RSixSiegeHUD.Models
{
    public class Kill
    {
        [Key]
        public int KillId { get; set; }
        public int UserId { get; set; }
        public int RoundId { get; set; }
        public bool Headshot { get; set; }
    }
}
