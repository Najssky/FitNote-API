﻿using System.ComponentModel.DataAnnotations;

namespace FitNote_API.Common.Requests.Authentication
{
    public class LoginRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
