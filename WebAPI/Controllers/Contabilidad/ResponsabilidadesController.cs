using System.Collections.Generic;
using System.Threading.Tasks;
using ContabilidadWebAPI.Dominio.Contabilidad;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ContabilidadWebAPI.Controllers;
using ContabilidadWebAPI.Aplicacion.Contabilidad.Responsabilidades;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Responsabilidad;

namespace ContabilidadWebAPI.Controllers.Contabilidad;

[ApiController]
[Route("api/[controller]")]
public class ResponsabilidadesController : MiControllerBase
{

    [HttpGet]
    public async Task<ActionResult<List<ResponsabilidadModel>>> Get()
    {
        return await Mediator.Send(new Consulta.ListarResponsabilidades());
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<ResponsabilidadModel>> GetId(int Id)
    {
        return await Mediator.Send(new ConsultaId.ConsultarId { Id = Id });

    }
}