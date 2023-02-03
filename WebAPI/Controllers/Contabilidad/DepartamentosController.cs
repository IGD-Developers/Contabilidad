using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Contabilidad.Departamentos;
using Aplicacion.Models.Contabilidad.Departamentos;
using Dominio.Contabilidad;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistencia;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepartamentosController : MiControllerBase
{
  
    [HttpGet]
    public async Task<ActionResult<List<DepartamentosModel>>>Get(){
        return await Mediator.Send(new Consulta.ListaDepartamentos());
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<DepartamentosModel>>Detalle(int Id){
        return await Mediator.Send(new ConsultaId.ConsultarId{Id = Id});
    }


    
}