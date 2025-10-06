using System.ComponentModel.DataAnnotations;
using ExampleApi.Core.Dtos.Person;
using ExampleApi.Core.Entities;

namespace Example.Api.Models.Person;

public class CreatePersonRequest
{
    [Required]
    [MaxLength(PersonConfig.NAME_MAX_LENGTH)]
    public required string Firstname { get; set; }
    [Required]
    [MaxLength(PersonConfig.NAME_MAX_LENGTH)]
    public required string Lastname { get; set; }
    [Required]
    [MaxLength(PersonConfig.ADDRESS_MAX_LENGTH)]
    public required string Address { get; set; }
    public required DateTime BirthDate { get; set; }

    public CreatePerson ToDto()
    {
        return new()
        {
            Firstname = Firstname,
            Lastname = Lastname,
            Address = Address,
            BirthDate = BirthDate,
        };
    }
}