namespace DML.Application.BaseResponse;

public class Response
{
    public bool IsSuccess { get; set; } = true;

    public Guid Id { get; set; } = Guid.Empty;
}
