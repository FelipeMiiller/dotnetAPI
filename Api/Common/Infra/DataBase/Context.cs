
using Microsoft.EntityFrameworkCore;
using Api.Modules.UserModule.Domain.Entities;
using Api.Modules.TaskModule.Domain.Entities;

namespace Api.Common.Infra.DataBase
{
    public class Context : DbContext
    {

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<TaskEntity> Tasks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=../DataBase/LocalDatabase.db");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<User>().Property(x => x.Name);
            modelBuilder.Entity<User>().Property(x => x.Email).IsRequired();
            modelBuilder.Entity<User>().HasMany(e => e.Tasks).WithOne(e => e.User).HasForeignKey(e => e.UserId).IsRequired();

            modelBuilder.Entity<TaskEntity>().HasKey(x => x.Id);
            modelBuilder.Entity<TaskEntity>().Property(x => x.Title).IsRequired();
            modelBuilder.Entity<TaskEntity>().Property(x => x.Description).IsRequired();
            modelBuilder.Entity<TaskEntity>().Property(x => x.UserId).IsRequired();


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

                if (entry.Entity is TaskEntity taskEntity)
                {
                    taskEntity.UpdateAt = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }
    }
}