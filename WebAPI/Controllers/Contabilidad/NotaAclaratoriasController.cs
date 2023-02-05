using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ContabilidadWebAPI.Aplicacion.Contabilidad.NotaAclaratorias;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.NotaAclaratoria;

namespace ContabilidadWebAPI.Controllers.Contabilidad;


[ApiController]
[Route("api/[controller]")]
public class NotaAclaratoriasController : MiControllerBase
{

    [HttpGet]
    public async Task<ActionResult<List<ListarNotaAclaratoriaModel>>> Get()
    {

        return await Mediator.Send(new ListaCntNotaAclaratoriasRequest());

    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<ListarNotaAclaratoriaModel>> GetId(int Id)
    {
        return await Mediator.Send(new ConsultarNotaAclaratoriaRequest { Id = Id });
    }

    [HttpPost]
    public async Task<ActionResult<Unit>> Insertar(InsertarNotaAclaratoriaRequest data)
    {
        return await Mediator.Send(data);
    }

    [HttpPut("editar/{Id}")]
    public async Task<ActionResult<Unit>> Editar(int Id, EditarNotaAclaratoriaRequest data)
    {
        data.Id = Id;
        return await Mediator.Send(data);
    }

    [HttpDelete("eliminar/{Id}")]
    public async Task<ActionResult<Unit>> Eliminar(int Id, EliminarNotaAclaratoriaRequest data)
    {
        data.Id = Id;
        return await Mediator.Send(data);

    }

    [HttpPut("cambiarestado/{Id}")]
    public async Task<ActionResult<Unit>> CambiarEstado(int Id, ActivarInactivarNotaAclaratoriaRequest data)
    {
        data.Id = Id;
        return await Mediator.Send(data);
    }




}
//instanciar
