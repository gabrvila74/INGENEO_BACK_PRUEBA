using System;
using System.Collections.Generic;

#nullable disable

namespace CapaDatos.Entidades
{
    public partial class TipoProducto
    {
        public TipoProducto()
        {
            PlanEntregas = new HashSet<PlanEntrega>();
        }

        public int IdTipoProducto { get; set; }
        public string Descripcion { get; set; }
        public int? IdTipoLogistica { get; set; }

        public virtual TipoLogistica IdTipoLogisticaNavigation { get; set; }
        public virtual ICollection<PlanEntrega> PlanEntregas { get; set; }
    }
}
