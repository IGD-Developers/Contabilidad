namespace ContabilidadWebAPI.Controllers.Contabilidad;

[ApiController]
[Route("api/[controller]")]
public class DepartamentosController : MiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<DepartamentosModel>>> Get()
    {
        return await Mediator.Send(new ListaDepartamentosRequest());
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<DepartamentosModel>> Detalle(int Id)
    {
        return await Mediator.Send(new ConsultarDepartamentoRequest{ Id = Id });
    }
}