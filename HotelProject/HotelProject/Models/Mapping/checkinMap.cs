using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HotelProject.Models.Mapping
{
    public class checkinMap : EntityTypeConfiguration<checkin>
    {
        public checkinMap()
        {
            // Primary Key
            this.HasKey(t => t.checkin_Id);

            // Properties
            this.Property(t => t.checkin_Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("checkin");
            this.Property(t => t.checkin_Id).HasColumnName("checkin_Id");
            this.Property(t => t.cliente_id).HasColumnName("cliente_id");
            this.Property(t => t.funcionario_Id).HasColumnName("funcionario_Id");
            this.Property(t => t.Data).HasColumnName("Data");
            this.Property(t => t.Previsao).HasColumnName("Previsao");
            this.Property(t => t.Saida).HasColumnName("Saida");
            this.Property(t => t.Valor).HasColumnName("Valor");

            // Relationships
            this.HasMany(t => t.quartos)
                .WithMany(t => t.checkins)
                .Map(m =>
                    {
                        m.ToTable("quartoCheckins");
                        m.MapLeftKey("checkin_Id");
                        m.MapRightKey("quarto_Id");
                    });

            this.HasOptional(t => t.cliente)
                .WithMany(t => t.checkins)
                .HasForeignKey(d => d.cliente_id);
            this.HasOptional(t => t.funcionario)
                .WithMany(t => t.checkins)
                .HasForeignKey(d => d.funcionario_Id);

        }
    }
}
