using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public DateTime? BirthDate { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public DateTime? LastLoginAttempt { get; set; }

        public int LoginFailCounter { get; set; } = 0;

        public bool IsLocked { get; set; } = false;

        public DateTime? LockedUntill { get; set; }

        public bool IsVerified { get; set; } = false;

        // -------------------------------------------------------

        [ForeignKey("StatusId")]
        public Inf_UserStatuses UserStatus { get; set; }

        public List<UsersRoles> UsersRoles { get; set; }

        public List<UsersSessions> UsersSessions { get; set; }

        public List<UserTokens> UserTokens { get; set; }

        public List<UserAchievements> UserAchievements { get; set; }

        public List<ExceptionLogs> ExceptionLogs { get; set; }

        public List<ExamSchedule> ExamSchedules { get; set; }

        public List<Courses> Course { get; set; }

        public List<Enrollments> Enrollments { get; set; }

        public List<EmailVerification> EmailVerifications { get; set; }

        public List<CourseLecturers> CourseLecuters { get; set; }
    }
}
