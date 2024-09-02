using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Students.DataBase.Domain;

namespace Students.DataBase.Configurations;

public class ProgramConf : IEntityTypeConfiguration<EdProgram>
{
    public void Configure(EntityTypeBuilder<EdProgram> builder)
    {
        builder.HasKey(x => x. Id);
        builder.HasIndex(x => x.Id).IsUnique();

        builder.HasOne(x => x.Class).WithMany(x => x.Programs);
    }
}
