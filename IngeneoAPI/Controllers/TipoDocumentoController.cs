using AutoMapper;
using CapaDatos;
using CapaDatos.DTOs;
using CapaNegocio.Interfaces;
using IngeneoAPI.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngeneoAPI.Controllers
{
    [Authorize]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public class TipoDocumentoController : BaseApiController
    {
        private readonly ITipoDocumento _tipoDocumento;

        public TipoDocumentoController(ITipoDocumento tipoDocumento)
        {
            _tipoDocumento = tipoDocumento;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoDocumentoDto>>> Get()
        {
            var tipoDocumentos = await _tipoDocumento.GetTipoDocumentosAsync();
            return Ok(tipoDocumentos);
        }

    }
}
