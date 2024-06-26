﻿namespace FitNote_API.Api.Responses.Wrappers
{
    public class ApiErrorResponse : ApiResponse
    {
        public string Message { get; set; }

        public ApiErrorResponse(string message) : base(false)
        {
            Message = message;
        }
    }
}
