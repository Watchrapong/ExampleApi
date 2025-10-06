namespace ExampleApi.Core.Dtos.Person;

public class GetPersonList
{
    public required Guid Id { get; set; }
    public required string Firstname { get; set; }
    public required string Lastname { get; set; }
    public required string Address { get; set; }
    public required DateTime BirthDate { get; set; }
}

public class GetPersonListQuery : IPageQuery<Entities.Person>
{
    public required string? Name { get; set; } = string.Empty;
    public required string? Address { get; set; } = string.Empty;
    public override IQueryable<Entities.Person> ApplyToQuery(IQueryable<Entities.Person> query)
    {
        if (!string.IsNullOrEmpty(Name))
        {
            query = query.Where(x => (x.Firstname + " " + x.Lastname).Contains(Name));
        }
        if (!string.IsNullOrEmpty(Address))
        {
            query = query.Where(x => x.Address.Contains(Address));
        }
        return query;
    }
}