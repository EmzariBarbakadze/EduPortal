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

        [ForeignKey("UserId")]
        public int Lecturer { get; set; }

        // ----------------------------------------

        public Users Users { get; set; }

        public Inf_ExamTypes ExamTypes { get; set; }

        public ExamSchedule ExamSchedules { get; set; }
    }
}
