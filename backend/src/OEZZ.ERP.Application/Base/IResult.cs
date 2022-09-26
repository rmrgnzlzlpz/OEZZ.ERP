namespace OEZZ.ERP.Application.Base;

public interface IResult
{
    public int Code { get; }
    public bool Success { get; }
    public string Message { get; }
    public IEnumerable<string>? Errors { get; }
}

public interface IResult<T> : IResult
{
    public T? Data { get; set; }
}