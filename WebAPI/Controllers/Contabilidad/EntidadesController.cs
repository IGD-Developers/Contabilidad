using System.Collections.Generic;
using System.Threading.Tasks;
using Aplicacion.Contabilidad.Entidades;
using Aplicacion.Models.Contabilidad.Entidades;
using Dominio.Contabilidad;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Contabilidad
{

    [ApiController]
    [Route("api/[controller]")]
    public class EntidadesController : MiControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<List<ListarEntidadesModel>>> Get()
        {

            return await Mediator.Send(new Consulta.ListaCntEntidades());
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<ListarEntidadesModel>> GetId(int id)
        {

            return await Mediator.Send(new ConsultaId.ConsultarId { Id = id });

        }


[HttpGet("getfiltrotipo")]
        public async Task<ActionResult<List<ListarEntidadesModel>>>  GetFiltroTipo(ConsultaEntidadTipoImpuesto.ConsultarEntidadTipoImpuesto data)
        {
            //var filtrado = new FiltroLiquidaImpuestosModel{id_sucursal=filtro.id_sucursal,fechafinal=filtro.fechafinal};
           
            return await Mediator.Send(data);

        }

        [HttpPost]

        public async Task<ActionResult<Unit>> Insertar(Insertar.Ejecuta data)
        {

            return await Mediator.Send(data);
        }
        [HttpPut("{id}")]

        public async Task<ActionResult<Unit>> Editar(int id, Editar.Ejecuta data)

        {
            data.Id = id;
            return await Mediator.Send(data);
        }


    }
}