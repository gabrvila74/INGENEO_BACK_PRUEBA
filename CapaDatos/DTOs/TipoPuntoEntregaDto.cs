using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.DTOs
{
    public class TipoPuntoEntregaDto
    {
        public int IdTipoPuntoEntrega { get; set; }
        public int IdTipoLogistica { get; set; }
        public string Descripcion { get; set; }
    }
}
