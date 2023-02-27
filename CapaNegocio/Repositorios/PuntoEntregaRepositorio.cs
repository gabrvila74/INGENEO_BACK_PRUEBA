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
    public class PuntoEntregaRepositorio : IPuntoEntrega
    {
        private readonly INGENEOContext _context;
        private readonly IMapper _mapper;

        public PuntoEntregaRepositorio(INGENEOContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<bool> ActualizarPuntoEntregaAsync(PuntoEntrega puntoEntrega)
        {
            _context.PuntoEntregas.Update(puntoEntrega);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> EliminarPuntoEntregaAsync(PuntoEntrega puntoEntrega)
        {
            _context.PuntoEntregas.Remove(puntoEntrega);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<PuntoEntregaDto>> GetPuntoEntregasAsync()
        {
            return await _context.PuntoEntregas
                .ProjectTo<PuntoEntregaDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<int> InsertarPuntoEntregaAsync(PuntoEntregaDto puntoEntregaDto)
        {
            PuntoEntrega puntoEntrega = new PuntoEntrega();

            _mapper.Map(puntoEntregaDto, puntoEntrega);
            _context.PuntoEntregas.Add(puntoEntrega);
            await _context.SaveChangesAsync();

            return puntoEntrega.IdPuntoEntrega;
        }

        public async Task<PuntoEntrega> ObtenerPuntoEntregaPorIdAsync(int IdPuntoEntrega)
        {
            return await _context.PuntoEntregas
                .FindAsync(IdPuntoEntrega);
        }
    }
}
