namespace ContabilidadWebAPI.ControllersDapper.Contabilidad.Pucs;



[ApiController]
[Route("api/[controller]")]
public class PucsDapperController : MiControllerBase
{

    [HttpGet]
    public async Task<ActionResult<List<PucRepositorioModel>>> ObtenerPucsDapper()
    {

        return await Mediator.Send(new ConsultarPucsDapperRequest());


    }

    [HttpPost]
    public async Task<ActionResult<Unit>> Insertar(InsertarPucsDapperRequest data)
    {

        return await Mediator.Send(data);
    }
}