using Microsoft.EntityFrameworkCore;
using WebApi.Domain.Models;
using WebApi.Infra.Data.Mappings;

namespace Equinox.Infra.Data.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Operadora> Operadora { get; set; }
        public DbSet<Plano> Plano { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new OperadoraMap());
            modelBuilder.ApplyConfiguration(new PlanoMap());

            modelBuilder.Entity<Operadora>()
                .HasMany(o => o.Planos)
                .WithOne(p => p.Operadora)
                .IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
