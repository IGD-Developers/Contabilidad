using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Controllers;
using ContabilidadWebAPI.Aplicacion.Contabilidad.Comprobantes;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Comprobantes;

namespace ContabilidadWebAPI.Controllers.Contabilidad;

[ApiController]
[Route("api/[controller]")]
public class ComprobantesController : MiControllerBase
{

    [HttpGet]
    //<CntComprobante proviene de Dominio>
    public async Task<ActionResult<List<ListarComprobantesModel>>> Get()
    {

        return await Mediator.Send(new Consulta.ListaCntComprobantes());
    }

    [HttpGet("{Id}")]

    public async Task<ActionResult<ListarComprobantesModel>> GetId(int Id)
    {

        return await Mediator.Send(new ConsultaId.ConsultarId { Id = Id });


    }

    [HttpPost]

    public async Task<ActionResult<Unit>> Insertar(Insertar.Ejecuta data)
    {
        data.IdModulo = 1;
        return await Mediator.Send(data);
    }


    [HttpPost("liquidaimpuesto")]


    public async Task<ActionResult<Unit>> LiquidaImpuesto(Insertar.Ejecuta data)
    {
        data.IdModulo = 2;
        return await Mediator.Send(data);
    }



    [HttpPut("{Id}")]

    public async Task<ActionResult<Unit>> Editar(int Id, Editar.Ejecuta data)

    {
        data.Id = Id;
        return await Mediator.Send(data);
    }

    [HttpPut("anular/{Id}")]

    public async Task<ActionResult<Unit>> Anular(int Id, Anular.Ejecuta data)

    {
        data.Id = Id;
        return await Mediator.Send(data);
    }

    [HttpDelete("eliminar/{Id}")]

    public async Task<ActionResult<Unit>> Eliminar(int Id, Eliminar.Ejecuta data)

    {
        data.Id = Id;
        return await Mediator.Send(data);
    }



    [HttpPut("revertir/{Id}")]

    public async Task<ActionResult<Unit>> Revertir(int Id, Revertir.Ejecuta data)

    {
        data.Id = Id;
        return await Mediator.Send(data);

    }


}




