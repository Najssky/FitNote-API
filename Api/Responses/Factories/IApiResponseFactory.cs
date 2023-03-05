using FitNote_API.Api.Responses.Wrappers;

namespace FitNote_API.Api.Responses.Factories
{
    public interface IApiResponseFactory
    {
        public ApiSuccessResponse<T> Success<T>(T data) => new ApiSuccessResponse<T>(true, data);
    }
}
