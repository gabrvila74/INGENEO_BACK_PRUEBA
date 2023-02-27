using AutoMapper;
using CapaDatos;
using CapaDatos.DTOs;
using CapaDatos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<TipoDocumento, TipoDocumentoDto>();
            CreateMap<TipoLogistica, TipoLogisticaDto>();
            CreateMap<TipoProducto, TipoProductoDto>();
            CreateMap<TipoProductoDto, TipoProducto>();
            CreateMap<Cliente, ClienteDto>();
            CreateMap<ClienteDto, Cliente>();
            CreateMap<PlanEntrega, PlanEntregaDto>();
            CreateMap<PlanEntregaDto, PlanEntrega>();
            CreateMap<PuntoEntrega, PuntoEntregaDto>();
            CreateMap<PuntoEntregaDto, PuntoEntrega>();
            CreateMap<TipoPuntoEntrega, TipoPuntoEntregaDto>();
        }
    }
}
