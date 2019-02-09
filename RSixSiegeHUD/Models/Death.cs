using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RSixSiegeHUD.Models
{
    public class Death
    {
        [Key]
        public int DeathId { get; set; }
        
        public string UserId { get; set; }
        public int RoundId { get; set; }
        public string KilledBy { get; set; }
    }
}
