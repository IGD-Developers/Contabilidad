namespace ContabilidadWebAPI.Controllers.Contabilidad;

[ApiController]
[Route("api/[controller]")]
public class TipoCiiusController : MiControllerBase
{


    [HttpGet]
    public async Task<ActionResult<List<TipoCiiusModel>>> Get()
    {
        return await Mediator.Send(new ListarTipoCiiusRequest());
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<TipoCiiusModel>> Detalle(int Id)
    {
        return await Mediator.Send(new ConsultarTipoCiiuRequest { Id = Id });
    }
}