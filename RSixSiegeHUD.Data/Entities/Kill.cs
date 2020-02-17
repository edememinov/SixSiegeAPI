using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RSixSiegeHUD.Data.Entities
{
    public class Kill : TimeStampObject
    {
        [Key]
        public int KillId { get; set; }
        public int UserId { get; set; }
        public int RoundId { get; set; }
        public bool Headshot { get; set; }
    }
}
