using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.DTOs
{
    public class PlanEntregaDto
    {
        public int IdPlanEntrega { get; set; }
        public int IdCliente { get; set; }
        public int IdPuntoEntrega { get; set; }
        public int IdTipoProducto { get; set; }
        public int CantidadProducto { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaEntrega { get; set; }
        public double PrecioEnvio { get; set; }
        public double PorcentajeDescuento { get; set; }
        public double PrecioEnvioFinal { get; set; }
        [MaxLength(10), MinLength(10)]
        public string NumeroGuia { get; set; }
        [MaxLength(8)]
        public string IdentificacionTransporte { get; set; }
    }
}
