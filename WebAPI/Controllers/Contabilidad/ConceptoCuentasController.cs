using MediatR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ContabilidadWebAPI.Controllers;
using ContabilidadWebAPI.Aplicacion.Contabilidad.ConceptoCuentas;
using ContabilidadWebAPI.Dominio.Contabilidad;

namespace ContabilidadWebAPI.Controllers.Contabilidad;

[ApiController]
[Route("api/[controller]")]
public class ConceptoCuentasController : MiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<CntConceptoCuenta>>> Get()
    {

        return await Mediator.Send(new ListaCntConceptoCuentasRequest());


    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<CntConceptoCuenta>> GetId(int Id)
    {
        return await Mediator.Send(new ConsultarConceptoCuentaRequest { Id = Id });

    }

    [HttpPost]
    public async Task<ActionResult<Unit>> Insertar(InsertarConceptoCuentaRequest data)
    {

        return await Mediator.Send(data);
    }

    [HttpPut("{Id}")]
    public async Task<ActionResult<Unit>> Editar(int Id, EditarConceptoCuentaRequest data)
    {
        data.Id = Id;
        return await Mediator.Send(data);
    }
}

