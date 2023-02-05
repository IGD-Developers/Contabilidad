using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContabilidadWebAPI.Aplicacion.Contabilidad.Generos;
using ContabilidadWebAPI.Aplicacion.Models.Contabilidad.Genero;
using ContabilidadWebAPI.Controllers;
using ContabilidadWebAPI.Dominio.Contabilidad;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ContabilidadWebAPI.Persistencia;

namespace ContabilidadWebAPI.Controllers.Contabilidad;

[ApiController]
[Route("api/[controller]")]
public class GenerosController : MiControllerBase
{
    //http://localhost:5000/api/CntGeneros
    [HttpGet]
    public async Task<ActionResult<List<GeneroModel>>> Get()
    {
        return await Mediator.Send(new ListaGenerosRequest());
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<GeneroModel>> Detalle(int Id)
    {
        return await Mediator.Send(new ConsultarGeneroRequest{ Id = Id });
    }
}