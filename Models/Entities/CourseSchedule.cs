using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;

namespace EduPortal.Models.Entities
{
    public class CourseSchedule
    {
        [Key]
        public int CourseScheduleId { get; set; }
        
        public int CourseId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int WeeklyDuration { get; set; }

        public string? Location { get; set; }

        public int LocationTypeId { get; set; }

        public bool IsActive { get; set; } = true;

        // ------------------------------------------

        public Inf_CourseLocationTypes CourseLocationTypes { get; set; }

        public Courses Courses { get; set; }

        public List<CourseScheduleAttributes> CourseScheduleAttributes { get; set; }
    }
}
