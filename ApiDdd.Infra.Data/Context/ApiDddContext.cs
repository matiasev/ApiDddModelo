using ApiDdd.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ApiDdd.Infra.Data.Mapping;

namespace ApiDdd.Infra.Data.Context
{
    public class ApiDddContext: DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Produto> Produto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=(localdb);Database=apiddd;Uid=root;Pwd=00000000;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(new UsuarioMap().Configure);

            modelBuilder.Entity<Produto>(new ProdutoMap().Configure);
        }
    }
}
