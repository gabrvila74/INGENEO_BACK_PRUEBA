using CapaDatos;
using CapaDatos.DTOs;
using CapaDatos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Interfaces
{
    public interface ITipoProducto
    {
        Task<IEnumerable<TipoProductoDto>> ObtenerTipoProductosAsync();
        Task<TipoProducto> ObtenerTipoProductoPorIdAsync(int IdTipoProducto);
        Task<bool> GuardarTodoAsync();
        Task<bool> EliminarTipoProductoAsync(TipoProducto tipoProducto);
        Task<bool> ActualizarTipoProductoAsync(TipoProducto tipoProducto);
        Task<int> InsertarTipoProductoAsync(TipoProductoDto tipoProductoDto);
    }
}
