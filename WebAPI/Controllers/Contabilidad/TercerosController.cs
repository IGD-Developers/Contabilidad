using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Contabilidad;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistencia;
using Aplicacion.Contabilidad.Terceros;
using Aplicacion.Models.Contabilidad.Tercero;
//using Aplicacion.Contabilidad.juridico;
//using Aplicacion.Contabilidad.Terceros.Natural;

namespace WebAPI.Controllers
{
[ApiController]
[Route("api/[controller]")]
    public class TercerosController : MiControllerBase
    {
       
        [HttpGet]
        public async Task<ActionResult<List<ListarTerceroModel>>>Get(){
            return await Mediator.Send(new Consulta.ListarTerceros());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<ListarTerceroModel>>Detalle(int Id){
            return await Mediator.Send(new ConsultaId.TerceroId{Id = Id});
        }

        [HttpPost]
        //[Route("Tercero")]
        public async Task<ActionResult<Unit>>Insertar(Insertar.Ejecuta data){
            return await Mediator.Send(data);
        }

        [HttpPost]
        [Route("insertarJuridico")]
        public async Task<ActionResult<Unit>>InsertarJuridico(InsertarJuridico.Ejecuta data){
            return await Mediator.Send(data);
        }

        [HttpPut("editar/{Id}")]
        public async Task<ActionResult<Unit>>Editar(int Id, Editar.Ejecuta data){
            
            data.Id = Id;
            return await Mediator.Send(data);
        }

        [HttpPut]
        [Route("editarJuridico/{Id}")]
        public async Task<ActionResult<Unit>>EditarJuridico(int Id,EditarJuridico.Ejecuta data){
            data.Id = Id;
            return await Mediator.Send(data);
        }


        [HttpDelete("eliminar/{Id}")]
        public async Task<ActionResult<Unit>>  Eliminar(int Id, Eliminar.Ejecuta data) 
        {
            data.Id = Id;
            return await Mediator.Send(data);
        }

       

        

    }
}