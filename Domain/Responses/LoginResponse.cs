namespace Domain.Core.Responses
{
    public class LoginResponse : ResponseBase
    {
        public string AccessToken { get; set; } 
        public string RefreshToken { get; set; }
    }
}
