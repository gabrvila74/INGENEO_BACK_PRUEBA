using AutoMapper;
using AutoMapper.QueryableExtensions;
using CapaDatos;
using CapaDatos.DTOs;
using CapaDatos.Entidades;
using CapaNegocio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Repositorios
{
    public class ClienteRepositorio : ICliente
    {
        private readonly INGENEOContext _context;
        private readonly IMapper _mapper;

        public ClienteRepositorio(INGENEOContext context, IMapper mapper)
        {
            this._context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClienteDto>> GetClientesAsync()
        {
            return await _context.Clientes
                .ProjectTo<ClienteDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }


        public async Task<Cliente> ObtenerClientePorIdAsync(int IdCliente)
        {
            return await _context.Clientes
                .FindAsync(IdCliente);
        }

        public async Task<bool> EliminarClienteAsync(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<int> InsertarClienteAsync(ClienteDto clienteDto)
        {
            Cliente cliente = new Cliente();

            _mapper.Map(clienteDto, cliente);
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return cliente.IdCliente;
        }

        public async Task<bool> ActualizarClienteAsync(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
