using EduPortal.Interfaces;
using EduPortal.Models.DTOs;
using EduPortal.Models.HelperClasses;
using EduPortal.RepositoryInterfaces;
using Microsoft.IdentityModel.Tokens;

namespace EduPortal.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _repository;

        public CourseService(ICourseRepository repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResponse<List<CourseSelDTO>>> GetAllCourses()
        {
            var response = new ServiceResponse<List<CourseSelDTO>>();

            var result = await _repository.GetAllCourses();

            if (result.IsNullOrEmpty())
            {
                return response.FailResponse("Repository returned null or empty value");
            }

            return response.SuccessResponse(result, "Courses successfully found");
        }
    }
}
