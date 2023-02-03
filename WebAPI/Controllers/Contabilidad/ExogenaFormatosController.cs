using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Aplicacion.Contabilidad.ExogenaFormatos;
using Dominio.Contabilidad;

namespace WebAPI.Controllers.Contabilidad;


[ApiController]
[Route("api/[controller]")]
public class ExogenaFormatosController : MiControllerBase
{



    [HttpGet]
    public async Task<ActionResult<List<CntExogenaFormato>>> Get()
    {

        return await Mediator.Send(new Consulta.ListaCntExogenaFormatos());
    }

    [HttpGet("{id}")]

    public async Task<ActionResult<CntExogenaFormato>> GetId(int id)
    {
        return await Mediator.Send(new ConsultaId.ConsultarId { Id = id });
    }


    [HttpPost]

    public async Task<ActionResult<Unit>>  Insertar(Insertar.Ejecuta data)

    {

        return await Mediator.Send(data);
    }

    [HttpPut("{id}")]

    public async Task<ActionResult<Unit>>  Editar(int id, Editar.Ejecuta data) 
    
    {
        data.Id = id;
        return await Mediator.Send(data);
    }

}