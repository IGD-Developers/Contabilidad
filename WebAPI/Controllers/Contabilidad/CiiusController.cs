using System.Collections.Generic;
using System.Threading.Tasks;
using Aplicacion.Contabilidad.Ciius;
using Aplicacion.Models.Contabilidad.Ciius;
using ContabilidadWebAPI.Controllers;
using Dominio.Contabilidad;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ContabilidadWebAPI.Controllers.Contabilidad;

[ApiController]
[Route("api/[controller]")]
public class CiiusController : MiControllerBase
{

    [HttpGet]
    public async Task<ActionResult<List<CiiuModel>>> Get()
    {
        return await Mediator.Send(new Consulta.ListaCiius());
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<CiiuModel>> Detalle(int Id)
    {
        return await Mediator.Send(new ConsultaId.ConsultarId { Id = Id });
    }

}