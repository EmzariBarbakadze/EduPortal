using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduPortal.Models.Entities
{
    public class UsersSessions
    {
        [Key]
        public int UserSessionId { get; set; }

        public int UserId { get; set; }

        public DateTime DateStart { get; set; } = DateTime.Now;

        public DateTime? DateEnd { get; set; }

        public DateTime ValidTill { get; set; } //= DateTime.Now.AddMinutes(15);

        public string IpAdress { get; set; }

        public int RestrictionLevelId { get; set; }


        // ----------------------------------------------------

        [ForeignKey("UserId")]
        public Users User { get; set; }

        [ForeignKey("RestrictionLevelId")]
        public Inf_RestrictionLevels RestrictionLevel { get; set; }

        public List<UserTokens> UserTokens { get; set; }
    }
}
