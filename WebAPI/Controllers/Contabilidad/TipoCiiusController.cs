using System.Collections.Generic;
using System.Linq;
using ContabilidadWebAPI.Dominio.Contabilidad;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ContabilidadWebAPI.Persistencia;
using System.Threading.Tasks;
using ContabilidadWebAPI.Controllers;
using ContabilidadWebAPI.Aplicacion.Contabilidad.TipoCiius;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.TipoCiius;

namespace ContabilidadWebAPI.Controllers.Contabilidad;

[ApiController]
[Route("api/[controller]")]
public class TipoCiiusController : MiControllerBase
{


    [HttpGet]
    public async Task<ActionResult<List<TipoCiiusModel>>> Get()
    {
        return await Mediator.Send(new ListarTipoCiiusRequest());
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<TipoCiiusModel>> Detalle(int Id)
    {
        return await Mediator.Send(new ConsultarTipoCiiuRequest { Id = Id });
    }
}