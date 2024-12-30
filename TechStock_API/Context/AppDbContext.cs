using Microsoft.EntityFrameworkCore;
using TechStock_API.Domain;

namespace TechStock_API.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; } //mapeia a entidade para a tabela a ser criada - Produtos
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>()
                .Property(p => p.ValorUnitario)
                .HasColumnType("decimal(10,3)");
        }
    }
}
