namespace ContabilidadWebAPI.Controllers.Contabilidad;

[ApiController]
[Route("api/[controller]")]
public class ResponsabilidadesController : MiControllerBase
{

    [HttpGet]
    public async Task<ActionResult<List<ResponsabilidadModel>>> Get()
    {
        return await Mediator.Send(new ListarResponsabilidadesRequest());
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<ResponsabilidadModel>> GetId(int Id)
    {
        return await Mediator.Send(new ConsultarResponsabilidadRequest { Id = Id });

    }
}