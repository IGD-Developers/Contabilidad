namespace ContabilidadWebAPI.Controllers.Contabilidad;


[ApiController]
[Route("api/[controller]")]
public class CentroCostosController : MiControllerBase
{
   


    [HttpGet]
    public async Task<ActionResult<List<ListarCentroCostosModel>>> Get()
    {


        return await Mediator.Send(new ListaCntCentroCostosRequest());

    }

    [HttpGet("{Id}")]

    public async Task<ActionResult<ListarCentroCostosModel>> GetId(int Id)
    {

        return await Mediator.Send(new ConsultarCentroCostoRequest { Id = Id });
    }

    [HttpPost]
    public async Task<ActionResult<Unit>> Insertar(InsertarCentroCostoRequest data) {

        return await Mediator.Send(data);
    }
    [HttpPut("{Id}")]

    public async Task<ActionResult<Unit>>  Editar(int Id, EditarCentroCostoRequest data) 
    
    {
        data.Id = Id;
        return await Mediator.Send(data);
    }

}


