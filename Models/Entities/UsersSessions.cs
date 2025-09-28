using System.ComponentModel.DataAnnotations;

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

        public Users Users { get; set; }

        public Inf_RestrictionLevels Inf_RestrictionLevels { get; set; }

        public List<UserTokens> UserTokens { get; set; }
    }
}
