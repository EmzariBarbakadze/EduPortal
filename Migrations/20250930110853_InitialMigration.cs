using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EduPortal.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Achievements",
                columns: table => new
                {
                    AchievementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescrLocal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescrEng = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConditionLocal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConditionEng = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achievements", x => x.AchievementId);
                });

            migrationBuilder.CreateTable(
                name: "Inf_ActivityTypes",
                columns: table => new
                {
                    ActivityTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescrLocal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescrEng = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inf_ActivityTypes", x => x.ActivityTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Inf_CourseCategories",
                columns: table => new
                {
                    CourseCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescrLocal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescrEng = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inf_CourseCategories", x => x.CourseCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Inf_CourseLocationTypes",
                columns: table => new
                {
                    LocationTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescrLocal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescrEng = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inf_CourseLocationTypes", x => x.LocationTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Inf_ErrorCodes",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescrLocal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescrEng = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inf_ErrorCodes", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Inf_ExamTypes",
                columns: table => new
                {
                    ExamTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescrLocal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescrEng = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inf_ExamTypes", x => x.ExamTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Inf_NotificationTypes",
                columns: table => new
                {
                    NotificationTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescrLocal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescrEng = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inf_NotificationTypes", x => x.NotificationTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Inf_RestrictionLevels",
                columns: table => new
                {
                    RestrictionLevelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescrLocal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescrEng = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inf_RestrictionLevels", x => x.RestrictionLevelId);
                });

            migrationBuilder.CreateTable(
                name: "Inf_UserStatuses",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescrLocal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescrEng = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inf_UserStatuses", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "Inf_Weekdays",
                columns: table => new
                {
                    WeekDayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescrLocal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescrEng = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inf_Weekdays", x => x.WeekDayId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescrLocal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescrEng = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsLocked = table.Column<bool>(type: "bit", nullable: false),
                    LockedUntill = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Inf_UserStatusesStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Inf_UserStatuses_Inf_UserStatusesStatusId",
                        column: x => x.Inf_UserStatusesStatusId,
                        principalTable: "Inf_UserStatuses",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleLocal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TitleEng = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionLocal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionEng = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseCategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    UsersUserId = table.Column<int>(type: "int", nullable: false),
                    CourseCategoriesCourseCategoryId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_Courses_Inf_CourseCategories_CourseCategoriesCourseCategoryId",
                        column: x => x.CourseCategoriesCourseCategoryId,
                        principalTable: "Inf_CourseCategories",
                        principalColumn: "CourseCategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Courses_Users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExceptionLogs",
                columns: table => new
                {
                    LogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Inf_ErrorCodesCode = table.Column<int>(type: "int", nullable: false),
                    UsersUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExceptionLogs", x => x.LogId);
                    table.ForeignKey(
                        name: "FK_ExceptionLogs_Inf_ErrorCodes_Inf_ErrorCodesCode",
                        column: x => x.Inf_ErrorCodesCode,
                        principalTable: "Inf_ErrorCodes",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExceptionLogs_Users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    NotificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    NotificationTypeId = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSent = table.Column<bool>(type: "bit", nullable: false),
                    UsersUserId = table.Column<int>(type: "int", nullable: false),
                    NotificationTypesNotificationTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.NotificationId);
                    table.ForeignKey(
                        name: "FK_Notifications_Inf_NotificationTypes_NotificationTypesNotificationTypeId",
                        column: x => x.NotificationTypesNotificationTypeId,
                        principalTable: "Inf_NotificationTypes",
                        principalColumn: "NotificationTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserAchievements",
                columns: table => new
                {
                    UserAchievementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AchievementId = table.Column<int>(type: "int", nullable: false),
                    AchievementsAchievementId = table.Column<int>(type: "int", nullable: false),
                    UsersUserId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAchievements", x => x.UserAchievementId);
                    table.ForeignKey(
                        name: "FK_UserAchievements_Achievements_AchievementsAchievementId",
                        column: x => x.AchievementsAchievementId,
                        principalTable: "Achievements",
                        principalColumn: "AchievementId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserAchievements_Users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersRoles",
                columns: table => new
                {
                    UserRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    UsersUserId = table.Column<int>(type: "int", nullable: false),
                    RolesRoleId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersRoles", x => x.UserRoleId);
                    table.ForeignKey(
                        name: "FK_UsersRoles_Roles_RolesRoleId",
                        column: x => x.RolesRoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersRoles_Users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersSessions",
                columns: table => new
                {
                    UserSessionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValidTill = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RestrictionLevelId = table.Column<int>(type: "int", nullable: false),
                    UsersUserId = table.Column<int>(type: "int", nullable: false),
                    Inf_RestrictionLevelsRestrictionLevelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersSessions", x => x.UserSessionId);
                    table.ForeignKey(
                        name: "FK_UsersSessions_Inf_RestrictionLevels_Inf_RestrictionLevelsRestrictionLevelId",
                        column: x => x.Inf_RestrictionLevelsRestrictionLevelId,
                        principalTable: "Inf_RestrictionLevels",
                        principalColumn: "RestrictionLevelId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersSessions_Users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseSchedules",
                columns: table => new
                {
                    CourseScheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WeeklyDuration = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationTypeId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CourseLocationTypesLocationTypeId = table.Column<int>(type: "int", nullable: false),
                    CoursesCourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSchedules", x => x.CourseScheduleId);
                    table.ForeignKey(
                        name: "FK_CourseSchedules_Courses_CoursesCourseId",
                        column: x => x.CoursesCourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseSchedules_Inf_CourseLocationTypes_CourseLocationTypesLocationTypeId",
                        column: x => x.CourseLocationTypesLocationTypeId,
                        principalTable: "Inf_CourseLocationTypes",
                        principalColumn: "LocationTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    EnrollmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    UsersUserId = table.Column<int>(type: "int", nullable: false),
                    CoursesCourseId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.EnrollmentId);
                    table.ForeignKey(
                        name: "FK_Enrollments_Courses_CoursesCourseId",
                        column: x => x.CoursesCourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Enrollments_Users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExamSchedule",
                columns: table => new
                {
                    ExamScheduleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<int>(type: "int", nullable: false),
                    EndDate = table.Column<int>(type: "int", nullable: false),
                    ExamTypeId = table.Column<int>(type: "int", nullable: false),
                    Lecturer = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationTypeId = table.Column<int>(type: "int", nullable: false),
                    ExamTypesExamTypeId = table.Column<int>(type: "int", nullable: false),
                    UsersUserId = table.Column<int>(type: "int", nullable: false),
                    CoursesCourseId = table.Column<int>(type: "int", nullable: false),
                    CourseLocationTypesLocationTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamSchedule", x => x.ExamScheduleId);
                    table.ForeignKey(
                        name: "FK_ExamSchedule_Courses_CoursesCourseId",
                        column: x => x.CoursesCourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExamSchedule_Inf_CourseLocationTypes_CourseLocationTypesLocationTypeId",
                        column: x => x.CourseLocationTypesLocationTypeId,
                        principalTable: "Inf_CourseLocationTypes",
                        principalColumn: "LocationTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExamSchedule_Inf_ExamTypes_ExamTypesExamTypeId",
                        column: x => x.ExamTypesExamTypeId,
                        principalTable: "Inf_ExamTypes",
                        principalColumn: "ExamTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExamSchedule_Users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    TokenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JwtId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RewokedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    IpAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SessionId = table.Column<int>(type: "int", nullable: true),
                    UsersSessionsUserSessionId = table.Column<int>(type: "int", nullable: false),
                    UsersUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => x.TokenId);
                    table.ForeignKey(
                        name: "FK_UserTokens_UsersSessions_UsersSessionsUserSessionId",
                        column: x => x.UsersSessionsUserSessionId,
                        principalTable: "UsersSessions",
                        principalColumn: "UserSessionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseScheduleAttributes",
                columns: table => new
                {
                    CourseScheduleAttributeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseScheduleId = table.Column<int>(type: "int", nullable: false),
                    ActivityTypeId = table.Column<int>(type: "int", nullable: false),
                    WeekDayId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    activityTypesActivityTypeId = table.Column<int>(type: "int", nullable: false),
                    WeekDaysWeekDayId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseScheduleAttributes", x => x.CourseScheduleAttributeId);
                    table.ForeignKey(
                        name: "FK_CourseScheduleAttributes_CourseSchedules_CourseScheduleId",
                        column: x => x.CourseScheduleId,
                        principalTable: "CourseSchedules",
                        principalColumn: "CourseScheduleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseScheduleAttributes_Inf_ActivityTypes_activityTypesActivityTypeId",
                        column: x => x.activityTypesActivityTypeId,
                        principalTable: "Inf_ActivityTypes",
                        principalColumn: "ActivityTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseScheduleAttributes_Inf_Weekdays_WeekDaysWeekDayId",
                        column: x => x.WeekDaysWeekDayId,
                        principalTable: "Inf_Weekdays",
                        principalColumn: "WeekDayId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExamResults",
                columns: table => new
                {
                    ExamResultId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamScheduleId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ExamTypeId = table.Column<int>(type: "int", nullable: false),
                    ResultScore = table.Column<float>(type: "real", nullable: false),
                    ExamDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Lecturer = table.Column<int>(type: "int", nullable: false),
                    UsersUserId = table.Column<int>(type: "int", nullable: false),
                    ExamTypesExamTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamResults", x => x.ExamResultId);
                    table.ForeignKey(
                        name: "FK_ExamResults_ExamSchedule_ExamScheduleId",
                        column: x => x.ExamScheduleId,
                        principalTable: "ExamSchedule",
                        principalColumn: "ExamScheduleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExamResults_Inf_ExamTypes_ExamTypesExamTypeId",
                        column: x => x.ExamTypesExamTypeId,
                        principalTable: "Inf_ExamTypes",
                        principalColumn: "ExamTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExamResults_Users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Inf_ActivityTypes",
                columns: new[] { "ActivityTypeId", "DescrEng", "DescrLocal" },
                values: new object[,]
                {
                    { 1, "Lecture", "ლექცია" },
                    { 2, "Working Group", "სემინარი" },
                    { 3, "Practicum", "პრაქტიკული" },
                    { 4, "Lab", "ლაბორატორიული" }
                });

            migrationBuilder.InsertData(
                table: "Inf_CourseCategories",
                columns: new[] { "CourseCategoryId", "Code", "DescrEng", "DescrLocal", "IsActive" },
                values: new object[,]
                {
                    { 1, "CS", "Computer Science", "კომპიუტერული მეცნიერება", true },
                    { 2, "MaTh", "Mathematics", "მათემატიკა", true },
                    { 3, "SC", "Natural Science", "საბუნებისმეტყველო მეცნიერება", true },
                    { 4, "GE", "General Education", "ზოგადი განათლება", true },
                    { 5, "Free", "Free Credits", "თავისუფალი კრედიტები", true }
                });

            migrationBuilder.InsertData(
                table: "Inf_CourseLocationTypes",
                columns: new[] { "LocationTypeId", "DescrEng", "DescrLocal", "IsActive" },
                values: new object[,]
                {
                    { 1, "On Site", "ადგილზე", true },
                    { 2, "Online", "ონლაინ", true },
                    { 3, "Hybrid", "ჰიბრიდული", true }
                });

            migrationBuilder.InsertData(
                table: "Inf_ErrorCodes",
                columns: new[] { "Code", "DescrEng", "DescrLocal", "IsActive" },
                values: new object[,]
                {
                    { 1000, "General system error", "ზოგადი შეცდომა", true },
                    { 1001, "Data not found", "მონაცემები ვერ მოიძებნა", true },
                    { 1002, "Invalid input data", "არასწორი შეყვანილი მონაცემები", true },
                    { 1003, "User not found", "მომხმარებელი ვერ მოიძებნა", true },
                    { 1004, "Invalid password", "პაროლი არასწორია", true },
                    { 1005, "Access denied", "წვდომა აკრძალულია", true },
                    { 1006, "Session expired", "სესია დასრულებულია", true },
                    { 1007, "Unauthorized request", "მოთხოვნა არ არის ავტორიზებული", true },
                    { 1008, "Data processing failed", "მონაცემების დამუშავება ვერ მოხერხდა", true },
                    { 1009, "Server temporarily unavailable", "სერვერი დროებით მიუწვდომელია", true },
                    { 1010, "Course not found", "კურსი ვერ მოიძებნა", true },
                    { 1011, "Exam not found", "გამოცდა ვერ მოიძებნა", true },
                    { 1012, "User already registered", "მომხმარებელს უკვე აქვს რეგისტრაცია", true }
                });

            migrationBuilder.InsertData(
                table: "Inf_ExamTypes",
                columns: new[] { "ExamTypeId", "DescrEng", "DescrLocal", "IsActive" },
                values: new object[,]
                {
                    { 1, "Quiz", "ქვიზი", true },
                    { 2, "Midterm", "შუალედური", true },
                    { 3, "Final Exam", "ფინალური გამოცდა", true }
                });

            migrationBuilder.InsertData(
                table: "Inf_NotificationTypes",
                columns: new[] { "NotificationTypeId", "DescrEng", "DescrLocal", "IsActive" },
                values: new object[,]
                {
                    { 1, "New course added", "ახალი კურსი დამატებულია", true },
                    { 2, "Exam reminder", "გამოცდის დრო ახლოვდება", true },
                    { 3, "New announcement", "ახალი განცხადება/შეტყობინება", true },
                    { 4, "New course material", "კურსში ახალი მასალა აიტვირთა", true },
                    { 5, "Grade published", "შეფასება გამოქვეყნდა", true },
                    { 6, "New message received", "ახალი შეტყობინება მიღებულია", true },
                    { 7, "Assignment due reminder", "დავალების ვადა ახლოვდება", true }
                });

            migrationBuilder.InsertData(
                table: "Inf_RestrictionLevels",
                columns: new[] { "RestrictionLevelId", "DescrEng", "DescrLocal", "IsActive" },
                values: new object[] { 1, "Test Mode", "სატესტო რეჟიმი", true });

            migrationBuilder.InsertData(
                table: "Inf_UserStatuses",
                columns: new[] { "StatusId", "DescrEng", "DescrLocal", "IsActive" },
                values: new object[,]
                {
                    { 1, "Active", "აქტიური", true },
                    { 2, "Inactive", "არაქტიური", true },
                    { 3, "Suspended", "შეჩერებული", true },
                    { 4, "Blocked", "დაბლოკილი", true },
                    { 5, "Registered (Unconfirmed)", "დარეგისტრირებული, დაუდასტურებელი", true },
                    { 6, "Deleted", "წაშლილი", true }
                });

            migrationBuilder.InsertData(
                table: "Inf_Weekdays",
                columns: new[] { "WeekDayId", "DescrEng", "DescrLocal" },
                values: new object[,]
                {
                    { 1, "Monday", "ორშაბათი" },
                    { 2, "Tuesday", "სამშაბათი" },
                    { 3, "Wednesday", "ოთხშაბათი" },
                    { 4, "Thursday", "ხუთშაბათი" },
                    { 5, "Friday", "პარასკევი" },
                    { 6, "Saturday", "შაბათი" },
                    { 7, "Sunday", "კვირა" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "DescrEng", "DescrLocal", "IsActive" },
                values: new object[,]
                {
                    { 1, "Student", "სტუდენტი", true },
                    { 2, "Lecturer", "ლექტორი", true },
                    { 3, "Admin", "ადმინისტრატორი", true },
                    { 4, "SuperAdmin", "სუპერ ადმინისტრატორი", true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseCategoriesCourseCategoryId",
                table: "Courses",
                column: "CourseCategoriesCourseCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_UsersUserId",
                table: "Courses",
                column: "UsersUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseScheduleAttributes_activityTypesActivityTypeId",
                table: "CourseScheduleAttributes",
                column: "activityTypesActivityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseScheduleAttributes_CourseScheduleId",
                table: "CourseScheduleAttributes",
                column: "CourseScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseScheduleAttributes_WeekDaysWeekDayId",
                table: "CourseScheduleAttributes",
                column: "WeekDaysWeekDayId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSchedules_CourseLocationTypesLocationTypeId",
                table: "CourseSchedules",
                column: "CourseLocationTypesLocationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSchedules_CoursesCourseId",
                table: "CourseSchedules",
                column: "CoursesCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_CoursesCourseId",
                table: "Enrollments",
                column: "CoursesCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_UsersUserId",
                table: "Enrollments",
                column: "UsersUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamResults_ExamScheduleId",
                table: "ExamResults",
                column: "ExamScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamResults_ExamTypesExamTypeId",
                table: "ExamResults",
                column: "ExamTypesExamTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamResults_UsersUserId",
                table: "ExamResults",
                column: "UsersUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamSchedule_CourseLocationTypesLocationTypeId",
                table: "ExamSchedule",
                column: "CourseLocationTypesLocationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamSchedule_CoursesCourseId",
                table: "ExamSchedule",
                column: "CoursesCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamSchedule_ExamTypesExamTypeId",
                table: "ExamSchedule",
                column: "ExamTypesExamTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamSchedule_UsersUserId",
                table: "ExamSchedule",
                column: "UsersUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExceptionLogs_Inf_ErrorCodesCode",
                table: "ExceptionLogs",
                column: "Inf_ErrorCodesCode");

            migrationBuilder.CreateIndex(
                name: "IX_ExceptionLogs_UsersUserId",
                table: "ExceptionLogs",
                column: "UsersUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_NotificationTypesNotificationTypeId",
                table: "Notifications",
                column: "NotificationTypesNotificationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UsersUserId",
                table: "Notifications",
                column: "UsersUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAchievements_AchievementsAchievementId",
                table: "UserAchievements",
                column: "AchievementsAchievementId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAchievements_UsersUserId",
                table: "UserAchievements",
                column: "UsersUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Inf_UserStatusesStatusId",
                table: "Users",
                column: "Inf_UserStatusesStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersRoles_RolesRoleId",
                table: "UsersRoles",
                column: "RolesRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersRoles_UsersUserId",
                table: "UsersRoles",
                column: "UsersUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersSessions_Inf_RestrictionLevelsRestrictionLevelId",
                table: "UsersSessions",
                column: "Inf_RestrictionLevelsRestrictionLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersSessions_UsersUserId",
                table: "UsersSessions",
                column: "UsersUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTokens_UsersSessionsUserSessionId",
                table: "UserTokens",
                column: "UsersSessionsUserSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTokens_UsersUserId",
                table: "UserTokens",
                column: "UsersUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseScheduleAttributes");

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "ExamResults");

            migrationBuilder.DropTable(
                name: "ExceptionLogs");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "UserAchievements");

            migrationBuilder.DropTable(
                name: "UsersRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "CourseSchedules");

            migrationBuilder.DropTable(
                name: "Inf_ActivityTypes");

            migrationBuilder.DropTable(
                name: "Inf_Weekdays");

            migrationBuilder.DropTable(
                name: "ExamSchedule");

            migrationBuilder.DropTable(
                name: "Inf_ErrorCodes");

            migrationBuilder.DropTable(
                name: "Inf_NotificationTypes");

            migrationBuilder.DropTable(
                name: "Achievements");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "UsersSessions");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Inf_CourseLocationTypes");

            migrationBuilder.DropTable(
                name: "Inf_ExamTypes");

            migrationBuilder.DropTable(
                name: "Inf_RestrictionLevels");

            migrationBuilder.DropTable(
                name: "Inf_CourseCategories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Inf_UserStatuses");
        }
    }
}
