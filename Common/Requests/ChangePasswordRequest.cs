using System;

namespace FitNote_API.Common.Requests
{
    public class ChangePasswordRequest
    {
        public string NewPassword { get; set; }
        public Guid Token { get; set; }
    }
}
