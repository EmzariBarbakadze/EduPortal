using System.ComponentModel.DataAnnotations;

namespace EduPortal.Models.Entities
{
    public class ExceptionLogs
    {
        [Key]
        public int LogId { get; set; }

        public int UserId { get; set; }

        public int Code { get; set; }

        public string Description { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public string IpAdress { get; set; }

        // ---------------------------------------------------

        public Inf_ErrorCodes Inf_ErrorCodes { get; set; }

        public Users Users { get; set; }
    }
}
