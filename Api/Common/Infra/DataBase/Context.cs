
using Microsoft.EntityFrameworkCore;
using Api.Modules.UserModule.Domain.Entities;


namespace Api.Common.Infra.DataBase
{
    public class Context : DbContext
    {

        public DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=../DataBase/LocalDatabase.db");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<User>().Property(x => x.Name);
            modelBuilder.Entity<User>().Property(x => x.Email).IsRequired();
            
        }

       

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);
            foreach (var entry in entries)
            {
                if (entry.Entity is User user)
                {
                    user.UpdateAt = DateTime.Now;

                    
                }
            }
            return base.SaveChanges();
        }
    }
}