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
                return response.FailResponse("No course found");
            }

            return response.SuccessResponse(result, "Courses successfully found");
        }

        public async Task<ServiceResponse<CourseSelDTO>> GetCourseById(int courseId)
        {
            var response = new ServiceResponse<CourseSelDTO>();

            if (courseId <= 0)
                response.FailResponse("Given id can not be less or equal to zero");

            response.Data = await _repository.GetCourseById(courseId);

            if (response.Data == null || !response.Success)
                return response.FailResponse("No course with given id found");

            return response;
        }
    }
}
