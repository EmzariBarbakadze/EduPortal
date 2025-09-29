using EduPortal.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduPortal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Achievements> Achievements { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<CourseSchedule> CourseSchedules { get; set; }
        public DbSet<CourseScheduleAttributes> CourseScheduleAttributes { get; set; }
        public DbSet<Enrollments> Enrollments { get; set; }
        public DbSet<ExamResults> ExamResults { get; set; }
        public DbSet<ExamSchedule> ExamSchedule { get; set; }
        public DbSet<ExceptionLogs> ExceptionLogs { get; set; }
        public DbSet<Inf_ActivityTypes> Inf_ActivityTypes { get; set; }
        public DbSet<Inf_CourseCategories> Inf_CourseCategories { get; set; }
        public DbSet<Inf_CourseLocationTypes> Inf_CourseLocationTypes { get; set; }
        public DbSet<Inf_ErrorCodes> Inf_ErrorCodes { get; set; }
        public DbSet<Inf_ExamTypes> Inf_ExamTypes { get; set; }
        public DbSet<Inf_NotificationTypes> Inf_RestrictionLevels { get; set; }
        public DbSet<Inf_UserStatuses> Inf_UserStatuses { get; set; }
        public DbSet<Inf_Weekdays> Inf_Weekdays { get; set; }
        public DbSet<Notifications> Notifications { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<UserAchievements> UserAchievements { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<UsersRoles> UsersRoles { get; set; }
        public DbSet<UsersSessions> UsersSessions { get; set; }
        public DbSet<UserTokens> UserTokens { get; set; }
    }
}
