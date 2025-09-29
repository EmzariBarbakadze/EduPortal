using EduPortal.Models.BaseClasses;
using System.ComponentModel.DataAnnotations;

namespace EduPortal.Models.Entities
{
    public class Inf_CourseLocationTypes : BaseClass3
    {
        [Key]
        public int LocationTypeId { get; set; }

        // --------------------------------------------

        public  List<ExamSchedule> ExamSchedules { get; set; }

        public List<CourseSchedule> CourseSchedules { get; set; }
    }
}
