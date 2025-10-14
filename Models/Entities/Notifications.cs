using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [ForeignKey("UserId")]
        public Users User { get; set; }

        [ForeignKey("NotificationTypeId")]
        public Inf_NotificationTypes NotificationType { get; set; }
    }
}
