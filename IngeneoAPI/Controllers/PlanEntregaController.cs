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
    public class PlanEntregaController : BaseApiController
    {
        private readonly IPlanEntrega _planEntrega;
        private readonly IMapper _mapper;

        public PlanEntregaController(IPlanEntrega planEntrega, IMapper mapper)
        {
            _planEntrega = planEntrega;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlanEntregaDto>>> Get()
        {
            var tipoDocumentos = await _planEntrega.GetPlanEntregasAsync();
            return Ok(tipoDocumentos);
        }

        [HttpPost]
        public async Task<ActionResult<int>> InsertarPlanEntrega(PlanEntregaDto planEntregaDto)
        {
            try
            {
                if (planEntregaDto == null)
                {
                    return BadRequest("Tipo de producto a insertar invalido");
                }

                return await _planEntrega.InsertarPlanEntregaAsync(planEntregaDto);

            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Error insertando la información: " + err.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> ActualizarPlanEntrega(PlanEntregaDto planEntregaDto)
        {
            try
            {
                var planEntrega = await _planEntrega.ObtenerPlanEntregaPorIdAsync(planEntregaDto.IdPlanEntrega);

                if (planEntrega == null)
                {
                    return NotFound($"El plan de entrega: {planEntregaDto.IdPlanEntrega}, no se encontró en la bd.");
                }

                _mapper.Map(planEntregaDto, planEntrega);

                if (await _planEntrega.ActualizarPlanEntregaAsync(planEntrega)) return Ok();

                return BadRequest("Se presentó un error en la actualización del plan de entrega.");
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Error actualizando la información: " + err.Message);
            }
        }

        [HttpDelete("{IdPlanEntrega}")]
        public async Task<ActionResult> EliminarPlanEntrega(int IdPlanEntrega)
        {
            try
            {
                var planEntrega = await _planEntrega.ObtenerPlanEntregaPorIdAsync(IdPlanEntrega);

                if (planEntrega == null)
                {
                    return NotFound($"El plan de entrega: {IdPlanEntrega}, no se encontró en la bd.");
                }

                if (await _planEntrega.EliminarPlanEntregaAsync(planEntrega)) return Ok();

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
