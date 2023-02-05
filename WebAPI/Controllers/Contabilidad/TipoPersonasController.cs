namespace ContabilidadWebAPI.Controllers.Contabilidad;

[ApiController]
[Route("api/[controller]")]
public class TipoPersonasController : MiControllerBase
{


    [HttpGet]
    public async Task<ActionResult<List<TipoPersonaModel>>> Get()
    {
        return await Mediator.Send(new ListarTipoPersonasRequest());
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<TipoPersonaModel>> Detalle(int Id)
    {
        return await Mediator.Send(new ConsultarTipoPersonaRequest { Id = Id });
    }
}