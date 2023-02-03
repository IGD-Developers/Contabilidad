
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Aplicacion.Contabilidad.Meses;
using Dominio.Contabilidad;

namespace WebAPI.Controllers.Contabilidad
{

    [ApiController]
    [Route("api/[controller]")]
    public class MesesController : MiControllerBase
    {
    [HttpGet]
        public async Task<ActionResult<List<CntMes>>> Get()
        {

            return await Mediator.Send(new Consulta.ListaCntMeses());

        }

        [HttpPost]
        public async Task<ActionResult<Unit>>Insertar(Insertar.Ejecuta data){
            return await Mediator.Send(data);
        }

        // [HttpPut]
        // public async Task<ActionResult<Unit>>Editar(Editar.Ejecuta data){
        //     return await Mediator.Send(data);
        // }

        [HttpPut("{id}")]

        public async Task<ActionResult<Unit>>  Editar(int id, Editar.Ejecuta data) 
        
        {
            data.Id = id;
            return await Mediator.Send(data);
        }
    }
}