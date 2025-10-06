namespace ExampleApi.Core.Dtos.Person;

public class CreatePerson
{
    public required string FirstName { get; set; } 
    public required string LastName { get; set; } 
    public required string Address { get; set; } 
}