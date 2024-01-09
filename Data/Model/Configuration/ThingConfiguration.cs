using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DateTimeCheck.Data.Model.Configuration;

public class ThingConfiguration : IEntityTypeConfiguration<Thing>
{
    public void Configure(EntityTypeBuilder<Thing> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.When).IsRequired(false);
    }
}