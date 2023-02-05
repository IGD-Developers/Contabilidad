namespace ContabilidadWebAPI.Controllers.Contabilidad;

[ApiController]
[Route("api/[controller]")]
public class FormatoConceptosController : MiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<CntFormatoConcepto>>> Get()
    {
        return await Mediator.Send(new ListaCntFormatoConceptosRequest());
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<CntFormatoConcepto>> GetId(int Id)
    {
        return await Mediator.Send(new ConsultarFormatoConceptoRequest { Id = Id });
    }

    [HttpPost]
    public async Task<ActionResult<Unit>> Insertar(InsertarFormatoConceptoRequest data)
    {
        return await Mediator.Send(data);
    }

    [HttpPut("{Id}")]
    public async Task<ActionResult<Unit>> Editar(int Id, EditarFormatoConceptoRequest data)
    {
        data.Id = Id;
        return await Mediator.Send(data);
    }
}