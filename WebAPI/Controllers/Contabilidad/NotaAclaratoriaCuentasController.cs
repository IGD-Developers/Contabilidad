namespace ContabilidadWebAPI.Controllers.Contabilidad;



[ApiController]
[Route("api/[controller]")]

public class NotaAclaratoriaCuentasController : MiControllerBase
{

    [HttpGet]
    public async Task<ActionResult<List<CntNotaAclaratoriaCuenta>>> Get()
    {

        return await Mediator.Send(new ListaCntNotaAclaratoriaCuentasRequest());

    }

    [HttpPost]
    public async Task<ActionResult<Unit>> Insertar(InsertarNotaAclaratoriaCuentaRequest dato)
    {
        return await Mediator.Send(dato);
    }

    [HttpPut]
    public async Task<ActionResult<Unit>> Editar(EditarNotaAclaratoriaCuentaRequest dato)
    {
        return await Mediator.Send(dato);
    }



}