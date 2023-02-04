using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContabilidadWebAPI.Aplicacion.Contabilidad.Regimenes;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Regimen;
using ContabilidadWebAPI.Controllers;
using ContabilidadWebAPI.Dominio.Contabilidad;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ContabilidadWebAPI.Persistencia;

namespace ContabilidadWebAPI.Controllers.Contabilidad;

[ApiController]
[Route("api/[controller]")]
public class RegimenesController : MiControllerBase
{

    [HttpGet]
    public async Task<ActionResult<List<RegimenModel>>> Get()
    {
        return await Mediator.Send(new Consulta.ListarRegimenes());
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<RegimenModel>> Detalle(int Id)
    {
        return await Mediator.Send(new ConsultaId.ConsultarId { Id = Id });
    }

}