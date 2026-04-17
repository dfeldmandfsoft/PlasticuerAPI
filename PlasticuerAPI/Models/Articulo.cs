using System;
using System.Collections.Generic;
using System.Text;

namespace PlasticuerAPI.Models
{
    public class Articulo
    {
        public int IdArticulo { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public double AlicuotaIVA { get; set; }
        public int IdLinea { get; set; }
        public int IdRubro { get; set; }

    }
}
