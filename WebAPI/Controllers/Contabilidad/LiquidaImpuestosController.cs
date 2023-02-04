using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
//using MediatR;
using System.Threading.Tasks;
using MediatR;
using ContabilidadWebAPI.Controllers;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.LiquidaImpuestos;
using ContabilidadWebAPI.Aplicacion.Contabilidad.LiquidaImpuestos;

namespace ContabilidadWebAPI.Controllers.Contabilidad;



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



    [HttpGet("{Id}")]

    public async Task<ActionResult<ListarLiquidaImpuestosModel>> GetId(int Id)
    {

        return await Mediator.Send(new ConsultaId.ConsultarId { Id = Id });

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
    [HttpPut("{Id}")]

    public async Task<ActionResult<Unit>> Editar(int Id, Editar.Ejecuta data)

    {
        data.Id = Id;
        return await Mediator.Send(data);
    }

}