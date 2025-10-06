namespace ExampleApi.Core.Entities;

public class Person : IIdEntity, ITimeEntity, ISoftDeleteEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public required string Firstname { get; set; } = string.Empty;
    public required string Lastname { get; set; } = string.Empty;
    public required string Address { get; set; } = string.Empty;
    
    public required DateTime BirthDate { get; set; }
    
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }
    public DateTime? Deleted { get; set; }
}

public class PersonConfig
{
    public const int NAME_MAX_LENGTH = 255;
    public const int ADDRESS_MAX_LENGTH = 255;
}