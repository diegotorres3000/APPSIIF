using System;
namespace APPSIIF.Models.Api
{
    public class RegisterRequest
    {
        public string NickName { get; set; }
        public string VerificationCode { get; set; }
        public string DeviceName { get; set; }
        public string DeviceSerial { get; set; }
        public string DeviceBrand { get; set; }
        public string DeviceModel { get; set; }
        public string DeviceOperatingSystem { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string TypeIncome { get; set; }
    }
}
