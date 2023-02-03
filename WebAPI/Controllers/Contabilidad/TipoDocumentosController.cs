using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Contabilidad.TipoDocumentos;
using Aplicacion.Models.Contabilidad.TipoDocumento;
using Dominio.Contabilidad;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistencia;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoDocumentosController : MiControllerBase
    {
     

        //http://localhost:5000/api/CntTipoDocumentos
        [HttpGet]
        public async Task<ActionResult<List<TipoDocumentoModel>>> Get(){
            return await Mediator.Send(new Consulta.ListaTipoDocumentos());
        }

        //http://localhost:5000/api/CntTipoDocumentos/1
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoDocumentoModel>> Get(int id){
            return await Mediator.Send(new ConsultaId.ConsultarTipoDocumentoId{Id = id});
        }
    }
}