using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using Aplicacion.Contabilidad.TipoComprobantes;
using Dominio.Contabilidad;
using Aplicacion.Models.Contabilidad.TipoComprobantes;
using ContabilidadWebAPI.Controllers;

namespace ContabilidadWebAPI.Controllers.Contabilidad;

[ApiController]
[Route("api/[controller]")]
public class TipoComprobantesController : MiControllerBase
{


    [HttpGet]
    public async Task<ActionResult<List<ListarTipoComprobanteModel>>> Get()
    {

        return await Mediator.Send(new Consulta.ListaCntTipoComprobantes());

    }

    //http://localhost:5000/api/CntTipoComprobantes/{1}

    [HttpGet("{Id}")]

    public async Task<ActionResult<ListarTipoComprobanteModel>> GetId(int Id)
    {

        return await Mediator.Send(new ConsultaId.ConsultarId { Id = Id });

    }


    [HttpPost]

    public async Task<ActionResult<Unit>> Insertar(Insertar.Ejecuta data)
    {

        return await Mediator.Send(data);


    }

    [HttpPut("{Id}")]

    public async Task<ActionResult<Unit>> Editar(int Id, Editar.Ejecuta data)

    {
        data.Id = Id;
        return await Mediator.Send(data);
    }



}