namespace Example.Api.Models.Person;

public class CreatePersonResponse : IApiResponse
{
    public required Guid Id { get; set; }
}