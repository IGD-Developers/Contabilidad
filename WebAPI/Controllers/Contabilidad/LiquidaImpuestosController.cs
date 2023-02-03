using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
//using MediatR;
using System.Threading.Tasks;
using Aplicacion.Contabilidad.LiquidaImpuestos;
using Aplicacion.Models.Contabilidad.LiquidaImpuestos;
using MediatR;


namespace WebAPI.Controllers.Contabilidad

{

    [ApiController]
    [Route("api/[controller]")]

    public class LiquidaImpuestosController : MiControllerBase
    {
        // [HttpGet]
        // public async Task<ActionResult<List<ListarLiquidaImpuestosModel>>> Get()
        // {
        //       System.Console.WriteLine("SIN parametros");
        //     return await Mediator.Send(new Consulta.ListaCntLiquidaImpuestos());
        // }



        [HttpGet("{id}")]

        public async Task<ActionResult<ListarLiquidaImpuestosModel>> GetId(int id)
        {

            return await Mediator.Send(new ConsultaId.ConsultarId { Id = id });

        }
       
       

        [HttpGet("getfiltro")]
        public async Task<ActionResult<List<ListarLiquidaImpuestosModel>>> GetFiltro(Consulta.ListaCntLiquidaImpuestos data)
        {
           
            return await Mediator.Send(data);

        }



        [HttpGet("getdata")]
        public async Task<ActionResult<List<ListarDetallesPreLiquidacionImpuestoModel>>> GetData(ConsultaPreLiquidacion.ConsultarPreLiquidacion data)
        {
           
            return await Mediator.Send(data);

        }
        
        // [HttpPost]

        // public async Task<ActionResult<Unit>> Insertar(Insertar.Ejecuta data)
        // {

        //     return await Mediator.Send(data);
        // }
        [HttpPut("{id}")]

        public async Task<ActionResult<Unit>> Editar(int id, Editar.Ejecuta data)

        {
            data.Id = id;
            return await Mediator.Send(data);
        }

    }
}