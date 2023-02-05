using System.Collections.Generic;
using System.Linq;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ContabilidadWebAPI.Persistencia;
using System.Threading.Tasks;
using ContabilidadWebAPI.Controllers;
using ContabilidadWebAPI.Aplicacion.Contabilidad.TipoPersonas;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.TipoPersona;

namespace ContabilidadWebAPI.Controllers.Contabilidad;

[ApiController]
[Route("api/[controller]")]
public class TipoPersonasController : MiControllerBase
{


    [HttpGet]
    public async Task<ActionResult<List<TipoPersonaModel>>> Get()
    {
        return await Mediator.Send(new ListarTipoPersonasRequest());
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<TipoPersonaModel>> Detalle(int Id)
    {
        return await Mediator.Send(new ConsultarTipoPersonaRequest { Id = Id });
    }
}