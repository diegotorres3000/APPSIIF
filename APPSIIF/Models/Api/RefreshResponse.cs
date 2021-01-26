using System;
using System.Collections.Generic;
using System.Text;

namespace APPSIIF.Models.Api
{
    class RefreshResponse
    {

        public string Code { get; set; }
        public string JwtToken { get; set; }
        public string RefreshToken { get; set; }

        public RefreshResponse(string Code, string JwtToken, string RefreshToken)
        {
            this.Code = Code;
            this.JwtToken = JwtToken;
            this.RefreshToken = RefreshToken;
        }
    }
}
