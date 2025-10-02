using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace EduPortal.Models.Entities
{
    public class UserTokens
    {
        [Key]
        public int TokenId { get; set; }

        public int UserId { get; set; }

        [NotNull, Required]
        public string RefreshToken { get; set; }

        public int JwtId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ExpiresAt { get; set; }

        public DateTime? RevokedAt { get; set; }

        public string? IpAdress { get; set; }

        public string? DeviceInfo { get; set; }

        public int? SessionId { get; set; }

        // ---------------------------------------------

        public UsersSessions UsersSessions { get; set; }

        public Users Users { get; set; }
    }
}
