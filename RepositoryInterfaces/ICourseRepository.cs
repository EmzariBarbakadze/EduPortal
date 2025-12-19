using EduPortal.Models.DTOs;

namespace EduPortal.RepositoryInterfaces
{
    public interface ICourseRepository
    {
        public Task<List<CourseSelDTO>> GetAllCourses();

        public Task<CourseSelDTO> GetCourseById(int courseId);

        public Task<bool> AddCourse(AddCourseDTO dto, int userId);
    }
}
