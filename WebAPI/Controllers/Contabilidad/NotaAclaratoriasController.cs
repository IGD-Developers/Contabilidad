using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Aplicacion.Contabilidad.NotaAclaratorias;
using Dominio.Contabilidad;
using Aplicacion.Models.Contabilidad.NotaAclaratoria;

namespace WebAPI.Controllers.Contabilidad;


[ApiController]
[Route("api/[controller]")]
public class NotaAclaratoriasController : MiControllerBase
{
    
    [HttpGet]
    public async Task<ActionResult<List<ListarNotaAclaratoriaModel>>> Get()
    {

        return await Mediator.Send(new Consulta.ListaCntNotaAclaratorias());

    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<ListarNotaAclaratoriaModel>> GetId(int Id)
    {
        return await Mediator.Send(new ConsultaId.ConsultarId { Id = Id });
    }

    [HttpPost]
    public async Task<ActionResult<Unit>>Insertar(Insertar.Ejecuta data){
        return await Mediator.Send(data);
    }

    [HttpPut("editar/{Id}")]
    public async Task<ActionResult<Unit>>Editar(int Id, Editar.Ejecuta data){
        data.Id = Id;
        return await Mediator.Send(data);
    }

    [HttpDelete("eliminar/{Id}")]
    public async Task<ActionResult<Unit>>Eliminar(int Id, Eliminar.Ejecuta data){
        data.Id = Id;
        return await Mediator.Send(data);

    }

    [HttpPut("cambiarestado/{Id}")]
    public async Task<ActionResult<Unit>>CambiarEstado(int Id, ActivarInactivar.Ejecuta data){
        data.Id = Id;
        return await Mediator.Send(data);
    }




}
//instanciar
