using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Aplicacion.Contabilidad.TipoCuentas;
using Dominio.Contabilidad;

namespace WebAPI.Controllers.Contabilidad
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoCuentasController : MiControllerBase
    {


        [HttpGet]

        public async Task<ActionResult<List<CntTipoCuenta>>> Get()
        {

            return await Mediator.Send(new Consulta.ListaCntTipoCuentas());
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<CntTipoCuenta>> GetId(int id)
        {

            return await Mediator.Send(new ConsultaId.ConsultarId { Id = id });

        }

        [HttpPost]

        public async Task<ActionResult<Unit>> Insertar(Insertar.Ejecuta data) {

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