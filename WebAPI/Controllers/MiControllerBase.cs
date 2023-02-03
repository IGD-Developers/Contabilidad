using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MiControllerBase : ControllerBase
{
    private IMediator _mediator;

  
    //protected IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());

     
     /// <summary>  
      ///   Propiedad tipo IMediator encapsulada - Metodo get 
      ///</summary>
      ///<returns> La interfaz IMediator asignando: _mediator = HttpContext.RequestServices.GetService(<c>IMediator</c>) </returns>
    protected IMediator Mediator {
    
        get{ 
        if(_mediator == null)
            {
                _mediator = HttpContext.RequestServices.GetService<IMediator>();
            }
            return _mediator;
         }
    }

}