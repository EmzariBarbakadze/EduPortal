using System.ComponentModel.DataAnnotations;

namespace EduPortal.Models.Entities
{
    public class Inf_Weekdays
    {
        [Key]
        public int WeekDayId { get; set; }

        public string DescrLocal { get; set; }

        public string DescrEng { get; set; }

        // -----------------------------------------

        public List<CourseScheduleAttributes> CourseScheduleAttributes { get; set; }
    }
}
