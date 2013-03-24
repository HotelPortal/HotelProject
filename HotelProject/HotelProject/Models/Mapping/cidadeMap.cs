using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HotelProject.Models.Mapping
{
    public class cidadeMap : EntityTypeConfiguration<cidade>
    {
        public cidadeMap()
        {
            // Primary Key
            this.HasKey(t => t.cidade_id);

            // Properties
            this.Property(t => t.Descricao)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("cidade");
            this.Property(t => t.cidade_id).HasColumnName("cidade_id");
            this.Property(t => t.Descricao).HasColumnName("Descricao");
            this.Property(t => t.Estado).HasColumnName("Estado");
        }
    }
}
