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
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastLoginAttempt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LoginFailCounter = table.Column<int>(type: "int", nullable: false),
                    IsLocked = table.Column<bool>(type: "bit", nullable: false),
                    LockedUntill = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Inf_UserStatuses_StatusId",
                        column: x => x.StatusId,
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
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_Courses_Inf_CourseCategories_CourseCategoryId",
                        column: x => x.CourseCategoryId,
                        principalTable: "Inf_CourseCategories",
                        principalColumn: "CourseCategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Courses_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmailVerification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailVerification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailVerification_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExceptionLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StackTrace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Layer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Method = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExceptionLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExceptionLogs_Inf_ErrorCodes_Code",
                        column: x => x.Code,
                        principalTable: "Inf_ErrorCodes",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_ExceptionLogs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
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
                    IsSent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.NotificationId);
                    table.ForeignKey(
                        name: "FK_Notifications_Inf_NotificationTypes_NotificationTypeId",
                        column: x => x.NotificationTypeId,
                        principalTable: "Inf_NotificationTypes",
                        principalColumn: "NotificationTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserId",
                        column: x => x.UserId,
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
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAchievements", x => x.UserAchievementId);
                    table.ForeignKey(
                        name: "FK_UserAchievements_Achievements_AchievementId",
                        column: x => x.AchievementId,
                        principalTable: "Achievements",
                        principalColumn: "AchievementId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserAchievements_Users_UserId",
                        column: x => x.UserId,
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
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersRoles", x => x.UserRoleId);
                    table.ForeignKey(
                        name: "FK_UsersRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersRoles_Users_UserId",
                        column: x => x.UserId,
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
                    ValidTill = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpAdress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeviceInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RestrictionLevelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersSessions", x => x.UserSessionId);
                    table.ForeignKey(
                        name: "FK_UsersSessions_Inf_RestrictionLevels_RestrictionLevelId",
                        column: x => x.RestrictionLevelId,
                        principalTable: "Inf_RestrictionLevels",
                        principalColumn: "RestrictionLevelId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersSessions_Users_UserId",
                        column: x => x.UserId,
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
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSchedules", x => x.CourseScheduleId);
                    table.ForeignKey(
                        name: "FK_CourseSchedules_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseSchedules_Inf_CourseLocationTypes_LocationTypeId",
                        column: x => x.LocationTypeId,
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
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.EnrollmentId);
                    table.ForeignKey(
                        name: "FK_Enrollments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Enrollments_Users_UserId",
                        column: x => x.UserId,
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
                    LocationTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamSchedule", x => x.ExamScheduleId);
                    table.ForeignKey(
                        name: "FK_ExamSchedule_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExamSchedule_Inf_CourseLocationTypes_LocationTypeId",
                        column: x => x.LocationTypeId,
                        principalTable: "Inf_CourseLocationTypes",
                        principalColumn: "LocationTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExamSchedule_Inf_ExamTypes_ExamTypeId",
                        column: x => x.ExamTypeId,
                        principalTable: "Inf_ExamTypes",
                        principalColumn: "ExamTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExamSchedule_Users_Lecturer",
                        column: x => x.Lecturer,
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
                    RefreshToken = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Salt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    JwtId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RevokedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SessionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => x.TokenId);
                    table.ForeignKey(
                        name: "FK_UserTokens_UsersSessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "UsersSessions",
                        principalColumn: "UserSessionId");
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
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
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
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
                        name: "FK_CourseScheduleAttributes_Inf_ActivityTypes_ActivityTypeId",
                        column: x => x.ActivityTypeId,
                        principalTable: "Inf_ActivityTypes",
                        principalColumn: "ActivityTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseScheduleAttributes_Inf_Weekdays_WeekDayId",
                        column: x => x.WeekDayId,
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
                    Lecturer = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_ExamResults_Inf_ExamTypes_ExamTypeId",
                        column: x => x.ExamTypeId,
                        principalTable: "Inf_ExamTypes",
                        principalColumn: "ExamTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExamResults_Users_Lecturer",
                        column: x => x.Lecturer,
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
                    { "0000", "Unknown error", "უცნობი შეცდომა", true },
                    { "1000", "Invalid parameter in the function", "არასწორი პარამეტრი ფუნქციაში", true },
                    { "1001", "Data not found", "მონაცემები ვერ მოიძებნა", true },
                    { "1002", "Invalid input data", "არასწორი შეყვანილი მონაცემები", true },
                    { "1003", "User not found", "მომხმარებელი ვერ მოიძებნა", true },
                    { "1004", "Invalid password", "პაროლი არასწორია", true },
                    { "1005", "Access denied", "წვდომა აკრძალულია", true },
                    { "1006", "Session expired", "სესია დასრულებულია", true },
                    { "1007", "Unauthorized request", "მოთხოვნა არ არის ავტორიზებული", true },
                    { "1008", "Data processing failed", "მონაცემების დამუშავება ვერ მოხერხდა", true },
                    { "1009", "Server temporarily unavailable", "სერვერი დროებით მიუწვდომელია", true },
                    { "1010", "Course not found", "კურსი ვერ მოიძებნა", true },
                    { "1011", "Exam not found", "გამოცდა ვერ მოიძებნა", true },
                    { "1012", "User already registered", "მომხმარებელს უკვე აქვს რეგისტრაცია", true }
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
                    { 7, "Assignment due reminder", "დავალების ვადა ახლოვდება", true },
                    { 8, "Verification pin code", "ვერიფიკაციის პინ კოდი", true },
                    { 9, "Your account is locked", "თქვენი ანგარიში დაილოქა", true }
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
                    { 5, "Unverified", "დაუდასტურებელი", true },
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
                name: "IX_Courses_CourseCategoryId",
                table: "Courses",
                column: "CourseCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CreatorId",
                table: "Courses",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseScheduleAttributes_ActivityTypeId",
                table: "CourseScheduleAttributes",
                column: "ActivityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseScheduleAttributes_CourseScheduleId",
                table: "CourseScheduleAttributes",
                column: "CourseScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseScheduleAttributes_WeekDayId",
                table: "CourseScheduleAttributes",
                column: "WeekDayId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSchedules_CourseId",
                table: "CourseSchedules",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSchedules_LocationTypeId",
                table: "CourseSchedules",
                column: "LocationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailVerification_UserId",
                table: "EmailVerification",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_CourseId",
                table: "Enrollments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_UserId",
                table: "Enrollments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamResults_ExamScheduleId",
                table: "ExamResults",
                column: "ExamScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamResults_ExamTypeId",
                table: "ExamResults",
                column: "ExamTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamResults_Lecturer",
                table: "ExamResults",
                column: "Lecturer");

            migrationBuilder.CreateIndex(
                name: "IX_ExamSchedule_CourseId",
                table: "ExamSchedule",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamSchedule_ExamTypeId",
                table: "ExamSchedule",
                column: "ExamTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamSchedule_Lecturer",
                table: "ExamSchedule",
                column: "Lecturer");

            migrationBuilder.CreateIndex(
                name: "IX_ExamSchedule_LocationTypeId",
                table: "ExamSchedule",
                column: "LocationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExceptionLogs_Code",
                table: "ExceptionLogs",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_ExceptionLogs_UserId",
                table: "ExceptionLogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_NotificationTypeId",
                table: "Notifications",
                column: "NotificationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAchievements_AchievementId",
                table: "UserAchievements",
                column: "AchievementId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAchievements_UserId",
                table: "UserAchievements",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_StatusId",
                table: "Users",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersRoles_RoleId",
                table: "UsersRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersRoles_UserId",
                table: "UsersRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersSessions_RestrictionLevelId",
                table: "UsersSessions",
                column: "RestrictionLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersSessions_UserId",
                table: "UsersSessions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTokens_SessionId",
                table: "UserTokens",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTokens_UserId",
                table: "UserTokens",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseScheduleAttributes");

            migrationBuilder.DropTable(
                name: "EmailVerification");

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
