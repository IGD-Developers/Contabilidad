using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Dominio.Contabilidad;
using Aplicacion.Contabilidad.Anos;

namespace WebAPI.Controllers.Contabilidad
{

    [ApiController]
    [Route("api/[controller]")]
    public class AnosController : MiControllerBase
    {
        // private readonly IMediator mediator;

        // public AnosController(IMediator mediator)
        // {
        //     this.mediator = mediator;
        // }
        

        [HttpGet]
        public async Task<ActionResult<List<CntAno>>> Get()
        {

            return await Mediator.Send(new Consulta.ListaCntAnos());

        }

        [HttpPost]

        public async Task<ActionResult<Unit>> Insertar(Insertar.Ejecuta data)
        {
            return await Mediator.Send(data);

        }
        


        

    }
}