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
    public interface ICliente
    {
        Task<IEnumerable<ClienteDto>> GetClientesAsync();
        Task<Cliente> ObtenerClientePorIdAsync(int IdCliente);
        Task<bool> ActualizarClienteAsync(Cliente cliente);
        Task<bool> EliminarClienteAsync(Cliente cliente);
        Task<int> InsertarClienteAsync(ClienteDto clienteDto);
    }
}
