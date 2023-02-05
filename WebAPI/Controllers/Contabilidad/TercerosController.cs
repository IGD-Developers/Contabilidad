using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContabilidadWebAPI.Dominio.Contabilidad;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ContabilidadWebAPI.Persistencia;
using ContabilidadWebAPI.Controllers;
using ContabilidadWebAPI.Aplicacion.Contabilidad.Terceros;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Tercero;
//using ContabilidadWebAPI.Aplicacion.Contabilidad.juridico;
//using ContabilidadWebAPI.Aplicacion.Contabilidad.Terceros.Natural;

namespace ContabilidadWebAPI.Controllers.Contabilidad;

[ApiController]
[Route("api/[controller]")]
public class TercerosController : MiControllerBase
{

    [HttpGet]
    public async Task<ActionResult<List<ListarTerceroModel>>> Get()
    {
        return await Mediator.Send(new ListarTercerosRequest());
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<ListarTerceroModel>> Detalle(int Id)
    {
        return await Mediator.Send(new ConsultarTerceroRequest { Id = Id });
    }

    [HttpPost]
    //[Route("Tercero")]
    public async Task<ActionResult<Unit>> Insertar(InsertarTerceroRequest data)
    {
        return await Mediator.Send(data);
    }

    [HttpPost]
    [Route("insertarJuridico")]
    public async Task<ActionResult<Unit>> InsertarJuridico(InsertarJuridicoRequest data)
    {
        return await Mediator.Send(data);
    }

    [HttpPut("editar/{Id}")]
    public async Task<ActionResult<Unit>> Editar(int Id, EditarTerceroRequest data)
    {

        data.Id = Id;
        return await Mediator.Send(data);
    }

    [HttpPut]
    [Route("editarJuridico/{Id}")]
    public async Task<ActionResult<Unit>> EditarJuridico(int Id, EditarJuridicoRequest data)
    {
        data.Id = Id;
        return await Mediator.Send(data);
    }


    [HttpDelete("eliminar/{Id}")]
    public async Task<ActionResult<Unit>> Eliminar(int Id, EliminarTerceroRequest data)
    {
        data.Id = Id;
        return await Mediator.Send(data);
    }





}