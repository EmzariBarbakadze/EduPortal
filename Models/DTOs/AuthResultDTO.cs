namespace EduPortal.Models.DTOs
{
    public class AuthResultDTO
    {
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }

        public DateTime RefreshTokenExpireDate { get; set; }
    }
}
