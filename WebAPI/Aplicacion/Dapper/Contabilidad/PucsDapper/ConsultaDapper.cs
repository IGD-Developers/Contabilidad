using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ContabilidadWebAPI.Persistencia.DapperConexion.Contabilidad.Pucs;
using MediatR;

namespace ContabilidadWebAPI.Aplicacion.Dapper.Contabilidad.PucsDapper;

public class ConsultarPucsDapperRequest : IRequest<List<PucRepositorioModel>> { }

public class ConsultarPucsDapperHandler : IRequestHandler<ConsultarPucsDapperRequest, List<PucRepositorioModel>>
{
    private readonly IPucRepositorio _pucRepositorio;

    public ConsultarPucsDapperHandler(IPucRepositorio pucRepositorio)
    {
        _pucRepositorio = pucRepositorio;
    }

    public async Task<List<PucRepositorioModel>> Handle(ConsultarPucsDapperRequest request, CancellationToken cancellationToken)
    {
        var resultado = await _pucRepositorio.ObtenerLista();
        //IEnumerable resultado lo llevamos a ToList() Para concordar con el Controller
        return resultado.ToList();
    }
}


