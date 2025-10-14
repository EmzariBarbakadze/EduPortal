using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduPortal.Models.Entities
{
    public class CourseScheduleAttributes
    {
        [Key]
        public int CourseScheduleAttributeId { get; set; }

        public int CourseScheduleId { get; set; }

        public int ActivityTypeId { get; set; }

        public int WeekDayId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsActive { get; set; } = true;

        // ---------------------------------------------------

        [ForeignKey("CourseScheduleId")]
        public CourseSchedule Schedule { get; set; }

        [ForeignKey("ActivityTypeId")]
        public Inf_ActivityTypes Activity { get; set; }

        [ForeignKey("WeekDayId")]
        public Inf_Weekdays WeekDay { get; set; }
    }
}
