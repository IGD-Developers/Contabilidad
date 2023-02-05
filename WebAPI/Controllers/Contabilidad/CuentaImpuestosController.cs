namespace ContabilidadWebAPI.Controllers.Contabilidad;


[ApiController]
[Route("api/[controller]")]
public class CuentaImpuestosController : MiControllerBase
{
    [HttpGet]
    public async Task<List<ListarCuentaImpuestosModel>> Get()
    {
        return await Mediator.Send(new ListaCntCuentaImpuestosRequest());
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<ListarCuentaImpuestosModel>> GetId(int Id)
    {
        return await Mediator.Send(new ConsultarCuentaImpuestoRequest { Id = Id });
    }

    // [HttpPost]

    // public async Task<ActionResult<Unit>> Insertar(Insertar.Ejecuta data) {

    //     return await Mediator.Send(data);

    // }


    // [HttpPut("{Id}")]

    // public async Task<ActionResult<Unit>>  Editar(int Id, Editar.Ejecuta data) 

    // {
    //     data.Id = Id;
    //     return await Mediator.Send(data);
    // }


}
