using System;
using System.Collections.Generic;

#nullable disable

namespace CapaDatos.Entidades
{
    public partial class PuntoEntrega
    {
        public PuntoEntrega()
        {
            PlanEntregas = new HashSet<PlanEntrega>();
        }

        public int IdPuntoEntrega { get; set; }
        public int IdTipoPuntoEntrega { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }

        public virtual TipoPuntoEntrega IdTipoPuntoEntregaNavigation { get; set; }
        public virtual ICollection<PlanEntrega> PlanEntregas { get; set; }
    }
}
