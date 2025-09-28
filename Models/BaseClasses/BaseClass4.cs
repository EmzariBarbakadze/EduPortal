namespace EduPortal.Models.BaseClasses
{
    public class BaseClass4
    {
        public string DescrLocal { get; set; }

        public string DescrEng { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;
    }
}
