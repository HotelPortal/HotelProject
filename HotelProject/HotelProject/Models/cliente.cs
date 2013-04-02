using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelProject.Models
{
    public partial class cliente
    {
        public cliente()
        {
            this.checkins = new List<checkin>();
        }

        public long cliente_id { get; set; }
        public Nullable<long> cidade_id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public System.DateTime DtRegistro { get; set; }
       [DataType(DataType.Date)]
        public System.DateTime DtNascimento { get; set; }
        public string Sexo { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public virtual ICollection<checkin> checkins { get; set; }
        public virtual cidade cidade { get; set; }
    }
}
