public class Result<T>
{
    public T Data { get; set; }
    public ErrorResponseDto Error { get; set; }
    public bool IsSuccess => Error == null;

    public static Result<T> Success(T data)
    {
        return new Result<T> { Data = data };
    }

    public static Result<T> Failure(ErrorResponseDto error)
    {
        return new Result<T> { Error = error };
    }
}
