using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Dominio.Contabilidad;
using Aplicacion.Contabilidad.Uvts;

namespace WebAPI.Controllers.Contabilidad;


[ApiController]
[Route("api/[controller]")]
public class UvtsController: MiControllerBase
{
    

    [HttpGet]

    public async Task<ActionResult<List<CntUvt>>>  Get() {
        return await Mediator.Send(new Consulta.ListaUvts());
     }


    [HttpPost]
    public async Task<ActionResult<Unit>>Insertar(Insertar.Ejecuta data){
        return await Mediator.Send(data);
    }

    [HttpPut]
    public async Task<ActionResult<Unit>>Editar(Editar.Ejecuta data){
        return await Mediator.Send(data);
    }

    [HttpPut("{id}")]

    public async Task<ActionResult<Unit>>  Editar(int id, Editar.Ejecuta data) 
    
    {
        data.Id = id;
        return await Mediator.Send(data);
    }

}