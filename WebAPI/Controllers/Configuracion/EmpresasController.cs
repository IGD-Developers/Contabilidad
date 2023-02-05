using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ContabilidadWebAPI.Persistencia;
using MediatR;
using System.Threading.Tasks;
using ContabilidadWebAPI.Dominio.Configuracion;
using Microsoft.AspNetCore.Authorization;
using ContabilidadWebAPI.Aplicacion.Configuracion.Empresas;
using ContabilidadWebAPI.Aplicacion.Models.Configuracion.Empresas;

namespace ContabilidadWebAPI.Controllers.Configuracion;




[ApiController]
[Route("api/[controller]")]
public class EmpresasController : MiControllerBase
{
    // private readonly IMediator mediator;

    // public EmpresasController(IMediator _mediator)
    // {
    //     mediator = _mediator;
    // }
    [HttpGet]

    public async Task<ActionResult<List<ListarEmpresasModel>>> Get()
    {

        return await Mediator.Send(new ListaCnfEmpresasRequest());

    }

    [HttpGet("{Id}")]

    public async Task<ActionResult<ListarEmpresasModel>> GetId(int Id)
    {

        return await Mediator.Send(new ConsultarEmpresaRequest { Id = Id });
    }

    
[HttpPost]

public async Task<ActionResult<Unit>> Insertar(InsertarEmpresaRequest data) {

    return await Mediator.Send(data);

}

[HttpPut("{Id}")]

    public async Task<ActionResult<Unit>>  Editar(int Id, EditarEmpresaRequest data) 
    
    {
        data.Id = Id;
        return await Mediator.Send(data);
    }

}