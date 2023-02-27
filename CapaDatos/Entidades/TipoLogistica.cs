using System;
using System.Collections.Generic;

#nullable disable

namespace CapaDatos.Entidades
{
    public partial class TipoLogistica
    {
        public TipoLogistica()
        {
            TipoProductos = new HashSet<TipoProducto>();
            TipoPuntoEntregas = new HashSet<TipoPuntoEntrega>();
        }

        public int IdTipoLogistica { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<TipoProducto> TipoProductos { get; set; }
        public virtual ICollection<TipoPuntoEntrega> TipoPuntoEntregas { get; set; }
    }
}
