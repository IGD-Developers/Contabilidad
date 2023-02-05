namespace ContabilidadWebAPI.Controllers.Contabilidad;

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

        return await Mediator.Send(new ListaCntCategoriaComprobantesRequest());



    }

    [HttpGet("{Id}")]
    //https://localhost:5000/api/CntCategoriaComprobantes/{Id}
    //https://localhost:5000/api/CntCategoriaComprobantes/1

    public async Task<ActionResult<ListarCategoriaComprobantesModel>> GetId(int Id)
    {

        return await Mediator.Send(new ConsultarCategoriaComprobanteRequest { Id = Id });

    }


    [HttpPost]

    public async Task<ActionResult<Unit>> Insertar(InsertarCategoriaComprobanteRequest data)
    {

        return await Mediator.Send(data);

    }

    [HttpPut("{Id}")]

    public async Task<ActionResult<Unit>> Editar(int Id, EditarCategoriaComprobanteRequest data)

    {
        data.Id = Id;
        return await Mediator.Send(data);
    }


}

