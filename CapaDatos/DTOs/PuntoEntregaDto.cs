using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.DTOs
{
    public class PuntoEntregaDto
    {
        public int IdPuntoEntrega { get; set; }
        public int IdTipoPuntoEntrega { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
    }
}
