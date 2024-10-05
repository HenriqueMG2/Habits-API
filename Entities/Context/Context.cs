using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities.Context
{
    public class Context(DbContextOptions<Context> options) : DbContext(options)
    {
                // DbSets
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Habit> Habit { get; set; }

        // Configurações de mapeamento
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Adicionar os mapeamentos
            modelBuilder.ApplyConfiguration(new Mapping.UserMapping());
            modelBuilder.ApplyConfiguration(new Mapping.HabitsMapping());
        }
    }
}