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
    public class PlanEntregaRepositorio : IPlanEntrega
    {
        private readonly INGENEOContext _context;
        private readonly IMapper _mapper;

        public PlanEntregaRepositorio(INGENEOContext context, IMapper mapper)
        {
            this._context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PlanEntregaDto>> GetPlanEntregasAsync()
        {
            return await _context.PlanEntregas
                .ProjectTo<PlanEntregaDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<PlanEntrega> ObtenerPlanEntregaPorIdAsync(int IdPlanEntrega)
        {
            return await _context.PlanEntregas
                .FindAsync(IdPlanEntrega);
        }

        public async Task<bool> EliminarPlanEntregaAsync(PlanEntrega planEntrega)
        {
            _context.PlanEntregas.Remove(planEntrega);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> ActualizarPlanEntregaAsync(PlanEntrega planEntrega)
        {
            _context.PlanEntregas.Update(planEntrega);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<int> InsertarPlanEntregaAsync(PlanEntregaDto planEntregaDto)
        {
            PlanEntrega planEntrega = new PlanEntrega();

            _mapper.Map(planEntregaDto, planEntrega);
            _context.PlanEntregas.Add(planEntrega);
            await _context.SaveChangesAsync();

            return planEntrega.IdPlanEntrega;
        }

    }
}
