using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Aplicacion.Contabilidad.NotaAclaratorias;
using Dominio.Contabilidad;
using Aplicacion.Models.Contabilidad.NotaAclaratoria;

namespace WebAPI.Controllers.Contabilidad
{

    [ApiController]
    [Route("api/[controller]")]
    public class NotaAclaratoriasController : MiControllerBase
    {
        
        [HttpGet]
        public async Task<ActionResult<List<ListarNotaAclaratoriaModel>>> Get()
        {

            return await Mediator.Send(new Consulta.ListaCntNotaAclaratorias());

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ListarNotaAclaratoriaModel>> GetId(int Id)
        {
            return await Mediator.Send(new ConsultaId.ConsultarId { Id = Id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>>Insertar(Insertar.Ejecuta data){
            return await Mediator.Send(data);
        }

        [HttpPut("editar/{id}")]
        public async Task<ActionResult<Unit>>Editar(int id, Editar.Ejecuta data){
            data.ID = id;
            return await Mediator.Send(data);
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<ActionResult<Unit>>Eliminar(int id, Eliminar.Ejecuta data){
            data.ID = id;
            return await Mediator.Send(data);

        }

        [HttpPut("cambiarestado/{id}")]
        public async Task<ActionResult<Unit>>CambiarEstado(int id, ActivarInactivar.Ejecuta data){
            data.ID = id;
            return await Mediator.Send(data);
        }




    }
}
//instanciar
