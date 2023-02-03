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

    [HttpGet("{Id}")]

    public async Task<ActionResult<CntExogenaFormato>> GetId(int Id)
    {
        return await Mediator.Send(new ConsultaId.ConsultarId { Id = Id });
    }


    [HttpPost]

    public async Task<ActionResult<Unit>>  Insertar(Insertar.Ejecuta data)

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