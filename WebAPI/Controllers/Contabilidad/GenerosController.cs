using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Contabilidad.Generos;
using Aplicacion.Models.Contabilidad.Genero;
using Dominio.Contabilidad;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistencia;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenerosController : MiControllerBase
    {
        //http://localhost:5000/api/CntGeneros
        [HttpGet]
        public async Task<ActionResult<List<GeneroModel>>>Get(){
            return await Mediator.Send(new Consulta.ListaGeneros());
        }


        [HttpGet("{Id}")]
        public async Task<ActionResult<GeneroModel>>Detalle(int Id){
            return await Mediator.Send(new ConsultaId.ConsultarId{Id = Id});
        }      
    }
}