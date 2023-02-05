namespace ContabilidadWebAPI.Controllers.Contabilidad;


[ApiController]
[Route("api/[controller]")]

public class PucTiposController : MiControllerBase
{

    [HttpGet]
    public async Task<ActionResult<List<CntPucTipo>>> Get()
    {

        return await Mediator.Send(new ListaCntPucTiposRequest());
    }


    [HttpGet("{Id}")]

    public async Task<ActionResult<CntPucTipo>> GetId(int Id)
    {

        return await Mediator.Send(new ConsultarPucTipoRequest { Id = Id });

    }

    [HttpPost]

    public async Task<ActionResult<Unit>> insertar(InsertarPucTipoRequest data)
    {

        return await Mediator.Send(data);


    }

    [HttpPut("{Id}")]

    public async Task<ActionResult<Unit>> Editar(int Id, EditarPucTipoRequest data)

    {
        data.Id = Id;
        return await Mediator.Send(data);
    }



}