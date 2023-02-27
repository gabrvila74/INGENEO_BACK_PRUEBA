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
    public class TipoDocumentoRepositorio : ITipoDocumento
    {
        private readonly INGENEOContext _context;
        private readonly IMapper _mapper;

        public TipoDocumentoRepositorio(INGENEOContext context, IMapper mapper)
        {
            this._context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TipoDocumentoDto>> GetTipoDocumentosAsync()
        {
            return await _context.TipoDocumentos
                .ProjectTo<TipoDocumentoDto>(_mapper.ConfigurationProvider)
                .ToListAsync(); 
        }

    }
}
