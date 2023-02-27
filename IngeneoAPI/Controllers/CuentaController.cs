using IngeneoAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngeneoAPI.Controllers
{
    public class CuentaController : BaseApiController
    {
        private readonly ITokenService _tokenService;

        public CuentaController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpGet("Login")]
        public ActionResult<string> Login()
        {
            // En este método se debe implementar la lógica de logueo con las credenciales del usuario
            // que está ingresando al sistema.
            // Si es un usuario valido se crea token JWT.
            return  new JsonResult(_tokenService.CrearToken("nombreusuario"));

        }
    }
}
