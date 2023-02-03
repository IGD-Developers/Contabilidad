using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Persistencia;
using MediatR;
using System.Threading.Tasks;
using Aplicacion.Configuracion.Empresas;
using Dominio.Configuracion;
using Microsoft.AspNetCore.Authorization;
using Aplicacion.Models.Configuracion.Empresas;

namespace WebAPI.Controllers.Configuracion
{



    [ApiController]
    [Route("api/[controller]")]
    public class EmpresasController : MiControllerBase
    {
        // private readonly IMediator mediator;

        // public EmpresasController(IMediator _mediator)
        // {
        //     mediator = _mediator;
        // }
        [HttpGet]

        public async Task<ActionResult<List<ListarEmpresasModel>>> Get()
        {

            return await Mediator.Send(new Consulta.ListaCnfEmpresas());

        }

        [HttpGet("{Id}")]

        public async Task<ActionResult<ListarEmpresasModel>> GetId(int Id)
        {

            return await Mediator.Send(new ConsultaId.ConsultarId { Id = Id });
        }

        
    [HttpPost]

    public async Task<ActionResult<Unit>> Insertar(Insertar.Ejecuta data) {

        return await Mediator.Send(data);

    }

    [HttpPut("{Id}")]

        public async Task<ActionResult<Unit>>  Editar(int Id, Editar.Ejecuta data) 
        
        {
            data.Id = Id;
            return await Mediator.Send(data);
        }

    }

}