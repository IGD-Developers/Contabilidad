
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Persistencia.DapperConexion.Contabilidad.Pucs;
using Aplicacion.Dapper.Contabilidad.PucsDapper;
using System;
using MediatR;

namespace WebAPI.ControllersDapper.Contabilidad.Pucs


{
    [ApiController]
    [Route("api/[controller]")]
    public class PucsDapperController: Controllers.MiControllerBase
    {
        
        [HttpGet]
        public async Task<ActionResult<List<PucRepositorioModel>>> ObtenerPucsDapper()
        {

            return await Mediator.Send(new ConsultaDapper.Lista());
            

        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Insertar(InsertarDapper.Ejecuta data) {

            return await Mediator.Send(data);
        }

       

    }   
}