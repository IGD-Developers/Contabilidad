using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ContabilidadWebAPI.Controllers;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Aplicacion.Contabilidad.FormatoColumnas;

namespace ContabilidadWebAPI.Controllers.Contabilidad;


[ApiController]
[Route("api/[controller]")]
public class FormatoColumnasController : MiControllerBase
{

    [HttpGet]
    public async Task<ActionResult<List<CntFormatoColumna>>> Get()
    {
        return await Mediator.Send(new ListaCntFormatoColumnasRequest());
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<CntFormatoColumna>> GetId(int Id)
    {
        return await Mediator.Send(new ConsultarFormatoColumnaRequest { Id = Id });
    }

    [HttpPost]
    public async Task<ActionResult<Unit>> Insertar(InsertarFormatoColumnaRequest data)
    {
        return await Mediator.Send(data);
    }

    [HttpPut("{Id}")]
    public async Task<ActionResult<Unit>> Editar(int Id, EditarFormatoColumnaRequest data)
    {
        data.Id = Id;
        return await Mediator.Send(data);
    }
}
