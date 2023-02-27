using CapaDatos.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Interfaces
{
    public interface ITipoPuntoEntrega
    {
        Task<IEnumerable<TipoPuntoEntregaDto>> GetTipoPuntoEntregasAsync();
    }
}
