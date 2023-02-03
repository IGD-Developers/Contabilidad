using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Contabilidad;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistencia;
using Aplicacion.Contabilidad.Terceros;
using Aplicacion.Models.Contabilidad.Tercero;
//using Aplicacion.Contabilidad.juridico;
//using Aplicacion.Contabilidad.Terceros.Natural;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TercerosController : MiControllerBase
{
   
    [HttpGet]
    public async Task<ActionResult<List<ListarTerceroModel>>>Get(){
        return await Mediator.Send(new Consulta.ListarTerceros());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ListarTerceroModel>>Detalle(int id){
        return await Mediator.Send(new ConsultaId.TerceroId{Id = id});
    }

    [HttpPost]
    //[Route("tercero")]
    public async Task<ActionResult<Unit>>Insertar(Insertar.Ejecuta data){
        return await Mediator.Send(data);
    }

    [HttpPost]
    [Route("insertarJuridico")]
    public async Task<ActionResult<Unit>>InsertarJuridico(InsertarJuridico.Ejecuta data){
        return await Mediator.Send(data);
    }

    [HttpPut("editar/{id}")]
    public async Task<ActionResult<Unit>>Editar(int id, Editar.Ejecuta data){
        
        data.Id = id;
        return await Mediator.Send(data);
    }

    [HttpPut]
    [Route("editarJuridico/{id}")]
    public async Task<ActionResult<Unit>>EditarJuridico(int id,EditarJuridico.Ejecuta data){
        data.Id = id;
        return await Mediator.Send(data);
    }


    [HttpDelete("eliminar/{id}")]
    public async Task<ActionResult<Unit>>  Eliminar(int id, Eliminar.Ejecuta data) 
    {
        data.Id = id;
        return await Mediator.Send(data);
    }

   

    

}