using EduPortal.Models.BaseClasses;
using System.ComponentModel.DataAnnotations;

namespace EduPortal.Models.Entities
{
    public class Enrollments : BaseClass2
    {
        [Key]
        public int EnrollmentId { get; set; }

        public int UserId { get; set; }

        public int CourseId { get; set; }

        // ---------------------------------

        public Users Users { get; set; }

        public Courses Courses { get; set; }
    }
}
