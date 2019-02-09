using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RSixSiegeHUD.Models
{
    public class LocalPlayer : Player
    {
        public int Health { get; set; }
        public int Score { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
    }
}
