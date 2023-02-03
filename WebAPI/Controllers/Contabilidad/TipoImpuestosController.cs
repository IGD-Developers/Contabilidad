using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using Aplicacion.Contabilidad.TipoImpuestos;
using Dominio.Contabilidad;
using Aplicacion.Models.Contabilidad.TipoImpuestos;

namespace WebAPI.Controllers.Contabilidad;


[ApiController]
[Route("api/[controller]")]

public class TipoImpuestosController : MiControllerBase
{
   

    [HttpGet]


    public async Task<ActionResult<List<ListarTipoImpuestosModel>>> Get()
    {

        return await Mediator.Send(new Consulta.ListaCntTipoImpuestos());



    }

    [HttpGet("{id}")]

    public async Task<ActionResult<ListarTipoImpuestosModel>> GetId(int id)
    {

        return await Mediator.Send(new ConsultaId.ConsultarId { Id = id });
    }

    [HttpPost]

    public async Task<ActionResult<Unit>>  Insertar(Insertar.Ejecuta data)
    {
        return await Mediator.Send(data);
    }

    [HttpPut("{id}")]

    public async Task<ActionResult<Unit>>  Editar(int id, Editar.Ejecuta data) 
    
    {
        data.Id = id;
        return await Mediator.Send(data);
    }

    

}