using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Aplicacion.Contabilidad.Pucs;
//using Dominio.Contabilidad;
using System;
using Aplicacion.Models.Contabilidad.Pucs;

namespace WebAPI.Controllers.Contabilidad
{

    [ApiController]
    [Route("api/[controller]")]

    public class PucsController : MiControllerBase


    {
        
        [HttpGet]

        public async Task<ActionResult<List<ListarPucModel>>> Get()
        {

            return await Mediator.Send(new Consulta.ListaCntPucs());
        }


        [HttpGet("{Id}")]

        public async Task<ActionResult<ListarPucModel>> GetId(int Id)
        {

            return await Mediator.Send(new ConsultaId.ConsultarId { Id = Id });
        }

        [HttpPost]

        public async Task<ActionResult<Unit>> Insertar(Insertar.Ejecuta data) {

            return await Mediator.Send(data);
        }
        [HttpPut("{Id}")]

        public async Task<ActionResult<Unit>>  Editar(int Id, Editar.Ejecuta data) 
        
        {
            data.Id = Id;
            return await Mediator.Send(data);
        }  

         [HttpDelete("{Id}")]

        public async Task<ActionResult<Unit>>  Eliminar(int Id) 
        
        {
             return await Mediator.Send(new Eliminar.Ejecuta{Id = Id});
        }        

    }
}