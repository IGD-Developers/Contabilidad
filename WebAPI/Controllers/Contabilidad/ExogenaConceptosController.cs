using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Aplicacion.Contabilidad.ExogenaConceptos;
using Dominio.Contabilidad;

namespace WebAPI.Controllers.Contabilidad
{

    [ApiController]
    [Route("api/[controller]")]
    public class ExogenaConceptosController : MiControllerBase
    {

 

        [HttpGet]

        public async Task<ActionResult<List<CntExogenaConcepto>>> Get()
        {

            return await Mediator.Send(new Consulta.ListaCntExogenaConceptos());
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<CntExogenaConcepto>> GetId(int id)
        {
            return await Mediator.Send(new ConsultaId.ConsultarId { Id = id });

        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Insertar(Insertar.Ejecuta data)
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
}