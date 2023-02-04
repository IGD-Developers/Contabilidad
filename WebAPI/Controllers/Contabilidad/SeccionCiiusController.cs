using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Contabilidad;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistencia;
using Aplicacion.Contabilidad.SeccionCiius;
using Aplicacion.Models.Contabilidad.SeccionCiius;
using ContabilidadWebAPI.Controllers;

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