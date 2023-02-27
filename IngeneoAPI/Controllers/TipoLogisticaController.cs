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
    public class TipoLogisticaController : BaseApiController
    {
        private readonly ITipoLogistica _tipoLogistica;

        public TipoLogisticaController(ITipoLogistica tipoLogistica)
        {
            _tipoLogistica = tipoLogistica;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoLogisticaDto>>> Get()
        {
            var tipoLogisticas = await _tipoLogistica.GetTipoLogisticasAsync();
            return Ok(tipoLogisticas);

        }
    }
}
