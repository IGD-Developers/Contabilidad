using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using ContabilidadWebAPI.Dominio.Contabilidad;
using ContabilidadWebAPI.Controllers;
using ContabilidadWebAPI.Aplicacion.Contabilidad.CuentaImpuestos;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.CuentaImpuestos;

namespace ContabilidadWebAPI.Controllers.Contabilidad;


[ApiController]
[Route("api/[controller]")]
public class CuentaImpuestosController : MiControllerBase
{


    [HttpGet]
    public async Task<List<ListarCuentaImpuestosModel>> Get()
    {

        return await Mediator.Send(new Consulta.ListaCntCuentaImpuestos());

    }

    [HttpGet("{Id}")]

    public async Task<ActionResult<ListarCuentaImpuestosModel>> GetId(int Id)
    {
        return await Mediator.Send(new ConsultaId.ConsultarId { Id = Id });

    }

    // [HttpPost]

    // public async Task<ActionResult<Unit>> Insertar(Insertar.Ejecuta data) {

    //     return await Mediator.Send(data);

    // }


    // [HttpPut("{Id}")]

    // public async Task<ActionResult<Unit>>  Editar(int Id, Editar.Ejecuta data) 

    // {
    //     data.Id = Id;
    //     return await Mediator.Send(data);
    // }


}
