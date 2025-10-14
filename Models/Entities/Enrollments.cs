using EduPortal.Models.BaseClasses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduPortal.Models.Entities
{
    public class Enrollments : BaseClass2
    {
        [Key]
        public int EnrollmentId { get; set; }

        public int UserId { get; set; }

        public int CourseId { get; set; }

        // ---------------------------------

        [ForeignKey("UserId")]
        public Users User { get; set; }

        [ForeignKey("CourseId")]
        public Courses Course { get; set; }
    }
}
