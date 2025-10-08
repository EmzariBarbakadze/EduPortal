using System.ComponentModel.DataAnnotations;

namespace EduPortal.Models.Entities
{
    public class EmailVerification
    {
        [Key]
        public int Id { get; set; }

        public string Email { get; set; }

        [MinLength(5), MaxLength(5)]
        public int Code { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public DateTime ExpirationDate { get; set; }

        public bool IsUsed { get; set; } = false;

        // ---------------------------------------------------------

        public Users Users { get; set; }
    }
}
