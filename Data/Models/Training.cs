﻿using System;
using System.ComponentModel.DataAnnotations;

namespace FitNote_API.Data.Models
{
    public class Training
    {
        [Key]
        public Guid Training_id { get; set; }
        public string Training_details { get; set; }

        public  Guid Training_user_id { get; set; }
        public DateTime Training_date { get; set; }

    }
}
