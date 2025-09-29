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

        [ForeignKey("UserId")]
        public int Lecturer { get; set; }

        public string? Location { get; set; }

        public int LocationTypeId { get; set; }

        // ------------------------------------------

        public Inf_ExamTypes ExamTypes { get; set; }

        public List<ExamResults> ExamResults { get; set; }

        public Users Users { get; set; }

        public Courses Courses { get; set; }

        public Inf_CourseLocationTypes CourseLocationTypes { get; set; }
    }
}
