using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Contabilidad;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistencia;
using Aplicacion.Contabilidad.SeccionCiius;
using Aplicacion.Models.Contabilidad.SeccionCiius;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeccionCiiusController : MiControllerBase
    {
     

        [HttpGet]
        public async Task<ActionResult<List<SeccionCiiusModel>>>Get(){
            return await Mediator.Send(new Consulta.ListarSeccionCiius());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SeccionCiiusModel>>Detalle(int id){
            return await Mediator.Send(new ConsultaId.ConsultarId{Id = id});
        }
    }
}