using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ContabilidadWebAPI.Controllers;
using ContabilidadWebAPI.Aplicacion.Contabilidad.ExogenaFormatos;
using ContabilidadWebAPI.Dominio.Contabilidad;

namespace ContabilidadWebAPI.Controllers.Contabilidad;


[ApiController]
[Route("api/[controller]")]
public class ExogenaFormatosController : MiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<CntExogenaFormato>>> Get()
    {
        return await Mediator.Send(new ListaCntExogenaFormatosRequest());
    }

    [HttpGet("{Id}")]

    public async Task<ActionResult<CntExogenaFormato>> GetId(int Id)
    {
        return await Mediator.Send(new ConsultarExogenaFormatoRequest { Id = Id });
    }

    [HttpPost]
    public async Task<ActionResult<Unit>> Insertar(InsertarExogenaFormatoRequest data)
    {
        return await Mediator.Send(data);
    }

    [HttpPut("{Id}")]
    public async Task<ActionResult<Unit>> Editar(int Id, EditarExogenaFormatoRequest data)
    {
        data.Id = Id;
        return await Mediator.Send(data);
    }
}