using System;
using System.Collections.Generic;

#nullable disable

namespace CapaDatos.Entidades
{
    public partial class PlanEntrega
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
        public string NumeroGuia { get; set; }
        public string IdentificacionTransporte { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual PuntoEntrega IdPuntoEntregaNavigation { get; set; }
        public virtual TipoProducto IdTipoProductoNavigation { get; set; }
    }
}
