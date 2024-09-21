using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Students.DataBase.Domain;

namespace Students.DataBase.Configurations;

public class StudentConf : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Class).WithMany(x => x.Students);
        builder.HasMany(x => x.Estimates).WithOne(x => x.Student);
        builder.HasOne(x => x.EdProgram).WithMany(x => x.Students);

        builder.HasIndex(x => x.Id).IsUnique();
    }
}
