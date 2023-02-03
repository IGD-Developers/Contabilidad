using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Persistencia;
using MediatR;
using System.Threading.Tasks;
using Dominio.Contabilidad;
using Aplicacion.Contabilidad.CategoriaComprobantes;
using Microsoft.AspNetCore.Authorization;
using Aplicacion.Models.Contabilidad.CategoriaComprobantes;

namespace WebAPI.Controllers.Contabilidad
{
    [ApiController]
    [Route("api/[controller]")]


    public class CategoriaComprobantesController : MiControllerBase
    {


        // private readonly IMediator mediator;

        // public CategoriaComprobantesController(IMediator _mediator)
        // {
        //     mediator = _mediator;
        // }

        [HttpGet]
       // [Authorize]

        public async Task<ActionResult<List<ListarCategoriaComprobantesModel>>> Get()
        {

            return await Mediator.Send(new Consulta.ListaCntCategoriaComprobantes());



        }

        [HttpGet("{Id}")]
        //https://localhost:5000/api/CntCategoriaComprobantes/{Id}
        //https://localhost:5000/api/CntCategoriaComprobantes/1

        public async Task<ActionResult<ListarCategoriaComprobantesModel>> GetId(int Id)
        {

            return await Mediator.Send(new ConsultaId.ConsultarId { Id = Id });

        }


        [HttpPost]

        public async Task<ActionResult<Unit>> Insertar(Insertar.Ejecuta data)
        {

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
    
