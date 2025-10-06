using ExampleApi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExampleApi.Data.Configurations;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Firstname)
               .HasMaxLength(PersonConfig.NAME_MAX_LENGTH);
        builder.Property(p => p.Lastname)
               .HasMaxLength(PersonConfig.NAME_MAX_LENGTH);

        builder.Property(p => p.Address)
               .HasMaxLength(PersonConfig.ADDRESS_MAX_LENGTH);

        // Seed mock data
        builder.HasData(
            new Person
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Firstname = "John",
                Lastname = "Doe",
                Address = "123 Main Street, Bangkok",
                BirthDate = new DateTime(1990, 5, 20),
                Created = DateTime.UtcNow
            },
            new Person
            {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                Firstname = "Jane",
                Lastname = "Smith",
                Address = "456 Second Avenue, Chiang Mai",
                BirthDate = new DateTime(1985, 11, 2),
                Created = DateTime.UtcNow
            },
            new Person
            {
                Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                Firstname = "Somchai",
                Lastname = "Prasert",
                Address = "789 Sukhumvit Road, Bangkok",
                BirthDate = new DateTime(2000, 1, 15),
                Created = DateTime.UtcNow
            }
        );
    }
}
