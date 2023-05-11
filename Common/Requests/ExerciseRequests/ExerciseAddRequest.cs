using System;
using System.ComponentModel.DataAnnotations;

namespace FitNote_API.Common.Requests.ExerciseRequests
{
    public class ExerciseAddRequest
    {
        [Required]
        public string Exercise_name { get; set; }
    }
}
