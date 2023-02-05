namespace ContabilidadWebAPI.Controllers.Contabilidad;

[ApiController]
[Route("api/[controller]")]
public class CiiusController : MiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<CiiuModel>>> Get()
    {
        return await Mediator.Send(new ListaCiiusRequest());
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<CiiuModel>> Detalle(int Id)
    {
        return await Mediator.Send(new ConsultarCiiuRequest { Id = Id });
    }
}