using AutoMapper;
using AutoMapper.QueryableExtensions;
using CapaDatos;
using CapaDatos.DTOs;
using CapaNegocio.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Repositorios
{
    public class TipoLogisticaRepositorio : ITipoLogistica
    {
        private readonly INGENEOContext _context;
        private readonly IMapper _mapper;

        public TipoLogisticaRepositorio(INGENEOContext context, IMapper mapper)
        {
            this._context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TipoLogisticaDto>> GetTipoLogisticasAsync()
        {
            return await _context.TipoLogisticas
                           .ProjectTo<TipoLogisticaDto>(_mapper.ConfigurationProvider)
                           .ToListAsync(); 

        }
    }
}
