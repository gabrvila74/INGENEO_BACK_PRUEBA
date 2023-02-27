using CapaDatos;
using CapaDatos.DTOs;
using CapaDatos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio.Interfaces
{
    public interface IPlanEntrega
    {
        Task<IEnumerable<PlanEntregaDto>> GetPlanEntregasAsync();
        Task<PlanEntrega> ObtenerPlanEntregaPorIdAsync(int IdPlanEntrega);
        Task<bool> EliminarPlanEntregaAsync(PlanEntrega planEntrega);
        Task<bool> ActualizarPlanEntregaAsync(PlanEntrega planEntrega);
        Task<int> InsertarPlanEntregaAsync(PlanEntregaDto planEntregaDto);
    }
}
