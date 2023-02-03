using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Aplicacion.Contabilidad.Consecutivos;
using Dominio.Contabilidad;

namespace WebAPI.Controllers.Contabilidad;

[ApiController]
[Route("api/[controller]")]
public class ConsecutivosController : MiControllerBase
{

   
    [HttpGet]
    public async Task<ActionResult<List<CntConsecutivo>>> Get()

    {
        return await Mediator.Send(new Consulta.ListaCntConsecutivos());

    }

    [HttpPost]

    public async Task<ActionResult<CntConsecutivo>>  Insertar(Insertar.Ejecuta data)
    {

        return await Mediator.Send(data);
    }
    // [HttpPost]

    // public async Task<ActionResult<Unit>>  Insertar(Insertar.Ejecuta data)
    // {

    //     return await Mediator.Send(data);
    // }

    [HttpPut("{Id}")]

    public async Task<ActionResult<Unit>>  Editar(int Id, Editar.Ejecuta data) 
    
    {
        data.Id = Id;
        return await Mediator.Send(data);
    }


}
