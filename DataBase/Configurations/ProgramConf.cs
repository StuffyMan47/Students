using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Students.DataBase.Domain;

namespace Students.DataBase.Configurations;

public class ProgramConf : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder.HasKey(x => x. Id);
        builder.HasIndex(x => x.Id).IsUnique();

        builder.HasOne(x => x.Class).WithMany(x => x.Programs);
    }
}
