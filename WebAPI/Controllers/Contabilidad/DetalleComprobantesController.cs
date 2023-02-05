using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using ContabilidadWebAPI.Controllers;
using ContabilidadWebAPI.Aplicacion.Contabilidad.DetalleComprobantes;
using ContabilidadWebAPI.Dominio.Contabilidad;

namespace ContabilidadWebAPI.Controllers.Contabilidad;


[ApiController]
[Route("api/[controller]")]
public class DetalleComprobantesController : MiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<CntDetalleComprobante>>> Get()
    {
        return await Mediator.Send(new ListaDetalleComprobantesRequest());
    }
    
    [HttpGet("{Id}")]
    public async Task<ActionResult<CntDetalleComprobante>> GetId(int Id)
    {
        return await Mediator.Send(new ConsultarDetalleComprobanteRequest { Id = Id });
    }

    [HttpPost]
    public async Task<ActionResult<Unit>> Insertar(InsertarDetalleComprobanteRequest data)
    {
        return await Mediator.Send(data);
    }

    [HttpPut("{Id}")]
    public async Task<ActionResult<Unit>> Editar(int Id, EditarDetalleComprobanteRequest data)
    {
        data.Id = Id;
        return await Mediator.Send(data);
    }
}
