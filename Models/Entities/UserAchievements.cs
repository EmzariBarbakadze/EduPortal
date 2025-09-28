using EduPortal.Models.BaseClasses;
using System.ComponentModel.DataAnnotations;

namespace EduPortal.Models.Entities
{
    public class UserAchievements : BaseClass2
    {
        [Key]
        public int UserAchievementId { get; set; }

        public int UserId { get; set; }

        public int AchievementId { get; set; }

        // ---------------------------------------------

        public Achievements Achievements { get; set; }

        public Users Users { get; set; }
    }
}
