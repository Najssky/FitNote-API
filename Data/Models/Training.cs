using System;
using System.ComponentModel.DataAnnotations;

namespace FitNote_API.Data.Models
{
    public class Training
    {
        [Key]
        public Guid Id { get; set; }
        public string Exercise_name { get; set; }
        public int Exercise_reps { get; set; }

        public  Guid Training_user_id { get; set; }
        public DateTime Training_date { get; set; }

    }
}
