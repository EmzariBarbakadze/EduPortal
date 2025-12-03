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

        public int CreatorId { get; set; }

        // ---------------------------------------------

        public List<ExamSchedule> ExamSchedules { get; set; }

        [ForeignKey("CreatorId")]
        public Users Creator { get; set; }

        [ForeignKey("CourseCategoryId")]
        public Inf_CourseCategories Categories { get; set; }

        public List<Enrollments> Enrollments { get; set; }

        public List<CourseSchedule> CourseSchedules { get; set; }

        public List<CourseLecturers> CourseLecturers { get; set; }
    }
}
