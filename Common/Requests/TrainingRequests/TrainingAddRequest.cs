using System;
using System.ComponentModel.DataAnnotations;

namespace FitNote_API.Common.Requests.TrainingRequests
{
    public class TrainingAddRequest
    {
        [Required]
        public string Training_details { get; set; }
        [Required]
        public Guid Training_user_id { get; set; }
        [Required]
        public DateTime Training_date { get; set; }

    }
}
