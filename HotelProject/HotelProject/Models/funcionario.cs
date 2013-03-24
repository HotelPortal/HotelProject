using System;
using System.Collections.Generic;

namespace HotelProject.Models
{
    public partial class funcionario
    {
        public funcionario()
        {
            this.checkins = new List<checkin>();
        }

        public long funcionario_Id { get; set; }
        public string Descricao { get; set; }
        public Nullable<long> cidade_id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public System.DateTime DtRegistro { get; set; }
        public System.DateTime DtNascimento { get; set; }
        public string Sexo { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public virtual ICollection<checkin> checkins { get; set; }
        public virtual cidade cidade { get; set; }
    }
}
