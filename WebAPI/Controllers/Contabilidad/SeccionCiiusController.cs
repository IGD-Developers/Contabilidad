using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContabilidadWebAPI.Dominio.Contabilidad;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ContabilidadWebAPI.Persistencia;
using ContabilidadWebAPI.Controllers;
using ContabilidadWebAPI.Aplicacion.Contabilidad.SeccionCiius;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.SeccionCiius;

namespace ContabilidadWebAPI.Controllers.Contabilidad;

[ApiController]
[Route("api/[controller]")]
public class SeccionCiiusController : MiControllerBase
{


    [HttpGet]
    public async Task<ActionResult<List<SeccionCiiusModel>>> Get()
    {
        return await Mediator.Send(new Consulta.ListarSeccionCiius());
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<SeccionCiiusModel>> Detalle(int Id)
    {
        return await Mediator.Send(new ConsultaId.ConsultarId { Id = Id });
    }
}