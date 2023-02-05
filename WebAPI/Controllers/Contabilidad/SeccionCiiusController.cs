namespace ContabilidadWebAPI.Controllers.Contabilidad;

[ApiController]
[Route("api/[controller]")]
public class SeccionCiiusController : MiControllerBase
{


    [HttpGet]
    public async Task<ActionResult<List<SeccionCiiusModel>>> Get()
    {
        return await Mediator.Send(new ListarSeccionCiiusRequest());
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<SeccionCiiusModel>> Detalle(int Id)
    {
        return await Mediator.Send(new ConsultarSeccionCiiuRequest { Id = Id });
    }
}