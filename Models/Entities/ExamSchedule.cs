using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduPortal.Models.Entities
{
    public class ExamSchedule
    {
        [Key]
        public int ExamScheduleId { get; set; }

        public int CourseId { get; set; }

        public int StartDate { get; set; }

        public int EndDate { get; set; }

        public int ExamTypeId { get; set; }

        public int Lecturer { get; set; }

        public string? Location { get; set; }

        public int LocationTypeId { get; set; }

        // ------------------------------------------

        [ForeignKey("ExamTypeId")]
        public Inf_ExamTypes ExamType { get; set; }

        public List<ExamResults> ExamResults { get; set; }

        [ForeignKey("Lecturer")]
        public Users User { get; set; }

        [ForeignKey("CourseId")]
        public Courses Course { get; set; }

        [ForeignKey("LocationTypeId")]
        public Inf_CourseLocationTypes CourseLocationType { get; set; }
    }
}
