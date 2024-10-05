using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            // Nome da tabela
            entity.ToTable("Users", "dbo");

            // Chave primária
            entity.HasKey(e => e.UserId);

            // Propriedades
            entity.Property(e => e.UserId).HasColumnName("UserId").ValueGeneratedOnAdd();

            entity.Property(e => e.Name).HasMaxLength(150).IsUnicode(false).IsRequired(); // Nome é obrigatório

            entity.Property(e => e.Email).HasMaxLength(150).IsUnicode(false).IsRequired(); // Email é obrigatório

            entity.Property(e => e.Password).HasMaxLength(100).IsUnicode(false).IsRequired(); // Senha é obrigatória

            entity.Property(e => e.CreateAt)
                  .HasColumnType("datetime")
                  .HasDefaultValueSql("GETDATE()") // Valor padrão na criação
                  .IsRequired();
        }
    }
}
