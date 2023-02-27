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
    public class TipoProductoController : BaseApiController
    {
        private readonly ITipoProducto _tipoProducto;
        private readonly IMapper _mapper;

        public TipoProductoController(ITipoProducto tipoProducto, IMapper mapper)
        {
            _tipoProducto = tipoProducto;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoProductoDto>>> ObenerTipoProducto()
        {
            var tipoProductos = await _tipoProducto.ObtenerTipoProductosAsync();
            return Ok(tipoProductos);
        }

        [HttpPost]
        public async Task<ActionResult<int>> InsertarTipoProducto(TipoProductoDto tipoProductoDto)
        {
            try
            {
                if (tipoProductoDto == null)
                {
                    return BadRequest("Tipo de producto a insertar invalido");
                }

                return await _tipoProducto.InsertarTipoProductoAsync(tipoProductoDto);

            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Error insertando la información: " + err.InnerException);
            }
        }

        [HttpPut]
        public async Task<ActionResult> ActualizarTipoProducto(TipoProductoDto tipoProductoDto)
        {
            try
            {
                var tipoProducto = await _tipoProducto.ObtenerTipoProductoPorIdAsync(tipoProductoDto.IdTipoProducto);

                if (tipoProducto == null)
                {
                    return NotFound($"El tipo de producto: {tipoProductoDto.IdTipoProducto}, no se encontró en la bd.");
                }

                _mapper.Map(tipoProductoDto, tipoProducto);

                if (await _tipoProducto.ActualizarTipoProductoAsync(tipoProducto)) return Ok();

                return BadRequest("Se presentó un error en la actualización del tipo de producto.");
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error actualizando la información: " + err.InnerException);
            }
        }

        [HttpDelete("{IdTipoProducto}")]
        public async Task<ActionResult> EliminarTipoProducto(int IdTipoProducto)
        {
            try
            {
                var tipoProducto = await _tipoProducto.ObtenerTipoProductoPorIdAsync(IdTipoProducto);

                if (tipoProducto == null)
                {
                    return NotFound($"El tipo de producto: {IdTipoProducto}, no se encontró en la bd.");
                }

                if (await _tipoProducto.EliminarTipoProductoAsync(tipoProducto)) return Ok();

                return BadRequest("Se presentó un error en la eliminación del tipo de producto.");
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error eliminando la información: " + err.InnerException);
            }
        }
    }
}
