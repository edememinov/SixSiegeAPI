using System.ComponentModel.DataAnnotations;

namespace RSixSiegeHUD.Data.Entities
{
    public class Death : TimeStampObject
    {
        [Key]
        public int DeathId { get; set; }
        
        public int UserId { get; set; }
        public int RoundId { get; set; }
        public string KilledBy { get; set; }
      
    }
}
