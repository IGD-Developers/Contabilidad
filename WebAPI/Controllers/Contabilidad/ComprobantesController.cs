namespace ContabilidadWebAPI.Controllers.Contabilidad;

[ApiController]
[Route("api/[controller]")]
public class ComprobantesController : MiControllerBase
{

    [HttpGet]
    //<CntComprobante proviene de Dominio>
    public async Task<ActionResult<List<ListarComprobantesModel>>> Get()
    {

        return await Mediator.Send(new ListaCntComprobantesRequest());
    }

    [HttpGet("{Id}")]

    public async Task<ActionResult<ListarComprobantesModel>> GetId(int Id)
    {

        return await Mediator.Send(new ConsultarComprobanteRequest { Id = Id });


    }

    [HttpPost]

    public async Task<ActionResult<Unit>> Insertar(InsertarComprobanteRequest data)
    {
        data.IdModulo = 1;
        return await Mediator.Send(data);
    }


    [HttpPost("liquidaimpuesto")]


    public async Task<ActionResult<Unit>> LiquidaImpuesto(InsertarComprobanteRequest data)
    {
        data.IdModulo = 2;
        return await Mediator.Send(data);
    }



    [HttpPut("{Id}")]

    public async Task<ActionResult<Unit>> Editar(int Id, EditarComprobanteRequest data)

    {
        data.Id = Id;
        return await Mediator.Send(data);
    }

    [HttpPut("anular/{Id}")]

    public async Task<ActionResult<Unit>> Anular(int Id, AnularComprobanteRequest data)

    {
        data.Id = Id;
        return await Mediator.Send(data);
    }

    [HttpDelete("eliminar/{Id}")]

    public async Task<ActionResult<Unit>> Eliminar(int Id, EliminarComprobanteRequest data)

    {
        data.Id = Id;
        return await Mediator.Send(data);
    }



    [HttpPut("revertir/{Id}")]

    public async Task<ActionResult<Unit>> Revertir(int Id, RevertirComprobanteRequest data)

    {
        data.Id = Id;
        return await Mediator.Send(data);
    }
}