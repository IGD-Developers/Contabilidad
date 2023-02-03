using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dominio.Contabilidad;
using Aplicacion.Contabilidad.CentroCostos;
using Aplicacion.Models.Contabilidad.CentroCostos;

namespace WebAPI.Controllers.Contabilidad
{

    [ApiController]
    [Route("api/[controller]")]
    public class CentroCostosController : MiControllerBase
    {
       


        [HttpGet]
        public async Task<ActionResult<List<ListarCentroCostosModel>>> Get()
        {


            return await Mediator.Send(new Consulta.ListaCntCentroCostos());

        }

        [HttpGet("{id}")]

        public async Task<ActionResult<ListarCentroCostosModel>> GetId(int id)
        {

            return await Mediator.Send(new ConsultaId.ConsultaPorId { Id = id });
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
