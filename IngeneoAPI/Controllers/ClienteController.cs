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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IngeneoAPI.Controllers
{
    [Authorize]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public class ClienteController : BaseApiController
    {
        private readonly ICliente _cliente;
        private readonly IMapper _mapper;

        public ClienteController(ICliente cliente, IMapper mapper)
        {
            _cliente = cliente;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDto>>> Get()
        {
            var clientes = await _cliente.GetClientesAsync();
            return Ok(clientes);
        }

        [HttpPost]
        public async Task<ActionResult<int>> InsertarCliente(ClienteDto clienteDto)
        {
            try
            {
                if (clienteDto == null)
                {
                    return BadRequest("Cliente a insertar invalido");
                }

                return await _cliente.InsertarClienteAsync(clienteDto);

            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Error insertando la información: " + err.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> ActualizarCliente(ClienteDto clienteDto)
        {
            try
            {
                var cliente = await _cliente.ObtenerClientePorIdAsync(clienteDto.IdCliente);

                if (cliente == null)
                {
                    return NotFound($"El tipo de producto: {clienteDto.IdCliente}, no se encontró en la bd.");
                }

                _mapper.Map(clienteDto, cliente);

                if (await _cliente.ActualizarClienteAsync(cliente)) return Ok();

                return BadRequest("Se presentó un error en la actualización del cliente.");
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error actualizando la información: " + err.Message);
            }
        }


        [HttpDelete("{IdCliente}")]
        public async Task<ActionResult> EliminarCliente(int IdCliente)
        {
            try
            {
                var cliente = await _cliente.ObtenerClientePorIdAsync(IdCliente);

                if (cliente == null)
                {
                    return NotFound($"El cliente: {IdCliente}, no se encontró en la bd.");
                }

                if (await _cliente.EliminarClienteAsync(cliente)) return Ok();

                return BadRequest("Se presentó un error en la eliminación del cliente.");
            }
            catch (Exception err)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                     "Error eliminando la información: " + err.Message);
            }
        }
    }
}
