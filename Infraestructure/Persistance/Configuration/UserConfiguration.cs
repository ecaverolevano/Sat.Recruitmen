using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sat.Recruitment.Domain.Entities;

namespace Sat.Recruitment.Infraestructure.Persistance.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(t => t.Name).IsRequired();
        builder.Property(t => t.Email).IsRequired();
        builder.Property(t => t.Address).IsRequired();
        builder.Property(t => t.Phone).IsRequired();
 
    }
}
