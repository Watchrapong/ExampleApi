
namespace ExampleApi.Core.Exceptions;

/// <summary>
/// Represents an exception that occurs when a requested resource is not found.
/// </summary>
public class NotFoundException : ServiceException
{
    public NotFoundException(string key, string value) : base("not_found", $"{key} \'{value}\' not found")
    {
    }
}
