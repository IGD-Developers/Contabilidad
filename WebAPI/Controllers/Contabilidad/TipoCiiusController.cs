using System.Collections.Generic;
using System.Linq;
using Dominio.Contabilidad;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistencia;
using Aplicacion.Contabilidad.TipoCiius;
using System.Threading.Tasks;
using Aplicacion.Models.Contabilidad.TipoCiius;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TipoCiiusController : MiControllerBase
{
   

    [HttpGet]
    public async Task<ActionResult<List<TipoCiiusModel>>>Get(){
        return await Mediator.Send(new Consulta.ListarTipoCiius());
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<TipoCiiusModel>> Detalle(int Id){
        return await Mediator.Send(new ConsultaId.ConsultarId{Id = Id});
    }
}