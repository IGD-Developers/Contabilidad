using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Aplicacion.Contabilidad.TipoImpuestos;
using Dominio.Contabilidad;
using Aplicacion.Models.Contabilidad.TipoImpuestos;
using ContabilidadWebAPI.Controllers;

namespace ContabilidadWebAPI.Controllers.Contabilidad;


[ApiController]
[Route("api/[controller]")]

public class TipoImpuestosController : MiControllerBase
{


    [HttpGet]


    public async Task<ActionResult<List<ListarTipoImpuestosModel>>> Get()
    {

        return await Mediator.Send(new Consulta.ListaCntTipoImpuestos());



    }

    [HttpGet("{Id}")]

    public async Task<ActionResult<ListarTipoImpuestosModel>> GetId(int Id)
    {

        return await Mediator.Send(new ConsultaId.ConsultarId { Id = Id });
    }

    [HttpPost]

    public async Task<ActionResult<Unit>> Insertar(Insertar.Ejecuta data)
    {
        return await Mediator.Send(data);
    }

    [HttpPut("{Id}")]

    public async Task<ActionResult<Unit>> Editar(int Id, Editar.Ejecuta data)

    {
        data.Id = Id;
        return await Mediator.Send(data);
    }



}