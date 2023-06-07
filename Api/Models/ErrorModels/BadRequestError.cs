namespace Api.Models.ErrorModels;

public class BadRequestError : Exception
{
    public BadRequestError(string message)
        : base(message)
    {
    }
}