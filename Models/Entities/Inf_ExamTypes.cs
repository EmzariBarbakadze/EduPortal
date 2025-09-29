using EduPortal.Models.BaseClasses;
using System.ComponentModel.DataAnnotations;

namespace EduPortal.Models.Entities
{
    public class Inf_ExamTypes : BaseClass3
    {
        [Key]
        public int ExamTypeId { get; set; }

        // ---------------------------------------

        public List<ExamResults> ExamResults { get; set; }

        public List<ExamSchedule> ExamSchedules { get; set; }
    }
}
