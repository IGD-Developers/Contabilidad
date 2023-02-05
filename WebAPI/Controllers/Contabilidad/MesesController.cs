namespace ContabilidadWebAPI.Controllers.Contabilidad;


[ApiController]
[Route("api/[controller]")]
public class MesesController : MiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<CntMes>>> Get()
    {

        return await Mediator.Send(new ListaCntMesesRequest());

    }

    [HttpPost]
    public async Task<ActionResult<Unit>> Insertar(InsertarMesRequest data)
    {
        return await Mediator.Send(data);
    }

    // [HttpPut]
    // public async Task<ActionResult<Unit>>Editar(Editar.ActivarInactivarNotaAclaratoriaRequest data){
    //     return await Mediator.Send(data);
    // }

    [HttpPut("{Id}")]

    public async Task<ActionResult<Unit>> Editar(int Id, EditarMesRequest data)

    {
        data.Id = Id;
        return await Mediator.Send(data);
    }
}