using System.Collections.Generic;
using System.Threading.Tasks;
using ContabilidadWebAPI.Aplicacion.Contabilidad.Entidades;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Entidades;
using ContabilidadWebAPI.Controllers;
using ContabilidadWebAPI.Dominio.Contabilidad;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ContabilidadWebAPI.Controllers.Contabilidad;


[ApiController]
[Route("api/[controller]")]
public class EntidadesController : MiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<ListarEntidadesModel>>> Get()
    {
        return await Mediator.Send(new ListaCntEntidadesRequest());
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<ListarEntidadesModel>> GetId(int Id)
    {
        return await Mediator.Send(new ConsultarEntidadRequest { Id = Id });
    }

    [HttpGet("getfiltrotipo")]
    public async Task<ActionResult<List<ListarEntidadesModel>>> GetFiltroTipo(ConsultarEntidadTipoImpuesto data)
    {
        //var filtrado = new FiltroLiquidaImpuestosModel{IdSucursal=filtro.IdSucursal,FechaFinal=filtro.FechaFinal};

        return await Mediator.Send(data);
    }

    [HttpPost]
    public async Task<ActionResult<Unit>> Insertar(InsertarEntidadRequest data)
    {
        return await Mediator.Send(data);
    }

    [HttpPut("{Id}")]
    public async Task<ActionResult<Unit>> Editar(int Id, EditarEntidadRequest data)
    {
        data.Id = Id;
        return await Mediator.Send(data);
    }
}