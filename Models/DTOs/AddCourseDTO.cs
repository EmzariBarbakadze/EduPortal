namespace EduPortal.Models.DTOs
{
    public class AddCourseDTO
    {
        public string TitleLocal { get; set; }

        public string TitleEng { get; set;  }

        public string DescrLocal { get; set; }

        public string DescrEng { get; set; }    

        public int CourseCategoryId { get; set; }   

        public bool IsActive { get; set; }
    }
}
