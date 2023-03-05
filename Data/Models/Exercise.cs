using System;
using System.ComponentModel.DataAnnotations;

namespace FitNote_API.Data.Models
{
    public class Exercise
    {
        [Key]
        public Guid Exercise_id { get; set; }
        public string Exercise_name { get; set; }
    }
}
