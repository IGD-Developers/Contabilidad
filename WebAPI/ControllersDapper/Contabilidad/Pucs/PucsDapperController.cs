
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;
using MediatR;
using ContabilidadWebAPI.Controllers;
using ContabilidadWebAPI.Persistencia.DapperConexion.Contabilidad.Pucs;
using ContabilidadWebAPI.Aplicacion.Dapper.Contabilidad.PucsDapper;

namespace ContabilidadWebAPI.ControllersDapper.Contabilidad.Pucs;



[ApiController]
[Route("api/[controller]")]
public class PucsDapperController : MiControllerBase
{

    [HttpGet]
    public async Task<ActionResult<List<PucRepositorioModel>>> ObtenerPucsDapper()
    {

        return await Mediator.Send(new ConsultaDapper.Lista());


    }

    [HttpPost]
    public async Task<ActionResult<Unit>> Insertar(InsertarDapper.Ejecuta data)
    {

        return await Mediator.Send(data);
    }



}