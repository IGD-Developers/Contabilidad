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

        return await Mediator.Send(new ConsultarLiquidaImpuestoRequest { Id = Id });

    }



    [HttpGet("getfiltro")]
    public async Task<ActionResult<List<ListarLiquidaImpuestosModel>>> GetFiltro(ListaCntLiquidaImpuestosRequest data)
    {

        return await Mediator.Send(data);

    }



    [HttpGet("getdata")]
    public async Task<ActionResult<List<ListarDetallesPreLiquidacionImpuestoModel>>> GetData(ConsultarPreLiquidacionRequest data)
    {

        return await Mediator.Send(data);

    }

    // [HttpPost]

    // public async Task<ActionResult<Unit>> Insertar(Insertar.ActivarInactivarNotaAclaratoriaRequest data)
    // {

    //     return await Mediator.Send(data);
    // }
    [HttpPut("{Id}")]

    public async Task<ActionResult<Unit>> Editar(int Id, EditarLiquidaImpuestoRequest data)

    {
        data.Id = Id;
        return await Mediator.Send(data);
    }

}