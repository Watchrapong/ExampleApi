using ExampleApi.Core;
using ExampleApi.Core.Dtos.Person;
using ExampleApi.Core.Entities;
using ExampleApi.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace ExampleApi.Services;

public class PersonService : IPersonService
{
    private readonly IRepository<Person> _personRepository;

    public PersonService(IRepository<Person> personRepository)
    {
        _personRepository = personRepository;
    }
    public async Task<Pagination<GetPersonList>> GetPersonListAsync(GetPersonListQuery pq, CancellationToken cancellationToken = default)
    {
        var query = _personRepository.Table;

        var personPage = await query
            .ToPaginationAsync(pq, p => new GetPersonList()
            {
                Id = p.Id,
                Firstname = p.Firstname,
                Lastname = p.Lastname,
                Address = p.Address,
                BirthDate = p.BirthDate
            }, cancellationToken: cancellationToken);

        return personPage;
    }
    
    public async Task<Guid> CreatePersonAsync(CreatePerson request, CancellationToken cancellationToken = default)
    {
        request.Validate();

        var person =  new Person()
        {
            Firstname = request.Firstname,
            Lastname = request.Lastname,
            Address = request.Address,
            BirthDate = request.BirthDate,
        };

        _personRepository.Insert(person);
       
        await _personRepository.CommitAsync(cancellationToken);
        
        return person.Id;
    }
}