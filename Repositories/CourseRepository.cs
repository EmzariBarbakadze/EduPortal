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
