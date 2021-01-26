namespace APPSIIF.Models.Api
{
    public class LoginRequest
    {
        public string NickName { get; set; }
        public string Password { get; set; }
        public string RegisterCode { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string IpAdress { get; set; }
        public string TypeIncome { get; set; }
    }
}
