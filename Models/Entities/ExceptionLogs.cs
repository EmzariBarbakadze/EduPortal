using System.ComponentModel.DataAnnotations;

namespace EduPortal.Models.Entities
{
    public class ExceptionLogs
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Code { get; set; } = "N/A";

        [MaxLength(200)]
        public string Message { get; set; } = string.Empty;

        public string? Details { get; set; }  

        public string? StackTrace { get; set; }

        public string? Source { get; set; }  // Service name or component

        public string? Layer { get; set; }   // e.g. "Service", "Repository", "Controller"

        public string? Method { get; set; }  // Name of the method where error occurred

        public string? Path { get; set; }    // Request path if from API

        // User & environment
        public string? UserId { get; set; }
        public string? IpAddress { get; set; }
        public string? DeviceInfo { get; set; }

        public DateTime Created { get; set; } = DateTime.UtcNow;

        // ---------------------------------------------------

        public Inf_ErrorCodes Inf_ErrorCodes { get; set; }

        public Users Users { get; set; }
    }
}
