using System;
using System.ComponentModel.DataAnnotations;

namespace FitNote_API.Data.Models
{
    public class User
    {
        [Key]
        public Guid User_id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public string? Phone_number { get; set; }
        public Guid Token { get; set; }
    }
}
