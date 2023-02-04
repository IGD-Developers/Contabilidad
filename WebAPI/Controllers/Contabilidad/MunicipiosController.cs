using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Contabilidad.Municipios;
using Aplicacion.Models.Contabilidad.Municipios;
using Dominio.Contabilidad;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistencia;

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
        return await _mediator.Send(new Consulta.ListarMunicipios());
    }


    [HttpGet("{Id}")]
    public async Task<ActionResult<MunicipioModel>> Detalle(int Id)
    {
        return await _mediator.Send(new ConsultaId.ConsultarId { Id = Id });
    }




}