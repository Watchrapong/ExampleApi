using ExampleApi.Core.Dtos.Person;

namespace ExampleApi.Core.Services;

public interface IPersonService
{
    Task<Pagination<GetPersonList>> GetPersonListAsync(GetPersonListQuery pq, CancellationToken cancellationToken = default);
    Task<Guid> CreatePersonAsync(CreatePerson request, CancellationToken cancellationToken = default);
}