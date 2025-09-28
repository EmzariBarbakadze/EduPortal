using EduPortal.Models.BaseClasses;

namespace EduPortal.Models.Entities
{
    public class Inf_NotificationTypes : BaseClass3
    {
        public int NotificationTypeId { get; set; }

        // ------------------------------------------

        public List<Notifications> Notifications { get; set; }
    }
}
