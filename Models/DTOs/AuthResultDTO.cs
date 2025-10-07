namespace EduPortal.Models.DTOs
{
    public class AuthResultDTO
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ExpiresAt { get; set; }
        public string Username { get; set; }
    }
}
