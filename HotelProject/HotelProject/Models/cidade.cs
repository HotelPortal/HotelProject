using System;
using System.Collections.Generic;

namespace HotelProject.Models
{
    public partial class cidade
    {
        public cidade()
        {
            this.clientes = new List<cliente>();
            this.funcionarios = new List<funcionario>();
        }

        public long cidade_id { get; set; }
        public string Descricao { get; set; }
        public string Estado { get; set; }
        public virtual ICollection<cliente> clientes { get; set; }
        public virtual ICollection<funcionario> funcionarios { get; set; }
    }
}
