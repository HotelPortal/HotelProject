using System;
using System.Collections.Generic;

namespace HotelProject.Models
{
    public partial class checkin
    {
        public checkin()
        {
            this.quartos = new List<quarto>();
        }

        public long checkin_Id { get; set; }
        public Nullable<long> cliente_id { get; set; }
        public Nullable<long> funcionario_Id { get; set; }
        public System.DateTime Data { get; set; }
        public int Previsao { get; set; }
        public System.DateTime Saida { get; set; }
        public float Valor { get; set; }
        public virtual cliente cliente { get; set; }
        public virtual funcionario funcionario { get; set; }
        public virtual ICollection<quarto> quartos { get; set; }
    }
}
