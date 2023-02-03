using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Aplicacion.Contabilidad.DetalleComprobantes;
using Dominio.Contabilidad;

namespace WebAPI.Controllers.Contabilidad;


[ApiController]
[Route("api/[controller]")]
public class DetalleComprobantesController : MiControllerBase
{
    

    [HttpGet]
    public async Task<ActionResult<List<CntDetalleComprobante>>> Get()
    {

        return await Mediator.Send(new Consulta.ListaDetalleComprobantes());

    }

    [HttpGet("{id}")]

    public async Task<ActionResult<CntDetalleComprobante>> GetId(int id)
    {
        return await Mediator.Send(new ConsultaId.ConsultarId { Id = id });

    }

    [HttpPost]

    public async  Task<ActionResult<Unit>> Insertar(Insertar.Ejecuta data) {

        return await Mediator.Send(data);
    }

    
    [HttpPut("{id}")]

    public async Task<ActionResult<Unit>>  Editar(int id, Editar.Ejecuta data) 
    
    {
        data.Id = id;
        return await Mediator.Send(data);
    }


}
