using ApiDdd.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ApiDdd.Infra.Data.Mapping;

namespace ApiDdd.Infra.Data.Context
{
    public class ApiDddContext: DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ApiDddDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(new UserMap().Configure);

            modelBuilder.Entity<Product>(new ProductMap().Configure);
        }
    }
}
