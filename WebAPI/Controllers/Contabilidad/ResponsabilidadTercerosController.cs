using System.Collections.Generic;
using System.Threading.Tasks;
using Dominio.Contabilidad;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Aplicacion.Contabilidad.ResponsabilidadTerceros;
using Aplicacion.Models.Contabilidad.ResponsabilidadTercero;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResponsabilidadTercerosController : MiControllerBase
    {       

        [HttpGet]
        public async Task<ActionResult<List<ResponsabilidadTerceroModel>>>Get(){
            return await Mediator.Send(new Consulta.ListarResponsabilidades());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponsabilidadTerceroModel>>GetId(int id){
            return await Mediator.Send(new ConsultaId.ConsultarId{Id = id});
        }

        /* [HttpPost]
        public async Task<ActionResult<Unit>>Insertar(Insertar.Ejecuta data){
            return await Mediator.Send(data);
        } */

        /* [HttpPut]
        public async Task<ActionResult<Unit>>Editar(Editar.Ejecuta data){
            return await Mediator.Send(data);
        } */

        /* [HttpDelete("eliminar/{id}")]
        public async Task<ActionResult<Unit>>Eliminar(int id,Eliminar.Ejecuta data){
            data.Id = id;
            return await Mediator.Send(data);
        } */
    }
}