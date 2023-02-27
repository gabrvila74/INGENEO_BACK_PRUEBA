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
    public class TipoProductoRepositorio : ITipoProducto
    {
        private readonly INGENEOContext _context;
        private readonly IMapper _mapper;

        public TipoProductoRepositorio(INGENEOContext context, IMapper mapper)
        {
            this._context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TipoProductoDto>> ObtenerTipoProductosAsync()
        {

            return await _context.TipoProductos
               .ProjectTo<TipoProductoDto>(_mapper.ConfigurationProvider)
               .ToListAsync();
        }

        public async Task<TipoProducto> ObtenerTipoProductoPorIdAsync(int IdTipoProducto)
        {
            return await _context.TipoProductos
                .FindAsync(IdTipoProducto);
        }

        public async Task<bool> GuardarTodoAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> EliminarTipoProductoAsync(TipoProducto tipoProducto)
        {
            _context.TipoProductos.Remove(tipoProducto);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> ActualizarTipoProductoAsync(TipoProducto tipoProducto)
        {
            _context.TipoProductos.Update(tipoProducto);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<int> InsertarTipoProductoAsync(TipoProductoDto tipoProductoDto)
        {
            TipoProducto tipoProducto = new TipoProducto();
            
            _mapper.Map(tipoProductoDto, tipoProducto);
            _context.TipoProductos.Add(tipoProducto);
            await _context.SaveChangesAsync();

            return tipoProducto.IdTipoProducto;
        }

    }
}
