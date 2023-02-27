using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.DTOs
{
    public class TipoProductoDto
    {
        public int IdTipoProducto { get; set; }
        public int IdTipoLogistica { get; set; }
        public string Descripcion { get; set; }
    }
}
