using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Aplicacion.Contabilidad.FormatoColumnas;
using Dominio.Contabilidad;

namespace WebAPI.Controllers.Contabilidad;


[ApiController]
[Route("api/[controller]")]
public class FormatoColumnasController : MiControllerBase
{


    

    [HttpGet]
    public async Task<ActionResult<List<CntFormatoColumna>>> Get()
    {

        return await Mediator.Send(new Consulta.ListaCntFormatoColumnas());
    }

    [HttpGet("{Id}")]

    public async Task<ActionResult<CntFormatoColumna>> GetId(int Id)
    {

        return await Mediator.Send(new ConsultaId.ConsultarId { Id = Id });

    }

    [HttpPost]

    public async Task<ActionResult<Unit>> Insertar(Insertar.Ejecuta data)
    {
        return await Mediator.Send(data);
    }

    [HttpPut("{Id}")]

    public async Task<ActionResult<Unit>>  Editar(int Id, Editar.Ejecuta data) 
    
    {
        data.Id = Id;
        return await Mediator.Send(data);
    }






}
