namespace ContabilidadWebAPI.Controllers.Contabilidad;

[ApiController]
[Route("api/[controller]")]
public class TipoDocumentosController : MiControllerBase
{


    //http://localhost:5000/api/CntTipoDocumentos
    [HttpGet]
    public async Task<ActionResult<List<TipoDocumentoModel>>> Get()
    {
        return await Mediator.Send(new ListaTipoDocumentosRequest());
    }

    //http://localhost:5000/api/CntTipoDocumentos/1
    [HttpGet("{Id}")]
    public async Task<ActionResult<TipoDocumentoModel>> Get(int Id)
    {
        return await Mediator.Send(new ConsultarTipoDocumentoRequest { Id = Id });
    }
}