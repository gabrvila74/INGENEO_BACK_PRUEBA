using AutoMapper;
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
    public class PuntoEntregaController : BaseApiController {
        private readonly IPuntoEntrega _puntoEntrega;
        private readonly IMapper _mapper;

        public PuntoEntregaController(IPuntoEntrega puntoEntrega, IMapper mapper)
        {
            _puntoEntrega = puntoEntrega;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PuntoEntregaDto>>> Get()
        {
            var puntoEntregas = await _puntoEntrega.GetPuntoEntregasAsync();
            return Ok(puntoEntregas);
        }

        [HttpPost]
        public async Task<ActionResult<int>> InsertarPuntoEntrega(PuntoEntregaDto puntoEntregaDto)
        {
            try
            {
                if (puntoEntregaDto == null)
                {
                    return BadRequest("Punto de entrega a insertar invalido");
                }

                return await _puntoEntrega.InsertarPuntoEntregaAsync(puntoEntregaDto);

            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Error insertando la información: " + err.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> ActualizarPuntoEntrega(PuntoEntregaDto puntoEntregaDto)
        {
            try
            {
                var puntoEntrega = await _puntoEntrega.ObtenerPuntoEntregaPorIdAsync(puntoEntregaDto.IdPuntoEntrega);

                if (puntoEntrega == null)
                {
                    return NotFound($"El plan de entrega: {puntoEntregaDto.IdPuntoEntrega}, no se encontró en la bd.");
                }

                _mapper.Map(puntoEntregaDto, puntoEntrega);

                if (await _puntoEntrega.ActualizarPuntoEntregaAsync(puntoEntrega)) return Ok();

                return BadRequest("Se presentó un error en la actualización del plan de entrega.");
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Error actualizando la información: " + err.Message);
            }
        }

        [HttpDelete("{IdPuntoEntrega}")]
        public async Task<ActionResult> EliminarPuntoEntrega(int IdPuntoEntrega)
        {
            try
            {
                var planEntrega = await _puntoEntrega.ObtenerPuntoEntregaPorIdAsync(IdPuntoEntrega);

                if (planEntrega == null)
                {
                    return NotFound($"El plan de entrega: {IdPuntoEntrega}, no se encontró en la bd.");
                }

                if (await _puntoEntrega.EliminarPuntoEntregaAsync(planEntrega)) return Ok();

                return BadRequest("Se presentó un error en la eliminación del plan de entrega.");
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Error eliminando la información: " + err.Message);
            }
        }

    }
}
