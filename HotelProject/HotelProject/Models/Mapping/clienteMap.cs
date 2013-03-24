using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HotelProject.Models.Mapping
{
    public class clienteMap : EntityTypeConfiguration<cliente>
    {
        public clienteMap()
        {
            // Primary Key
            this.HasKey(t => t.cliente_id);

            // Properties
            // Table & Column Mappings
            this.ToTable("cliente");
            this.Property(t => t.cliente_id).HasColumnName("cliente_id");
            this.Property(t => t.cidade_id).HasColumnName("cidade_id");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(t => t.Telefone).HasColumnName("Telefone");
            this.Property(t => t.Cpf).HasColumnName("Cpf");
            this.Property(t => t.Rg).HasColumnName("Rg");
            this.Property(t => t.DtRegistro).HasColumnName("DtRegistro");
            this.Property(t => t.DtNascimento).HasColumnName("DtNascimento");
            this.Property(t => t.Sexo).HasColumnName("Sexo");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Endereco).HasColumnName("Endereco");
            this.Property(t => t.Bairro).HasColumnName("Bairro");

            // Relationships
            this.HasOptional(t => t.cidade)
                .WithMany(t => t.clientes)
                .HasForeignKey(d => d.cidade_id);

        }
    }
}
