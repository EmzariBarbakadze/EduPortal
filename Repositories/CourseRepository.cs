using EduPortal.Data;
using EduPortal.Models.DTOs;
using EduPortal.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace EduPortal.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CourseSelDTO>> GetAllCourses()
        {
            var result = await _context.Database.SqlQueryRaw<CourseSelDTO>("EXEC Edu_GetAllCourses").ToListAsync();

            if (result.IsNullOrEmpty())
                return null;
            else
                return result;
        }
    }
}
