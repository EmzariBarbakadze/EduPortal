using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduPortal.Models.Entities
{
    public class ExamResults
    {
        [Key]
        public int ExamResultId { get; set; }

        public int ExamScheduleId { get; set; }

        public int UserId { get; set; }

        public int ExamTypeId { get; set; }

        public float ResultScore { get; set; }

        public DateTime ExamDate { get; set; }

        public int Lecturer { get; set; }

        // ----------------------------------------

        [ForeignKey("Lecturer")]
        public Users User { get; set; }

        [ForeignKey("ExamTypeId")]
        public Inf_ExamTypes ExamType { get; set; }

        [ForeignKey("ExamScheduleId")]
        public ExamSchedule Schedule { get; set; }
    }
}
