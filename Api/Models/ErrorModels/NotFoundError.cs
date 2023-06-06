namespace Api.Models.ErrorModels;

public class NotFoundError : Exception
{
    public NotFoundError(string message)
        : base(message)
    {
    }
}