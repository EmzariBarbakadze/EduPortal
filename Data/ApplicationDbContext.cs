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
        public DbSet<Inf_NotificationTypes> Inf_NotificationTypes { get; set; }
        public DbSet<Inf_RestrictionLevels> Inf_RestrictionLevels { get; set; }
        public DbSet<Inf_UserStatuses> Inf_UserStatuses { get; set; }
        public DbSet<Inf_Weekdays> Inf_Weekdays { get; set; }
        public DbSet<Notifications> Notifications { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<UserAchievements> UserAchievements { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<UsersRoles> UsersRoles { get; set; }
        public DbSet<UsersSessions> UsersSessions { get; set; }
        public DbSet<UserTokens> UserTokens { get; set; }

        public DbSet<EmailVerification> EmailVerification { get; set; }


        // Seed Inf Tables

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Roles>().HasData(
                new Roles { RoleId = 1, DescrLocal = "სტუდენტი", DescrEng = "Student", IsActive = true },
                new Roles { RoleId = 2, DescrLocal = "ლექტორი", DescrEng = "Lecturer", IsActive = true },
                new Roles { RoleId = 3, DescrLocal = "ადმინისტრატორი", DescrEng = "Admin", IsActive = true },
                new Roles { RoleId = 4, DescrLocal = "სუპერ ადმინისტრატორი", DescrEng = "SuperAdmin", IsActive = true }
            );

            modelBuilder.Entity<Inf_ActivityTypes>().HasData(
                new Inf_ActivityTypes { ActivityTypeId = 1, DescrLocal = "ლექცია", DescrEng = "Lecture" },
                new Inf_ActivityTypes { ActivityTypeId = 2, DescrLocal = "სემინარი", DescrEng = "Working Group" },
                new Inf_ActivityTypes { ActivityTypeId = 3, DescrLocal = "პრაქტიკული", DescrEng = "Practicum" },
                new Inf_ActivityTypes { ActivityTypeId = 4, DescrLocal = "ლაბორატორიული", DescrEng = "Lab" }
            );

            modelBuilder.Entity<Inf_CourseCategories>().HasData(
                new Inf_CourseCategories { CourseCategoryId = 1, Code = "CS", DescrLocal = "კომპიუტერული მეცნიერება", DescrEng = "Computer Science", IsActive = true },
                new Inf_CourseCategories { CourseCategoryId = 2, Code = "MaTh", DescrLocal = "მათემატიკა", DescrEng = "Mathematics", IsActive = true },
                new Inf_CourseCategories { CourseCategoryId = 3, Code = "SC", DescrLocal = "საბუნებისმეტყველო მეცნიერება", DescrEng = "Natural Science", IsActive = true },
                new Inf_CourseCategories { CourseCategoryId = 4, Code = "GE", DescrLocal = "ზოგადი განათლება", DescrEng = "General Education", IsActive = true },
                new Inf_CourseCategories { CourseCategoryId = 5, Code = "Free", DescrLocal = "თავისუფალი კრედიტები", DescrEng = "Free Credits", IsActive = true }
            );

            modelBuilder.Entity<Inf_CourseLocationTypes>().HasData(
                new Inf_CourseLocationTypes { LocationTypeId = 1, DescrLocal = "ადგილზე", DescrEng = "On Site", IsActive = true },
                new Inf_CourseLocationTypes { LocationTypeId = 2, DescrLocal = "ონლაინ", DescrEng = "Online", IsActive = true },
                new Inf_CourseLocationTypes { LocationTypeId = 3, DescrLocal = "ჰიბრიდული", DescrEng = "Hybrid", IsActive = true }
            );

            modelBuilder.Entity<Inf_ErrorCodes>().HasData(
                new Inf_ErrorCodes { Code = 1000, DescrLocal = "არასწორი პარამეტრი ფუნქციაში", DescrEng = "Invalid parameter in the function", IsActive = true },
                new Inf_ErrorCodes { Code = 1001, DescrLocal = "მონაცემები ვერ მოიძებნა", DescrEng = "Data not found", IsActive = true },
                new Inf_ErrorCodes { Code = 1002, DescrLocal = "არასწორი შეყვანილი მონაცემები", DescrEng = "Invalid input data", IsActive = true },
                new Inf_ErrorCodes { Code = 1003, DescrLocal = "მომხმარებელი ვერ მოიძებნა", DescrEng = "User not found", IsActive = true },
                new Inf_ErrorCodes { Code = 1004, DescrLocal = "პაროლი არასწორია", DescrEng = "Invalid password", IsActive = true },
                new Inf_ErrorCodes { Code = 1005, DescrLocal = "წვდომა აკრძალულია", DescrEng = "Access denied", IsActive = true },
                new Inf_ErrorCodes { Code = 1006, DescrLocal = "სესია დასრულებულია", DescrEng = "Session expired", IsActive = true },
                new Inf_ErrorCodes { Code = 1007, DescrLocal = "მოთხოვნა არ არის ავტორიზებული", DescrEng = "Unauthorized request", IsActive = true },
                new Inf_ErrorCodes { Code = 1008, DescrLocal = "მონაცემების დამუშავება ვერ მოხერხდა", DescrEng = "Data processing failed", IsActive = true },
                new Inf_ErrorCodes { Code = 1009, DescrLocal = "სერვერი დროებით მიუწვდომელია", DescrEng = "Server temporarily unavailable", IsActive = true },
                new Inf_ErrorCodes { Code = 1010, DescrLocal = "კურსი ვერ მოიძებნა", DescrEng = "Course not found", IsActive = true },
                new Inf_ErrorCodes { Code = 1011, DescrLocal = "გამოცდა ვერ მოიძებნა", DescrEng = "Exam not found", IsActive = true },
                new Inf_ErrorCodes { Code = 1012, DescrLocal = "მომხმარებელს უკვე აქვს რეგისტრაცია", DescrEng = "User already registered", IsActive = true }
            );

            modelBuilder.Entity<Inf_ExamTypes>().HasData(
                new Inf_ExamTypes { ExamTypeId = 1, DescrLocal = "ქვიზი", DescrEng = "Quiz", IsActive = true },
                new Inf_ExamTypes { ExamTypeId = 2, DescrLocal = "შუალედური", DescrEng = "Midterm", IsActive = true },
                new Inf_ExamTypes { ExamTypeId = 3, DescrLocal = "ფინალური გამოცდა", DescrEng = "Final Exam", IsActive = true }
            );

            modelBuilder.Entity<Inf_NotificationTypes>().HasData(
                new Inf_NotificationTypes { NotificationTypeId = 1, DescrLocal = "ახალი კურსი დამატებულია", DescrEng = "New course added", IsActive = true },
                new Inf_NotificationTypes { NotificationTypeId = 2, DescrLocal = "გამოცდის დრო ახლოვდება", DescrEng = "Exam reminder", IsActive = true },
                new Inf_NotificationTypes { NotificationTypeId = 3, DescrLocal = "ახალი განცხადება/შეტყობინება", DescrEng = "New announcement", IsActive = true },
                new Inf_NotificationTypes { NotificationTypeId = 4, DescrLocal = "კურსში ახალი მასალა აიტვირთა", DescrEng = "New course material", IsActive = true },
                new Inf_NotificationTypes { NotificationTypeId = 5, DescrLocal = "შეფასება გამოქვეყნდა", DescrEng = "Grade published", IsActive = true },
                new Inf_NotificationTypes { NotificationTypeId = 6, DescrLocal = "ახალი შეტყობინება მიღებულია", DescrEng = "New message received", IsActive = true },
                new Inf_NotificationTypes { NotificationTypeId = 7, DescrLocal = "დავალების ვადა ახლოვდება", DescrEng = "Assignment due reminder", IsActive = true }
            );

            modelBuilder.Entity<Inf_RestrictionLevels>().HasData(
                new Inf_RestrictionLevels { RestrictionLevelId = 1, DescrLocal = "სატესტო რეჟიმი", DescrEng = "Test Mode", IsActive = true }
            );

            modelBuilder.Entity<Inf_UserStatuses>().HasData(
                 new Inf_UserStatuses { StatusId = 1, DescrLocal = "აქტიური", DescrEng = "Active", IsActive = true },
                 new Inf_UserStatuses { StatusId = 2, DescrLocal = "არაქტიური", DescrEng = "Inactive", IsActive = true },
                 new Inf_UserStatuses { StatusId = 3, DescrLocal = "შეჩერებული", DescrEng = "Suspended", IsActive = true },
                 new Inf_UserStatuses { StatusId = 4, DescrLocal = "დაბლოკილი", DescrEng = "Blocked", IsActive = true },
                 new Inf_UserStatuses { StatusId = 5, DescrLocal = "დაუდასტურებელი", DescrEng = "Unverified", IsActive = true },
                 new Inf_UserStatuses { StatusId = 6, DescrLocal = "წაშლილი", DescrEng = "Deleted", IsActive = true }
            );

            modelBuilder.Entity<Inf_Weekdays>().HasData(
                new Inf_Weekdays { WeekDayId = 1, DescrLocal = "ორშაბათი", DescrEng = "Monday" },
                new Inf_Weekdays { WeekDayId = 2, DescrLocal = "სამშაბათი", DescrEng = "Tuesday" },
                new Inf_Weekdays { WeekDayId = 3, DescrLocal = "ოთხშაბათი", DescrEng = "Wednesday" },
                new Inf_Weekdays { WeekDayId = 4, DescrLocal = "ხუთშაბათი", DescrEng = "Thursday" },
                new Inf_Weekdays { WeekDayId = 5, DescrLocal = "პარასკევი", DescrEng = "Friday" },
                new Inf_Weekdays { WeekDayId = 6, DescrLocal = "შაბათი", DescrEng = "Saturday" },
                new Inf_Weekdays { WeekDayId = 7, DescrLocal = "კვირა", DescrEng = "Sunday" }
            );
        }
    }
}
