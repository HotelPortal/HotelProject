using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HotelProject.Models.Mapping
{
    public class status_quartoMap : EntityTypeConfiguration<status_quarto>
    {
        public status_quartoMap()
        {
            // Primary Key
            this.HasKey(t => t.status_Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("status_quarto");
            this.Property(t => t.status_Id).HasColumnName("status_Id");
            this.Property(t => t.Descridao).HasColumnName("Descridao");
            this.Property(t => t.FlAlugavel).HasColumnName("FlAlugavel");
        }
    }
}
