using EduPortal.Models.BaseClasses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduPortal.Models.Entities
{
    public class Courses : BaseClass2
    {
        [Key]
        public int CourseId { get; set; }

        public string TitleLocal { get; set; }

        public string TitleEng { get; set; }

        public string DescriptionLocal { get; set; }

        public string DescriptionEng { get; set; }

        public int CourseCategoryId { get; set; }

        [ForeignKey("UserId")]
        public int CreatorId { get; set; }

        // ---------------------------------------------

        public List<ExamSchedule> ExamSchedules { get; set; }

        public Users Users { get; set; }

        public Inf_CourseCategories CourseCategories { get; set; }

        public List<Enrollments> Enrollments { get; set; }

        public List<CourseSchedule> CourseSchedules { get; set; }
    }
}
