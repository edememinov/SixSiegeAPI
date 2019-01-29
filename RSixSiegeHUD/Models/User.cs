using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RSixSiegeHUD.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public int UbisoftId { get; set; }
        public int OverwolfId { get; set; }
    }
}
