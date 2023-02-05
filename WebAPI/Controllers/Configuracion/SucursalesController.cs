namespace ContabilidadWebAPI.Controllers.Configuracion;

[ApiController]
[Route("api/[controller]")]
public class SucursalesController : MiControllerBase
{

    [HttpGet]

    public async Task<ActionResult<List<ListarSucursalModel>>> Get()
    {


        return await Mediator.Send(new ListaCnfSucursalesRequest());
    }

    [HttpGet("{Id}")]

    public async Task<ActionResult<ListarSucursalModel>> GetId(int Id)
    {

        return await Mediator.Send(new ConsultarSucursalRequest { Id = Id });
    }

    [HttpPost]

    public async Task<ActionResult<Unit>> Insertar(InsertarSucursalRequest data){

        return await  Mediator.Send(data);
    }

     [HttpPut("{Id}")]

    public async Task<ActionResult<Unit>>  Editar(int Id, EditarSucursalRequest data) 
    
    {
        data.Id = Id;
        return await Mediator.Send(data);
    }

}




