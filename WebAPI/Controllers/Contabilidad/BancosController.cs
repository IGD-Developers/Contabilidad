using System.Collections.Generic;
using System.Threading.Tasks;
using Aplicacion.Contabilidad.Bancos;
using Aplicacion.Models.Contabilidad.Bancos;
using Dominio.Contabilidad;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Contabilidad
{

    [ApiController]
    [Route("api/[controller]")]
    public class BancosController : MiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<ListarBancosModel>>> Get()
        {
            return await Mediator.Send(new Consulta.ListaCntBancos());
        }



        [HttpGet("{id}")]
        
        public async Task<ActionResult<ListarBancosModel>> GetId(int id)
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