using EduPortal.Models.BaseClasses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduPortal.Models.Entities
{
    public class UserAchievements : BaseClass2
    {
        [Key]
        public int UserAchievementId { get; set; }

        public int UserId { get; set; }

        public int AchievementId { get; set; }

        // ---------------------------------------------

        [ForeignKey("AchievementId")]
        public Achievements Achievement { get; set; }

        [ForeignKey("UserId")]
        public Users User { get; set; }
    }
}
