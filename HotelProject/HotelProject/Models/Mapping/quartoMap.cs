using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HotelProject.Models.Mapping
{
    public class quartoMap : EntityTypeConfiguration<quarto>
    {
        public quartoMap()
        {
            // Primary Key
            this.HasKey(t => t.quarto_Id);

            // Properties
            this.Property(t => t.quarto_Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("quarto");
            this.Property(t => t.quarto_Id).HasColumnName("quarto_Id");
            this.Property(t => t.status_Id).HasColumnName("status_Id");
            this.Property(t => t.Numero).HasColumnName("Numero");
            this.Property(t => t.Descricao).HasColumnName("Descricao");
            this.Property(t => t.ValorDia).HasColumnName("ValorDia");

            // Relationships
            this.HasOptional(t => t.status_quarto)
                .WithMany(t => t.quartos)
                .HasForeignKey(d => d.status_Id);

        }
    }
}
