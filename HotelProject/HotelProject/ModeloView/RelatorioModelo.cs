using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelProject.ModeloView
{
    public class RelatorioModelo
    {
        [DataType(DataType.Date)]
        public DateTime DataIni { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataFim { get; set; }
    }
}