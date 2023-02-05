using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using ContabilidadWebAPI.Controllers;
using ContabilidadWebAPI.Aplicacion.Contabilidad.Consecutivos;
using ContabilidadWebAPI.Dominio.Contabilidad;

namespace ContabilidadWebAPI.Controllers.Contabilidad;

[ApiController]
[Route("api/[controller]")]
public class ConsecutivosController : MiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<CntConsecutivo>>> Get()

    {
        return await Mediator.Send(new ListaCntConsecutivosRequest());

    }

    [HttpPost]
    public async Task<ActionResult<CntConsecutivo>> Insertar(InsertarConsecutivoRequest data)
    {

        return await Mediator.Send(data);
    }
    // [HttpPost]

    // public async Task<ActionResult<Unit>>  Insertar(Insertar.Ejecuta data)
    // {

    //     return await Mediator.Send(data);
    // }

    [HttpPut("{Id}")]
    public async Task<ActionResult<Unit>> Editar(int Id, EditarConsecutivoRequest data)
    {
        data.Id = Id;
        return await Mediator.Send(data);
    }

}
