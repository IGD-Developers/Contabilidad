namespace ContabilidadWebAPI.Controllers.Contabilidad;

[ApiController]
[Route("api/[controller]")]
public class TipoComprobantesController : MiControllerBase
{


    [HttpGet]
    public async Task<ActionResult<List<ListarTipoComprobanteModel>>> Get()
    {

        return await Mediator.Send(new ListaCntTipoComprobantesRequest());

    }

    //http://localhost:5000/api/CntTipoComprobantes/{1}

    [HttpGet("{Id}")]

    public async Task<ActionResult<ListarTipoComprobanteModel>> GetId(int Id)
    {

        return await Mediator.Send(new ConsultarTipoComprobanteRequest { Id = Id });

    }


    [HttpPost]

    public async Task<ActionResult<Unit>> Insertar(InsertarTipoComprobanteRequest data)
    {

        return await Mediator.Send(data);


    }

    [HttpPut("{Id}")]

    public async Task<ActionResult<Unit>> Editar(int Id, EditarTipoComprobanteRequest data)

    {
        data.Id = Id;
        return await Mediator.Send(data);
    }



}