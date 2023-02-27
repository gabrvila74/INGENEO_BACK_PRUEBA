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
    public class TipoPuntoEntregaController : BaseApiController
    {
        private readonly ITipoPuntoEntrega _tipoPuntoEntrega;

        public TipoPuntoEntregaController(ITipoPuntoEntrega tipoPuntoEntrega)
        {
            _tipoPuntoEntrega = tipoPuntoEntrega;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoPuntoEntregaDto>>> Get()
        {
            var tipoPuntoEntregas = await _tipoPuntoEntrega.GetTipoPuntoEntregasAsync();
            return Ok(tipoPuntoEntregas);
        }

    }
}
