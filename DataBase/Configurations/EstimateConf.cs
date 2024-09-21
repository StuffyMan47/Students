using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Students.DataBase.Domain;

namespace Students.DataBase.Configurations;

public class EstimateConf : IEntityTypeConfiguration<Estimate>
{
    public void Configure(EntityTypeBuilder<Estimate> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Id).IsUnique();

        builder.HasOne(x => x.Student).WithMany(x => x.Estimates);
        builder.HasOne(x => x.EdProgramm).WithMany(x=>x.Estimates);
    }
}
