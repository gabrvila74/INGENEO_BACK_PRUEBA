using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngeneoAPI.Services
{
    public interface ITokenService
    {
        string CrearToken(string nombreUsuario);
    }

}
