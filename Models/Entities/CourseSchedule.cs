using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [ForeignKey("LocationTypeId")]
        public Inf_CourseLocationTypes LocationType { get; set; }

        [ForeignKey("CourseId")]
        public Courses Course { get; set; }

        public List<CourseScheduleAttributes> CourseScheduleAttributes { get; set; }
    }
}
