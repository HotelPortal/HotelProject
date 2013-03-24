using System;
using System.Collections.Generic;

namespace HotelProject.Models
{
    public partial class quarto
    {
        public quarto()
        {
            this.checkins = new List<checkin>();
        }

        public long quarto_Id { get; set; }
        public Nullable<long> status_Id { get; set; }
        public string Numero { get; set; }
        public string Descricao { get; set; }
        public float ValorDia { get; set; }
        public virtual status_quarto status_quarto { get; set; }
        public virtual ICollection<checkin> checkins { get; set; }
    }
}
