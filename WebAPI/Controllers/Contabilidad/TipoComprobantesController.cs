using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using Aplicacion.Contabilidad.TipoComprobantes;
using Dominio.Contabilidad;
using Aplicacion.Models.Contabilidad.TipoComprobantes;

namespace WebAPI.Controllers.Contabilidad;

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

    [HttpGet("{id}")]

    public async Task<ActionResult<ListarTipoComprobanteModel>> GetId(int id)
    {

        return await Mediator.Send(new ConsultaId.ConsultarId { Id = id });

    }


    [HttpPost]

    public async  Task<ActionResult<Unit>> Insertar(Insertar.Ejecuta data) {

        return await Mediator.Send(data);


    }

     [HttpPut("{id}")]

    public async Task<ActionResult<Unit>>  Editar(int id, Editar.Ejecuta data) 
    
    {
        data.Id = id;
        return await Mediator.Send(data);
    }



}