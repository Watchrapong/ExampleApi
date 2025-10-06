using ExampleApi.Core.Exceptions;

namespace ExampleApi.Core.Dtos.Person;


public class CreatePerson
{
    public required string Firstname { get; set; } 
    public required string Lastname { get; set; } 
    public required string Address { get; set; }
    public required DateTime BirthDate { get; set; }
    
    public void Validate()
    {
        Firstname = Firstname.Trim();
        Lastname = Lastname.Trim();
        Address = Address.Trim();
    
        if (string.IsNullOrWhiteSpace(Firstname))
        {
            throw new ServiceException("name_is_required", "Firstname is required");
        }
    }
    
}