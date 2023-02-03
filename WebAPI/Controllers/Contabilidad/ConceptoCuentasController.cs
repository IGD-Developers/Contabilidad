using MediatR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Aplicacion.Contabilidad.ConceptoCuentas;
using Dominio.Contabilidad;

namespace WebAPI.Controllers.Contabilidad
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConceptoCuentasController : MiControllerBase
    {
       

        [HttpGet]

        public async Task<ActionResult<List<CntConceptoCuenta>>> Get()
        {

            return await Mediator.Send(new Consulta.ListaCntConceptoCuentas());


        }

        [HttpGet("{id}")]

        public async Task<ActionResult<CntConceptoCuenta>> GetId(int id)
        {
            return await Mediator.Send(new ConsultaId.ConsultarId { Id = id });

        }

        [HttpPost]

        public async Task<ActionResult<Unit>>  Insertar(Insertar.Ejecuta data)
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
