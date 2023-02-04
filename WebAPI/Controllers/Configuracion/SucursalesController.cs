using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using ContabilidadWebAPI.Dominio.Configuracion;
using ContabilidadWebAPI.Aplicacion.Configuracion.Sucursales;
using ContabilidadWebAPI.Aplicacion.Models.Configuracion.Sucursales;

namespace ContabilidadWebAPI.Controllers.Configuracion;

[ApiController]
[Route("api/[controller]")]
public class SucursalesController : MiControllerBase
{

    [HttpGet]

    public async Task<ActionResult<List<ListarSucursalModel>>> Get()
    {


        return await Mediator.Send(new Consulta.ListaCnfSucursales());
    }

    [HttpGet("{Id}")]

    public async Task<ActionResult<ListarSucursalModel>> GetId(int Id)
    {

        return await Mediator.Send(new ConsultaId.ConsultarId { Id = Id });
    }

    [HttpPost]

    public async Task<ActionResult<Unit>> Insertar(Insertar.Ejecuta data){

        return await  Mediator.Send(data);
    }

     [HttpPut("{Id}")]

    public async Task<ActionResult<Unit>>  Editar(int Id, Editar.Ejecuta data) 
    
    {
        data.Id = Id;
        return await Mediator.Send(data);
    }

}




