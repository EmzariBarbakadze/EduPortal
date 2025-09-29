using EduPortal.Models.BaseClasses;
using System.ComponentModel.DataAnnotations;

namespace EduPortal.Models.Entities
{
    public class Inf_NotificationTypes : BaseClass3
    {
        [Key]
        public int NotificationTypeId { get; set; }

        // ------------------------------------------

        public List<Notifications> Notifications { get; set; }
    }
}
