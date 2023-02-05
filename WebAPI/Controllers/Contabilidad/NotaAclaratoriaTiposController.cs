namespace ContabilidadWebAPI.Controllers.Contabilidad;


[ApiController]
[Route("api/[controller]")]

public class NotaAclaratoriaTiposController : MiControllerBase
{


    [HttpGet]
    public async Task<ActionResult<List<NotaAclaratoriaTipoModel>>> Get()
    {
        return await Mediator.Send(new ListaCntNotaAclaratoriaTiposRequest());
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<CntNotaAclaratoriaTipo>> GetId(int Id)
    {
        return await Mediator.Send(new ConsultarNotaAclaratoriaTipoRequest { Id = Id });
    }

    [HttpPost]
    public async Task<ActionResult<Unit>> Insertar(InsertarNotaAclaratoriaTipoRequest dato)
    {
        return await Mediator.Send(dato);
    }

    [HttpPut]
    public async Task<ActionResult<Unit>> Editar(EditarNotaAclaratoriaTipoRequest dato)
    {
        return await Mediator.Send(dato);
    }

}