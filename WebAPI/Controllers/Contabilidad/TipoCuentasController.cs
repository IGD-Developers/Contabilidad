using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ContabilidadWebAPI.Controllers;
using ContabilidadWebAPI.Aplicacion.Contabilidad.TipoCuentas;
using ContabilidadWebAPI.Dominio.Contabilidad;

namespace ContabilidadWebAPI.Controllers.Contabilidad;

[ApiController]
[Route("api/[controller]")]
public class TipoCuentasController : MiControllerBase
{


    [HttpGet]

    public async Task<ActionResult<List<CntTipoCuenta>>> Get()
    {

        return await Mediator.Send(new ListaCntTipoCuentasRequest());
    }

    [HttpGet("{Id}")]

    public async Task<ActionResult<CntTipoCuenta>> GetId(int Id)
    {

        return await Mediator.Send(new ConsultarTipoCuentaRequest { Id = Id });

    }

    [HttpPost]

    public async Task<ActionResult<Unit>> Insertar(InsertarTipoCuentaRequest data)
    {

        return await Mediator.Send(data);
    }

    [HttpPut("{Id}")]

    public async Task<ActionResult<Unit>> Editar(int Id, EditarTipoCuentaRequest data)

    {
        data.Id = Id;
        return await Mediator.Send(data);
    }

}