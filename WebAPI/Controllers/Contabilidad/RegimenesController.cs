using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Contabilidad.Regimenes;
using Aplicacion.Models.Contabilidad.Regimen;
using Dominio.Contabilidad;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistencia;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegimenesController : MiControllerBase
    {
        
        [HttpGet]
        public async Task<ActionResult<List<RegimenModel>>>Get(){
            return await Mediator.Send(new Consulta.ListarRegimenes());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RegimenModel>>Detalle(int id){
            return await Mediator.Send(new ConsultaId.ConsultarId{Id = id});
        }
        
    }
}