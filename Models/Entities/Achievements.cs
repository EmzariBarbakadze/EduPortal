using System.ComponentModel.DataAnnotations;

namespace EduPortal.Models.Entities
{
    public class Achievements
    {
        [Key]
        public int AchievementId { get; set; }

        public string DescrLocal { get; set; }

        public string DescrEng { get; set; }

        public string ConditionLocal { get; set; }

        public string ConditionEng { get; set; }

        public bool IsActive { get; set; } = true;

        // -----------------------------------------

        public List<UserAchievements> UserAchievements { get; set; }
    }
}
