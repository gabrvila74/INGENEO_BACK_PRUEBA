using CapaDatos;
using CapaNegocio.Interfaces;
using CapaNegocio.Repositorios;
using IngeneoAPI.Filters;
using IngeneoAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngeneoAPI.Extensions
{
    public static class ApplicationsServiceExtensions
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            // Configuración del acceso a datos
            services.AddDbContext<INGENEOContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("INGENEOConnection"));
            });

            // Configurar las interfaces para que el controlador las pueda usar
            services.AddScoped<ICliente, ClienteRepositorio>();
            services.AddScoped<ITipoDocumento, TipoDocumentoRepositorio>();
            services.AddScoped<ITipoLogistica, TipoLogisticaRepositorio>();
            services.AddScoped<ITipoProducto, TipoProductoRepositorio>();
            services.AddScoped<IPlanEntrega, PlanEntregaRepositorio>();
            services.AddScoped<IPuntoEntrega, PuntoEntregaRepositorio>();
            services.AddScoped<ITipoPuntoEntrega, TipoPuntoEntregaRepositorio>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ValidationFilterAttribute>();
            services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

            return services;

        }
    }
}
