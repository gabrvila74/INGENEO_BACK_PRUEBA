using System;
using System.Collections.Generic;

#nullable disable

namespace CapaDatos.Entidades
{
    public partial class TipoPuntoEntrega
    {
        public TipoPuntoEntrega()
        {
            PuntoEntregas = new HashSet<PuntoEntrega>();
        }

        public int IdTipoPuntoEntrega { get; set; }
        public int IdTipoLogistica { get; set; }
        public string Descripcion { get; set; }

        public virtual TipoLogistica IdTipoLogisticaNavigation { get; set; }
        public virtual ICollection<PuntoEntrega> PuntoEntregas { get; set; }
    }
}
