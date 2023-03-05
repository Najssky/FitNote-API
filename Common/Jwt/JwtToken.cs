namespace FitNote_API.Common.Jwt
{
    public class JwtToken
    {
        private string refreshToken;

        public string AccessToken { get; set; }

        public string RefreshToken { get => refreshToken; set => refreshToken = value; }
    }
}
