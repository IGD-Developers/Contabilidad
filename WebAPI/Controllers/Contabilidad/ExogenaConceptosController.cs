namespace ContabilidadWebAPI.Controllers.Contabilidad;


[ApiController]
[Route("api/[controller]")]
public class ExogenaConceptosController : MiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<CntExogenaConcepto>>> Get()
    {
        return await Mediator.Send(new ListaCntExogenaConceptosRequest());
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<CntExogenaConcepto>> GetId(int Id)
    {
        return await Mediator.Send(new ConsultarExogenaConceptoRequest { Id = Id });
    }

    [HttpPost]
    public async Task<ActionResult<Unit>> Insertar(InsertarExogenaConceptoRequest data)
    {
        return await Mediator.Send(data);
    }

    [HttpPut("{Id}")]
    public async Task<ActionResult<Unit>> Editar(int Id, EditarExogenaConceptoRequest data)
    {
        data.Id = Id;
        return await Mediator.Send(data);
    }
}