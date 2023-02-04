using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Aplicacion.Contabilidad.NotaAclaratoriaCuentas;
using Dominio.Contabilidad;
using ContabilidadWebAPI.Controllers;

namespace ContabilidadWebAPI.Controllers.Contabilidad;



[ApiController]
[Route("api/[controller]")]

public class NotaAclaratoriaCuentasController : MiControllerBase
{

    [HttpGet]
    public async Task<ActionResult<List<CntNotaAclaratoriaCuenta>>> Get()
    {

        return await Mediator.Send(new Consulta.ListaCntNotaAclaratoriaCuentas());

    }

    [HttpPost]
    public async Task<ActionResult<Unit>> Insertar(Insertar.Ejecuta dato)
    {
        return await Mediator.Send(dato);
    }

    [HttpPut]
    public async Task<ActionResult<Unit>> Editar(Editar.Ejecuta dato)
    {
        return await Mediator.Send(dato);
    }



}