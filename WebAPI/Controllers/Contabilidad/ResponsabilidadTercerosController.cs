using System.Collections.Generic;
using System.Threading.Tasks;
using Dominio.Contabilidad;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Aplicacion.Contabilidad.ResponsabilidadTerceros;
using Aplicacion.Models.Contabilidad.ResponsabilidadTercero;
using ContabilidadWebAPI.Controllers;

namespace ContabilidadWebAPI.Controllers.Contabilidad;

[ApiController]
[Route("api/[controller]")]
public class ResponsabilidadTercerosController : MiControllerBase
{

    [HttpGet]
    public async Task<ActionResult<List<ResponsabilidadTerceroModel>>> Get()
    {
        return await Mediator.Send(new Consulta.ListarResponsabilidades());
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<ResponsabilidadTerceroModel>> GetId(int Id)
    {
        return await Mediator.Send(new ConsultaId.ConsultarId { Id = Id });
    }

    /* [HttpPost]
    public async Task<ActionResult<Unit>>Insertar(Insertar.Ejecuta data){
        return await Mediator.Send(data);
    } */

    /* [HttpPut]
    public async Task<ActionResult<Unit>>Editar(Editar.Ejecuta data){
        return await Mediator.Send(data);
    } */

    /* [HttpDelete("eliminar/{Id}")]
    public async Task<ActionResult<Unit>>Eliminar(int Id,Eliminar.Ejecuta data){
        data.Id = Id;
        return await Mediator.Send(data);
    } */
}