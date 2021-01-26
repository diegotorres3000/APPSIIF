using System;
namespace APPSIIF.Models.Api
{
    public class LoginResponse
    {
        public string Code { get; set; }
        public string UserName { get; set; }
        public bool ItsPasswordChange { get; set; }
        public string JwtToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
