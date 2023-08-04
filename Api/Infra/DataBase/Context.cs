

namespace Api.Common.Infra.DataBase
{
    public class Context:DbContext
    {
    
    public DbSet<User> Users { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite( "Data Source=../DataBase/LocalDatabase.db");
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(x => x.id);
        modelBuilder.Entity<User>().Property(x => x.nome).IsRequired();
        modelBuilder.Entity<User>().Property(x => x.email).IsRequired();
        modelBuilder.Entity<User>().Property(x => x.password).IsRequired();

    }
    }
}