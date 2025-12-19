using EduPortal.Data;
using EduPortal.Models.DTOs;
using EduPortal.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using Dapper;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Data.SqlClient;
using System.Data;

namespace EduPortal.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly string _connectionString;

        public CourseRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection")!;
        }

        public async Task<bool> AddCourse(AddCourseDTO dto, int userId)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var parameters = new DynamicParameters();
            parameters.Add("@TitleLocal", dto.TitleLocal);
            parameters.Add("@TitleEng", dto.TitleEng);
            parameters.Add("@DescrLocal", dto.DescrLocal);
            parameters.Add("@DesctEng", dto.DescrEng);
            parameters.Add("@CourseCategoryId", dto.CourseCategoryId);
            parameters.Add("@UserId", userId);
            parameters.Add("@IsActive", dto.IsActive);

            try
            {
                await connection.ExecuteAsync(
                    "dbo.Edu_AddCourse",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );
            }
            catch
            {
                return false;
            }

            return true;
        }

        public async Task<List<CourseSelDTO>> GetAllCourses()
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var result = await connection.QueryAsync<CourseSelDTO>(
                    "Edu_GetAllCourses",
                    commandType: CommandType.StoredProcedure
                );

            return result.ToList();
        }

        public async Task<CourseSelDTO> GetCourseById(int courseId)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var result = await connection.QueryFirstOrDefaultAsync<CourseSelDTO>(
                    "Edu_GetCourseById",
                    new {CourseId = courseId},
                    commandType: CommandType.StoredProcedure
                );

            return result!;
        }
    }
}
