using FitNote_API.Api.Responses.Wrappers;

namespace FitNote_API.Api.Responses.Factories
{
    public class ApiResponseFactory : IApiResponseFactory
    {
        public ApiSuccessResponse<T> Success<T>(T data) => new ApiSuccessResponse<T>(true, data);

        public ApiErrorResponse Error(string errorMessage) => new ApiErrorResponse(errorMessage);
    }
}
