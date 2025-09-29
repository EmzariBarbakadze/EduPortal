using System.ComponentModel.DataAnnotations;

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

        public CourseSchedule CourseSchedule { get; set; }

        public Inf_ActivityTypes activityTypes { get; set; }

        public Inf_Weekdays WeekDays { get; set; }
    }
}
