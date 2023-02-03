
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Aplicacion.Contabilidad.NotaAclaratoriaTipos;
using Dominio.Contabilidad;
using Aplicacion.Models.Contabilidad.NotaAclaratoriaTipo;

namespace WebAPI.Controllers.Contabilidad
{

    [ApiController]
    [Route("api/[controller]")]

    public class NotaAclaratoriaTiposController : MiControllerBase
    {


        [HttpGet]
        public async Task<ActionResult<List<NotaAclaratoriaTipoModel>>> Get()
        {
            return await Mediator.Send(new Consulta.ListaCntNotaAclaratoriaTipos());
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<CntNotaAclaratoriaTipo>> GetId(int Id)
        {
            return await Mediator.Send(new ConsultaId.ConsultarId { Id = Id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Insertar(Insertar.Ejecuta dato)
        {
            return await Mediator.Send(dato);
        }

        [HttpPut]
        public async Task<ActionResult<Unit>> Editar(Editar.Ejecuta dato){
            return await Mediator.Send(dato);
        }

    }
}