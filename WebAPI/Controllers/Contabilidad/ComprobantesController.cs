using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using Aplicacion.Contabilidad.Comprobantes;
using Dominio.Contabilidad;
using Aplicacion.Models.Contabilidad.Comprobantes;

namespace WebAPI.Controllers.Contabilidad
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComprobantesController : MiControllerBase
    {
        
        [HttpGet]
        //<CntComprobante proviene de Dominio>
        public async Task<ActionResult<List<ListarComprobantesModel>>> Get()
        {

            return await Mediator.Send(new Consulta.ListaCntComprobantes());
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<ListarComprobantesModel>> GetId(int id)
        {

            return await Mediator.Send(new ConsultaId.ConsultarId { Id = id });


        }

        [HttpPost]

        public async Task<ActionResult<Unit>> Insertar(Insertar.Ejecuta data)
        {
            data.id_modulo=1;
            return await Mediator.Send(data);
        }
 
 
        [HttpPost("liquidaimpuesto")]
         

        public async Task<ActionResult<Unit>> LiquidaImpuesto(Insertar.Ejecuta data)
        {
            data.id_modulo=2;
            return await Mediator.Send(data);
        }



        [HttpPut("{id}")]

        public async Task<ActionResult<Unit>>  Editar(int id, Editar.Ejecuta data) 
        
        {
            data.Id = id;
            return await Mediator.Send(data);
        }

         [HttpPut("anular/{id}")]

        public async Task<ActionResult<Unit>>  Anular(int id, Anular.Ejecuta data) 
        
        {
            data.Id = id;
            return await Mediator.Send(data);
        }

        [HttpDelete("eliminar/{id}")]

        public async Task<ActionResult<Unit>>  Eliminar(int id, Eliminar.Ejecuta data) 
        
        {
            data.Id = id;
            return await Mediator.Send(data);
        }



        [HttpPut("revertir/{id}")]

        public async Task<ActionResult<Unit>>  Revertir(int id, Revertir.Ejecuta data) 
        
        {
            data.Id = id;
            return await Mediator.Send(data);
            
        }


    }



    }
