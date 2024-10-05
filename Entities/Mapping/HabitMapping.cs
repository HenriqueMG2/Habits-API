using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Mapping
{
    public class HabitsMapping : IEntityTypeConfiguration<Habit>
    {
        public void Configure(EntityTypeBuilder<Habit> entity)
        {
            // Nome da tabela
            entity.ToTable("Habits", "dbo");

            // Chave primária
            entity.HasKey(e => e.HabitId);

            // Propriedades
            entity.Property(e => e.HabitId)
                  .HasColumnName("HabitId")
                  .ValueGeneratedOnAdd();

            entity.Property(e => e.Description)
                  .HasMaxLength(250) // Defina um tamanho máximo para a descrição
                  .IsUnicode(false)
                  .IsRequired(); // Descrição é obrigatória

            entity.Property(e => e.Count)
                  .IsRequired(); // Count é obrigatório
        }
    }
}
