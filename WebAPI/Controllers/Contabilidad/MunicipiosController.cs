using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContabilidadWebAPI.Aplicacion.Contabilidad.Municipios;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Municipios;
using ContabilidadWebAPI.Dominio.Contabilidad;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ContabilidadWebAPI.Persistencia;

namespace ContabilidadWebAPI.Controllers.Contabilidad;

[ApiController]
[Route("api/[controller]")]
public class MunicipiosController : ControllerBase
{
    private readonly IMediator _mediator;

    public MunicipiosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<MunicipioModel>>> Get()
    {
        return await _mediator.Send(new ListarMunicipiosRequest());
    }


    [HttpGet("{Id}")]
    public async Task<ActionResult<MunicipioModel>> Detalle(int Id)
    {
        return await _mediator.Send(new ConsultarMunicipioRequest { Id = Id });
    }




}