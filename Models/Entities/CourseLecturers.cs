using EduPortal.Models.BaseClasses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduPortal.Models.Entities
{
    public class CourseLecturers : BaseClass2
    {
        [Key]
        public int Id { get; set; }

        public int CourseId { get; set; }

        public int LecturerId { get; set; }

        public int ActivityId { get; set; }

        // ----------------------------------

        [ForeignKey("CourseId")]
        public Courses Course { get; set; }

        [ForeignKey("LecturerId")]
        public Users User { get; set; }

        [ForeignKey("ActivityId")]
        public Inf_ActivityTypes ActivityType { get; set; }
    }
}
