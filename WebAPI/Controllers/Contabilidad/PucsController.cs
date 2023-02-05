namespace ContabilidadWebAPI.Controllers.Contabilidad;


[ApiController]
[Route("api/[controller]")]

public class PucsController : MiControllerBase


{

    [HttpGet]

    public async Task<ActionResult<List<ListarPucModel>>> Get()
    {

        return await Mediator.Send(new ListaCntPucsRequest());
    }


    [HttpGet("{Id}")]

    public async Task<ActionResult<ListarPucModel>> GetId(int Id)
    {

        return await Mediator.Send(new ConsultarPucRequest { Id = Id });
    }

    [HttpPost]

    public async Task<ActionResult<Unit>> Insertar(InsertarPucRequest data)
    {

        return await Mediator.Send(data);
    }
    [HttpPut("{Id}")]

    public async Task<ActionResult<Unit>> Editar(int Id, EditarPucRequest data)

    {
        data.Id = Id;
        return await Mediator.Send(data);
    }

    [HttpDelete("{Id}")]

    public async Task<ActionResult<Unit>> Eliminar(int Id)

    {
        return await Mediator.Send(new EliminarPucRequest { Id = Id });
    }

}