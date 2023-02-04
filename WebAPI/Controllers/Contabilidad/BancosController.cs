using System.Collections.Generic;
using System.Threading.Tasks;
using ContabilidadWebAPI.Aplicacion.Contabilidad.Bancos;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Bancos;
using ContabilidadWebAPI.Controllers;
using ContabilidadWebAPI.Dominio.Contabilidad;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ContabilidadWebAPI.Controllers.Contabilidad;


[ApiController]
[Route("api/[controller]")]
public class BancosController : MiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<ListarBancosModel>>> Get()
    {
        return await Mediator.Send(new Consulta.ListaCntBancos());
    }



    [HttpGet("{Id}")]
    
    public async Task<ActionResult<ListarBancosModel>> GetId(int Id)
    {

        return await Mediator.Send(new ConsultaId.ConsultarId { Id = Id });

    }
    
    [HttpPost]

    public async Task<ActionResult<Unit>> Insertar(Insertar.Ejecuta data)
    {

        return await Mediator.Send(data);

    }

[HttpPut("{Id}")]

    public async Task<ActionResult<Unit>>  Editar(int Id, Editar.Ejecuta data) 
    
    {
        data.Id = Id;
        return await Mediator.Send(data);
    }


}