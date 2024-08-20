using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Students.DataBase.Domain;

namespace Students.DataBase.Configurations;

public class ClassConf : IEntityTypeConfiguration<Class>
{
    public void Configure(EntityTypeBuilder<Class> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.Students).WithOne(x => x.Class);

        builder.HasIndex(x => x.Id).IsUnique();
    }
}
