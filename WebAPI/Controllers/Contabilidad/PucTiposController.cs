using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Aplicacion.Contabilidad.PucTipos;
using Dominio.Contabilidad;

namespace WebAPI.Controllers.Contabilidad
{

    [ApiController]
    [Route("api/[controller]")]

    public class PucTiposController : MiControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<List<CntPucTipo>>> Get()
        {

            return await Mediator.Send(new Consulta.ListaCntPucTipos());
        }


        [HttpGet("{Id}")]

        public async Task<ActionResult<CntPucTipo>> GetId(int Id)
        {

            return await Mediator.Send(new ConsultaId.ConsultarId { Id = Id });

        }

        [HttpPost]

        public async Task<ActionResult<Unit>> insertar(Insertar.Ejecuta data){

            return await Mediator.Send(data);


        }

        [HttpPut("{Id}")]

        public async Task<ActionResult<Unit>>  Editar(int Id, Editar.Ejecuta data) 
        
        {
            data.Id = Id;
            return await Mediator.Send(data);
        }



    }
}