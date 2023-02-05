namespace ContabilidadWebAPI.Controllers.Contabilidad;

[ApiController]
[Route("api/[controller]")]
public class ResponsabilidadTercerosController : MiControllerBase
{

    [HttpGet]
    public async Task<ActionResult<List<ResponsabilidadTerceroModel>>> Get()
    {
        return await Mediator.Send(new ListarResponsabilidadesTerceroRequest());
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<ResponsabilidadTerceroModel>> GetId(int Id)
    {
        return await Mediator.Send(new ConsultarResponsabilidadTerceroRequest { Id = Id });
    }

    /* [HttpPost]
    public async Task<ActionResult<Unit>>Insertar(Insertar.ActivarInactivarNotaAclaratoriaRequest data){
        return await Mediator.Send(data);
    } */

    /* [HttpPut]
    public async Task<ActionResult<Unit>>Editar(Editar.ActivarInactivarNotaAclaratoriaRequest data){
        return await Mediator.Send(data);
    } */

    /* [HttpDelete("eliminar/{Id}")]
    public async Task<ActionResult<Unit>>Eliminar(int Id,Eliminar.ActivarInactivarNotaAclaratoriaRequest data){
        data.Id = Id;
        return await Mediator.Send(data);
    } */
}