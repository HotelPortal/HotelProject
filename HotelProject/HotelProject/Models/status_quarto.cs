using System;
using System.Collections.Generic;

namespace HotelProject.Models
{
    public partial class status_quarto
    {
        public status_quarto()
        {
            this.quartos = new List<quarto>();
        }

        public long status_Id { get; set; }
        public string Descridao { get; set; }
        public bool FlAlugavel { get; set; }
        public virtual ICollection<quarto> quartos { get; set; }
    }
}
