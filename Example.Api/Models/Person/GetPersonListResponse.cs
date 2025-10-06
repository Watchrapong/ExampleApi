using ExampleApi.Core;
using ExampleApi.Core.Dtos.Person;

namespace Example.Api.Models.Person;

public class GetPersonListResponse : IApiResponse
{
    public required Guid Id { get; set; }
    public required string Firstname { get; set; }
    public required string Lastname { get; set; }
    public required string Address { get; set; }
    public required DateTime? BirthDate { get; set; }
    public int Age { get; set; }

    public static PageResponse<GetPersonListResponse> FromDto(Pagination<GetPersonList> page)
    {
        return page.ToPageResponse(x =>
        {
            var utcNow = DateTime.UtcNow;

            var age = utcNow.Year - x.BirthDate.Year;

            if (utcNow.Month < x.BirthDate.Month || 
                (utcNow.Month == x.BirthDate.Month && utcNow.Day < x.BirthDate.Day))
            {
                age--;
            }

            return new GetPersonListResponse
            {
                Id = x.Id,
                Firstname = x.Firstname,
                Lastname = x.Lastname,
                Address = x.Address,
                BirthDate = x.BirthDate,
                Age = age
            };
        });
    }
}