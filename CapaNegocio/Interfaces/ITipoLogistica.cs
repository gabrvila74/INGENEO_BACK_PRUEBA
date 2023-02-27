using CapaDatos;
using CapaDatos.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Interfaces
{
    public interface ITipoLogistica
    {
        Task<IEnumerable<TipoLogisticaDto>> GetTipoLogisticasAsync();
    }
}
