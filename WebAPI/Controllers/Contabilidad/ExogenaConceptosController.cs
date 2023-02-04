using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ContabilidadWebAPI.Controllers;
using ContabilidadWebAPI.Aplicacion.Contabilidad.ExogenaConceptos;
using ContabilidadWebAPI.Dominio.Contabilidad;

namespace ContabilidadWebAPI.Controllers.Contabilidad;


[ApiController]
[Route("api/[controller]")]
public class ExogenaConceptosController : MiControllerBase
{



    [HttpGet]

    public async Task<ActionResult<List<CntExogenaConcepto>>> Get()
    {

        return await Mediator.Send(new Consulta.ListaCntExogenaConceptos());
    }

    [HttpGet("{Id}")]

    public async Task<ActionResult<CntExogenaConcepto>> GetId(int Id)
    {
        return await Mediator.Send(new ConsultaId.ConsultarId { Id = Id });

    }

    [HttpPost]
    public async Task<ActionResult<Unit>> Insertar(Insertar.Ejecuta data)
    {
        return await Mediator.Send(data);
    }

    [HttpPut("{Id}")]

    public async Task<ActionResult<Unit>> Editar(int Id, Editar.Ejecuta data)

    {
        data.Id = Id;
        return await Mediator.Send(data);
    }


}