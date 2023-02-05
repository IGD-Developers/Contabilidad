namespace ContabilidadWebAPI.Controllers.Contabilidad;

[ApiController]
[Route("api/[controller]")]
public class RegimenesController : MiControllerBase
{

    [HttpGet]
    public async Task<ActionResult<List<RegimenModel>>> Get()
    {
        return await Mediator.Send(new ListarRegimenesRequest());
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<RegimenModel>> Detalle(int Id)
    {
        return await Mediator.Send(new ConsultarRegimenRequest { Id = Id });
    }

}