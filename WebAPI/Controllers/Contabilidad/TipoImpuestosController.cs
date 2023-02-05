using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Controllers;
using ContabilidadWebAPI.Aplicacion.Contabilidad.TipoImpuestos;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.TipoImpuestos;
using ContabilidadWebAPI.Aplicacion.Contabilidad.TipoOperaciones;

namespace ContabilidadWebAPI.Controllers.Contabilidad;


[ApiController]
[Route("api/[controller]")]

public class TipoImpuestosController : MiControllerBase
{


    [HttpGet]


    public async Task<ActionResult<List<ListarTipoImpuestosModel>>> Get()
    {

        return await Mediator.Send(new ListaCntTipoImpuestosRequest());



    }

    [HttpGet("{Id}")]

    public async Task<ActionResult<ListarTipoImpuestosModel>> GetId(int Id)
    {

        return await Mediator.Send(new ConsultarTipoImpuestoRequest { Id = Id });
    }

    [HttpPost]

    public async Task<ActionResult<Unit>> Insertar(InsertarTipoImpuestoRequest data)
    {
        return await Mediator.Send(data);
    }

    [HttpPut("{Id}")]

    public async Task<ActionResult<Unit>> Editar(int Id, EditarTipoImpuestoRequest data)

    {
        data.Id = Id;
        return await Mediator.Send(data);
    }



}