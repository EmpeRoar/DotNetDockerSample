using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VSDocker.Model;

namespace VSDocker.EFCore
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {

        }

        private string DefaultSchema = "VSDocker";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=192.168.1.8\\xxx;Database=DockerExercise;Trusted_Connection=True;User Id=xxx; Password=xxx; MultipleActiveResultSets =true");

        }

        
        public virtual DbSet<Company> Companies { get; set; }


        public DatabaseFacade Database()
        {
            return base.Database;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(e =>
            {
                e.ToTable("Company", DefaultSchema);
                e.HasKey(x => x.Id);
                e.Property(x => x.Name).HasColumnName("Name");
                e.Property(x => x.IsSoftDelete).HasDefaultValue(true);
            });
           //base.OnModelCreating(modelBuilder);

        }
    }
}
