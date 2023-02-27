using System;
using System.Collections.Generic;

#nullable disable

namespace CapaDatos.Entidades
{
    public partial class Cliente
    {
        public Cliente()
        {
            PlanEntregas = new HashSet<PlanEntrega>();
        }

        public int IdCliente { get; set; }
        public int IdTipoDocumento { get; set; }
        public string Documento { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public virtual TipoDocumento IdTipoDocumentoNavigation { get; set; }
        public virtual ICollection<PlanEntrega> PlanEntregas { get; set; }
    }
}
