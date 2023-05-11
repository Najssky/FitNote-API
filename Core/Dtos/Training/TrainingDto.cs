using System;

namespace FitNote_API.Core.Dtos.Training
{
    public class TrainingDto
    {
        public Guid Training_id { get; set; }
        public string Training_details { get; set; }
        public Guid Training_user_id { get; set; }
        public DateTime Training_date { get; set; }

    }
}
