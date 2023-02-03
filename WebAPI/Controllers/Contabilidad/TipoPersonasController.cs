using System.Collections.Generic;
using System.Linq;
using Dominio.Contabilidad;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistencia;
using Aplicacion.Contabilidad.TipoPersonas;
using System.Threading.Tasks;
using Aplicacion.Models.Contabilidad.TipoPersona;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoPersonasController : MiControllerBase
    {
       

        [HttpGet]
        public async Task<ActionResult<List<TipoPersonaModel>>>Get(){
            return await Mediator.Send(new Consulta.ListarTipoPersonas());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoPersonaModel>>Detalle(int id){
            return await Mediator.Send(new ConsultaId.ConsultarId{Id = id});
        }
    }
}