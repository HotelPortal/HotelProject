using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using HotelProject.Models.Mapping;

namespace HotelProject.Models
{
    public partial class HotelDBContext : DbContext
    {
        static HotelDBContext()
        {
            Database.SetInitializer<HotelDBContext>(null);
            
        }

        public HotelDBContext()
            : base("Name=HotelDBContext")
        {
            IsDisposed = false;
        }

        public DbSet<checkin> checkins { get; set; }
        public DbSet<cidade> cidades { get; set; }
        public DbSet<cliente> clientes { get; set; }
        public DbSet<funcionario> funcionarios { get; set; }
        public DbSet<quarto> quartos { get; set; }
        public DbSet<status_quarto> status_quarto { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new checkinMap());
            modelBuilder.Configurations.Add(new cidadeMap());
            modelBuilder.Configurations.Add(new clienteMap());
            modelBuilder.Configurations.Add(new funcionarioMap());
            modelBuilder.Configurations.Add(new quartoMap());
            modelBuilder.Configurations.Add(new status_quartoMap());
        }

        public bool IsDisposed { get; private set; }
        protected override void Dispose(bool disposing)
        {
            IsDisposed = true;
        }
    }
}
