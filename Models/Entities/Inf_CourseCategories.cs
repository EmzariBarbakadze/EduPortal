using EduPortal.Models.BaseClasses;
using System.ComponentModel.DataAnnotations;

namespace EduPortal.Models.Entities
{
    public class Inf_CourseCategories : BaseClass4
    {
        [Key]
        public int CourseCategoryId { get; set; }

        public string Code { get; set; }

        // ----------------------------------------------

        public List<Courses> Courses { get; set; }
    }
}
