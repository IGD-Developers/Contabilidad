
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using ContabilidadWebAPI.Controllers;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Aplicacion.Contabilidad.Meses;

namespace ContabilidadWebAPI.Controllers.Contabilidad;


[ApiController]
[Route("api/[controller]")]
public class MesesController : MiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<CntMes>>> Get()
    {

        return await Mediator.Send(new Consulta.ListaCntMeses());

    }

    [HttpPost]
    public async Task<ActionResult<Unit>> Insertar(Insertar.Ejecuta data)
    {
        return await Mediator.Send(data);
    }

    // [HttpPut]
    // public async Task<ActionResult<Unit>>Editar(Editar.Ejecuta data){
    //     return await Mediator.Send(data);
    // }

    [HttpPut("{Id}")]

    public async Task<ActionResult<Unit>> Editar(int Id, Editar.Ejecuta data)

    {
        data.Id = Id;
        return await Mediator.Send(data);
    }
}