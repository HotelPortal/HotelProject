using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HotelProject.Models.Mapping
{
    public class funcionarioMap : EntityTypeConfiguration<funcionario>
    {
        public funcionarioMap()
        {
            // Primary Key
            this.HasKey(t => t.funcionario_Id);

            // Properties
            this.Property(t => t.funcionario_Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Descricao)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("funcionario");
            this.Property(t => t.funcionario_Id).HasColumnName("funcionario_Id");
            this.Property(t => t.Descricao).HasColumnName("Descricao");
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
            this.Property(t => t.Login).HasColumnName("Login");
            this.Property(t => t.Senha).HasColumnName("Senha");

            // Relationships
            this.HasOptional(t => t.cidade)
                .WithMany(t => t.funcionarios)
                .HasForeignKey(d => d.cidade_id);

        }
    }
}
