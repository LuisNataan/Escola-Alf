using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Escola.Alf.Application
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions dbContext) : base(dbContext)
        {
        }

        public DbSet<ProfessorModel> Professores { get; set; }

        public MainContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.GetForeignKeys()
                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                    .ToList().ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
                entityType.GetProperties().Where(c => c.ClrType == typeof(string)).ToList()
                    .ForEach(p => p.SetIsUnicode(false));
            }
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MainContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer("DefaultConnection");
            }
        }
    }
}
