using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace EduPortal.Models.Entities
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [NotNull, Required]
        public string UserName { get; set; }

        [EmailAddress, NotNull, Required]
        public string Email { get; set; }

        [NotNull, Required]
        public string PasswordHash { get; set; }

        public int StatusId { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public bool IsLocked { get; set; } = false;

        public DateTime? LockedUntill { get; set; }

        // -------------------------------------------------------

        public Inf_UserStatuses Inf_UserStatuses { get; set; }

        public List<UsersRoles> UsersRoles { get; set; }

        public List<UsersSessions> UsersSessions { get; set; }

        public List<UserTokens> UserTokens { get; set; }

        public List<UserAchievements> UserAchievements { get; set; }

        public List<ExceptionLogs> ExceptionLogs { get; set; }

        public List<ExamSchedule> ExamSchedules { get; set; }

        public List<Courses> Course { get; set; }

        public List<Enrollments> Enrollments { get; set; }
    }
}
