using System;
using System.Collections.Generic;

#nullable disable

namespace CapaDatos.Entidades
{
    public partial class TipoDocumento
    {
        public TipoDocumento()
        {
            Clientes = new HashSet<Cliente>();
        }

        public int IdTipoDocumento { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
