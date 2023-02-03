using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Aplicacion.Contabilidad.FormatoConceptos;
using Dominio.Contabilidad;

namespace WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class FormatoConceptosController: MiControllerBase
    {

       
        [HttpGet]
        public async Task<ActionResult<List<CntFormatoConcepto>>> Get() {

            return await Mediator.Send(new Consulta.ListaCntFormatoConceptos());
           
        }
        [HttpGet("{id}")]

        public async Task<ActionResult<CntFormatoConcepto>> GetId(int id) {
            return await Mediator.Send(new ConsultaId.ConsultarId{Id=id});
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