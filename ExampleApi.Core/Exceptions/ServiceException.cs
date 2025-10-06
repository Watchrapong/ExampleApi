
namespace ExampleApi.Core.Exceptions;

/// <summary>
/// Represents an exception that occurs in the service layer.
/// </summary>
public class ServiceException : Exception
{
    /// <summary>
    /// The error code of the exception
    /// </summary>
    /// <example>ERR001</example>
    public string Code { get; }

    public ServiceException(string code, string message) : base(message)
    {
        Code = code;
    }
}
