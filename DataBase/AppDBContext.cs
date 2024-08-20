using Microsoft.EntityFrameworkCore;
using Students.DataBase.Domain;

namespace Students.DataBase;

public class AppDBContext : DbContext
{
    public DbSet<Class> Classes { get; set; } = null!;
    public DbSet<Estimate> Estimates { get; set; } = null!;
    public DbSet<Student> Students { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder modelBuilder)
    {
        //тут надо указать свой путь к mdf файлу
        modelBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\repos\Students\DataBase\Student.mdf;Integrated Security=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Применение всех конфигов
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
