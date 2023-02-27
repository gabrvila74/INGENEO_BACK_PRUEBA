using CapaDatos.DTOs;
using CapaDatos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Interfaces
{
    public interface IPuntoEntrega
    {
        Task<IEnumerable<PuntoEntregaDto>> GetPuntoEntregasAsync();
        Task<PuntoEntrega> ObtenerPuntoEntregaPorIdAsync(int IdPuntoEntrega);
        Task<bool> EliminarPuntoEntregaAsync(PuntoEntrega puntoEntrega);
        Task<bool> ActualizarPuntoEntregaAsync(PuntoEntrega puntoEntrega);
        Task<int> InsertarPuntoEntregaAsync(PuntoEntregaDto puntoEntregaDto);
    }
}
