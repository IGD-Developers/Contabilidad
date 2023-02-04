using System.Collections.Generic;
using System.Linq;
using Dominio.Contabilidad;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistencia;
using Aplicacion.Contabilidad.TipoPersonas;
using System.Threading.Tasks;
using Aplicacion.Models.Contabilidad.TipoPersona;
using ContabilidadWebAPI.Controllers;

namespace ContabilidadWebAPI.Controllers.Contabilidad;

[ApiController]
[Route("api/[controller]")]
public class TipoPersonasController : MiControllerBase
{


    [HttpGet]
    public async Task<ActionResult<List<TipoPersonaModel>>> Get()
    {
        return await Mediator.Send(new Consulta.ListarTipoPersonas());
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<TipoPersonaModel>> Detalle(int Id)
    {
        return await Mediator.Send(new ConsultaId.ConsultarId { Id = Id });
    }
}