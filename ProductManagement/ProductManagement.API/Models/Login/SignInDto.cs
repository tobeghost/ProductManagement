namespace ProductManagement.API.Models.Login
{
    public class SignInDto
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
        public int ExpiryInMinutes { get; set; }
    }
}
