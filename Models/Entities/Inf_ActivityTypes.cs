using System.ComponentModel.DataAnnotations;

namespace EduPortal.Models.Entities
{
    public class Inf_ActivityTypes
    {
        [Key]
        public int ActivityTypeId { get; set; }

        public string DescrLocal { get; set; }

        public string DescrEng { get; set; }

        // ------------------------------------------------

        public List<CourseScheduleAttributes> CourseScheduleAttributes { get; set; }

        public List<CourseLecturers> CourseLecturers { get; set; }
    }
}
