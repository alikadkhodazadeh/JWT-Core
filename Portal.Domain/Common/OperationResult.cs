public class OperationResult
{
    public bool Succeeded { get; protected init; }
    public bool Failure => !Succeeded;
    public string Message { get; protected init; }

    public static OperationResult Success()
        => new OperationResult() { Succeeded = true, Message = "The operation successfully." };
    public static OperationResult Success(string message)
        => new OperationResult() { Succeeded = true, Message = message };
    public static OperationResult Fail()
        => new OperationResult() { Succeeded = false, Message = "The operation failed." };
    public static OperationResult Fail(string message)
        => new OperationResult() { Succeeded = false, Message = message };
}

public class OperationResult<TData> : OperationResult
{
    public TData? Data { get; private init; }
    public static OperationResult<TData> Success(TData data)
        => new OperationResult<TData>() { Succeeded = true, Data = data, Message = "The operation successfully." };
    public static OperationResult<TData> Success(TData data, string message)
        => new OperationResult<TData>() { Succeeded = true, Data = data, Message = message };
    public static OperationResult<TData> Fail(TData data)
        => new OperationResult<TData>() { Succeeded = false, Data = data, Message = "The operation failed." };
    public static OperationResult<TData> Fail(TData data, string message)
        => new OperationResult<TData>() { Succeeded = false, Data = data, Message = message };
}