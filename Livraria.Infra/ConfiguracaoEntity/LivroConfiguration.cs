using Livraria.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Livraria.Infra.ConfiguracaoEntity
{
    public class LivroConfiguration : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome).HasMaxLength(150).IsRequired();
            builder.Property(c => c.Autor).HasMaxLength(70);
            builder.Property(c => c.Editora).HasMaxLength(70);
            builder.Property(c => c.Quantidade).IsRequired();
        }
    }
}
