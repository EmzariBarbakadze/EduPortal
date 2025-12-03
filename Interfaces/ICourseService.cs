using EduPortal.Models.DTOs;
using EduPortal.Models.HelperClasses;

namespace EduPortal.Interfaces
{
    public interface ICourseService
    {
        public Task<ServiceResponse<List<CourseSelDTO>>> GetAllCourses();
    }
}
