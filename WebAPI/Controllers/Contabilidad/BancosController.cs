namespace ContabilidadWebAPI.Controllers.Contabilidad;


[ApiController]
[Route("api/[controller]")]
public class BancosController : MiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<ListarBancosModel>>> Get()
    {
        return await Mediator.Send(new ListaCntBancosRequest());
    }



    [HttpGet("{Id}")]
    
    public async Task<ActionResult<ListarBancosModel>> GetId(int Id)
    {

        return await Mediator.Send(new ConsultarBancoRequest { Id = Id });

    }
    
    [HttpPost]

    public async Task<ActionResult<Unit>> Insertar(InsertarBancoRequest data)
    {

        return await Mediator.Send(data);

    }

[HttpPut("{Id}")]

    public async Task<ActionResult<Unit>>  Editar(int Id, EditarBancoRequest data) 
    
    {
        data.Id = Id;
        return await Mediator.Send(data);
    }


}