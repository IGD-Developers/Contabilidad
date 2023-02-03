using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Aplicacion.Contabilidad.Pucs;
//using Dominio.Contabilidad;
using System;
using Aplicacion.Models.Contabilidad.Pucs;

namespace WebAPI.Controllers.Contabilidad;


[ApiController]
[Route("api/[controller]")]

public class PucsController : MiControllerBase


{
    
    [HttpGet]

    public async Task<ActionResult<List<ListarPucModel>>> Get()
    {

        return await Mediator.Send(new Consulta.ListaCntPucs());
    }


    [HttpGet("{id}")]

    public async Task<ActionResult<ListarPucModel>> GetId(int id)
    {

        return await Mediator.Send(new ConsultaId.ConsultarId { Id = id });
    }

    [HttpPost]

    public async Task<ActionResult<Unit>> Insertar(Insertar.Ejecuta data) {

        return await Mediator.Send(data);
    }
    [HttpPut("{id}")]

    public async Task<ActionResult<Unit>>  Editar(int id, Editar.Ejecuta data) 
    
    {
        data.Id = id;
        return await Mediator.Send(data);
    }  

     [HttpDelete("{id}")]

    public async Task<ActionResult<Unit>>  Eliminar(int id) 
    
    {
         return await Mediator.Send(new Eliminar.Ejecuta{Id = id});
    }        

}