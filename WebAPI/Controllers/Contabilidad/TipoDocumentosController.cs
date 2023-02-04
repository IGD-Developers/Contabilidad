using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContabilidadWebAPI.Aplicacion.Contabilidad.TipoDocumentos;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.TipoDocumento;
using ContabilidadWebAPI.Controllers;
using ContabilidadWebAPI.Dominio.Contabilidad;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ContabilidadWebAPI.Persistencia;

namespace ContabilidadWebAPI.Controllers.Contabilidad;

[ApiController]
[Route("api/[controller]")]
public class TipoDocumentosController : MiControllerBase
{


    //http://localhost:5000/api/CntTipoDocumentos
    [HttpGet]
    public async Task<ActionResult<List<TipoDocumentoModel>>> Get()
    {
        return await Mediator.Send(new Consulta.ListaTipoDocumentos());
    }

    //http://localhost:5000/api/CntTipoDocumentos/1
    [HttpGet("{Id}")]
    public async Task<ActionResult<TipoDocumentoModel>> Get(int Id)
    {
        return await Mediator.Send(new ConsultaId.ConsultarTipoDocumentoId { Id = Id });
    }
}