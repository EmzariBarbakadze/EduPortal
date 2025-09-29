using System.ComponentModel.DataAnnotations;

namespace EduPortal.Models.Entities
{
    public class Notifications
    {
        [Key]
        public int NotificationId { get; set; }

        public int UserId { get; set; }

        public int NotificationTypeId { get; set; }

        public string Message { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public bool IsSent { get; set; } = false;

        // -----------------------------------------------------

        public Users Users { get; set; }

        public Inf_NotificationTypes NotificationTypes { get; set; }
    }
}
