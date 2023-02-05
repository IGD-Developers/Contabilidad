namespace ContabilidadWebAPI.Controllers.Contabilidad;


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

        return await Mediator.Send(new ListaCntAnosRequest());

    }

    [HttpPost]

    public async Task<ActionResult<Unit>> Insertar(InsertarAnoRequest data)
    {
        return await Mediator.Send(data);

    }
    


    

}