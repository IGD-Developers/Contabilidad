using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ContabilidadWebAPI.Controllers;
using ContabilidadWebAPI.Aplicacion.Contabilidad.TipoOperaciones;
using ContabilidadWebAPI.Dominio.Contabilidad;

namespace ContabilidadWebAPI.Controllers.Contabilidad;


[ApiController]
[Route("api/[controller]")]
public class TipoOperacionesController : MiControllerBase
{


    [HttpGet]
    public async Task<ActionResult<List<CntTipoOperacion>>> Get()
    {


        return await Mediator.Send(new ListaCntTipoOperacionesRequest());

    }

    [HttpGet("{Id}")]

    public async Task<ActionResult<CntTipoOperacion>> GetId(int Id)
    {
        return await Mediator.Send(new ConsultarTipoOperacionRequest { Id = Id });
    }

    [HttpPost]

    public async Task<ActionResult<Unit>> Insertar(InsertarTipoOperacionRequest data)
    {

        return await Mediator.Send(data);
    }

    [HttpPut("{Id}")]

    public async Task<ActionResult<Unit>> Editar(int Id, EditarTipoOperacionRequest data)

    {
        data.Id = Id;
        return await Mediator.Send(data);
    }


}