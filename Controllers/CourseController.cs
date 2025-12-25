using EduPortal.Interfaces;
using EduPortal.Models.DTOs;
using EduPortal.Models.Entities;
using EduPortal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EduPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _service;
        private readonly IErrorLogger _logger;

        public CourseController(ICourseService service, IErrorLogger logger)
        {
            _service = service;
            _logger = logger; 
        }

        [HttpGet("Get all courses")]
        public async Task<IActionResult> GetAllCourses()
        {
            var response = await _service.GetAllCourses();

            if (!response.Success)
            {
                await _logger.LogServiceErrorAsync(
                  "0000",
                  "Error from GetAllCourses service",
                  "Controller",
                  "GetAllCourses",
                  null
                );
                return BadRequest(response.Message);
            }

            return Ok(response);
        }

        [HttpGet("Get course by id")]
        public async Task<IActionResult> GetCourseById(int courseId)
        {
            var response = await _service.GetCourseById(courseId);

            if (!response.Success)
            {
                await _logger.LogServiceErrorAsync(
                  "0000",
                  "Error from GetCourseById service",
                  "Controller",
                  "GetCourseById",
                  null
                );
                return BadRequest(response.Message);
            }

            return Ok(response);
        }

        [HttpPost("Add course")]
        [Authorize(Roles = "Lecturer,Admin,SuperAdmin")]
        public async Task<IActionResult> AddCourse(AddCourseDTO dto)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            var response = await _service.AddCourse(dto, userId);

            if (!response.Success)
            {
                await _logger.LogServiceErrorAsync(
                  "0000",
                  "Error from AddCourse service",
                  "Controller",
                  "AddCourse",
                  null
                );
                return BadRequest(response.Message);
            }

            return Ok(response);
        }

        [HttpPut("Edit course")]
        [Authorize(Roles = "Lecturer,Admin,SuperAdmin")]
        public async Task<IActionResult> EditCourse()
        {
            return default;
        }

        [HttpDelete("Remove course")]
        [Authorize(Roles = "Lecturer,Admin,SuperAdmin")]
        public async Task<IActionResult> RemoveCourse()
        {
            return default;
        }

        [HttpPost("Assign course")]
        [Authorize(Roles = "Admin,SuperAdmin")]
        public async Task<IActionResult> AssignCourse()
        {
            return default;
        }
    }
}
