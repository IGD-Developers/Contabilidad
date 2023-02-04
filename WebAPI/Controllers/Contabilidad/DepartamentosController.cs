using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContabilidadWebAPI.Aplicacion.Contabilidad.Departamentos;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Departamentos;
using ContabilidadWebAPI.Controllers;
using ContabilidadWebAPI.Dominio.Contabilidad;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ContabilidadWebAPI.Persistencia;

namespace ContabilidadWebAPI.Controllers.Contabilidad;

[ApiController]
[Route("api/[controller]")]
public class DepartamentosController : MiControllerBase
{

    [HttpGet]
    public async Task<ActionResult<List<DepartamentosModel>>> Get()
    {
        return await Mediator.Send(new Consulta.ListaDepartamentos());
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<DepartamentosModel>> Detalle(int Id)
    {
        return await Mediator.Send(new ConsultaId.ConsultarId { Id = Id });
    }



}