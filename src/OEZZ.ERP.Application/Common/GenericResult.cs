using System.Net;
using OEZZ.ERP.Application.Base;

namespace OEZZ.ERP.Application.Common;

public static class GenericResult
{
    public static IResult<T> Ok<T>(this T data, string message = "OK", int code = (int)HttpStatusCode.OK) => new Result<T>(message, code, data);
    public static IResult Ok(string message = "OK", int code = (int)HttpStatusCode.OK) => new Result(message, code);
    public static IResult Bad(string message, int code = (int)HttpStatusCode.BadRequest) => new Result(message, code, new[] { message });
    public static IResult<T> Bad<T>(string message, int code = (int)HttpStatusCode.BadRequest, T? data = default) => new Result<T>(message, code, data, new[] { message });
}

public static class ResultExtensions
{
    public static IResult<T> To<T>(this IResult result) => new Result<T>(result.Message, result.Code, errors: result.Errors);
}