namespace APPSIIF.Models.Api
{
    class ChangePasswordRequest
    {
        public string NickName { get; set; }
        public string Code { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
