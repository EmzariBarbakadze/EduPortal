using EduPortal.Models.DTOs;
using EduPortal.Models.HelperClasses;

namespace EduPortal.Interfaces
{
    public interface ICourseService
    {
        public Task<ServiceResponse<List<CourseSelDTO>>> GetAllCourses();

        public Task<ServiceResponse<CourseSelDTO>> GetCourseById(int courseId);

        public Task<ServiceResponse<bool>> AddCourse(AddCourseDTO dto, int userId);
    }
}
