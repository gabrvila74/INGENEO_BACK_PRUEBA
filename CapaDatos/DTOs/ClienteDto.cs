using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.DTOs
{
    public class ClienteDto 
    {
        public int IdCliente { get; set; }
        public int IdTipoDocumento { get; set; }
        public string Documento { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
    }
}
