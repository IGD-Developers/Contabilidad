namespace ContabilidadWebAPI.Aplicacion.Contabilidad.Pucs;

public class ListaCntPucsRequest : IRequest<List<ListarPucModel>>
{ }

public class ListaCntPucsHandler : IRequestHandler<ListaCntPucsRequest, List<ListarPucModel>>
{

    private readonly CntContext _context;
    private readonly IMapper mapper;
    public ListaCntPucsHandler(CntContext context, IMapper mapper)
    {
        _context = context;
        this.mapper = mapper;
    }

    public async Task<List<ListarPucModel>> Handle(ListaCntPucsRequest request, CancellationToken cancellationToken)
    {

        // var cntPucs = await _context.cntPucs
        // .ToListAsync();
        var entidadesDto = await _context.cntPucs
        .Include(x => x.PucTipo)
        .Include(x => x.TipoCuenta)
        .Select(p => mapper.Map<CntPuc, ListarPucModel>(p))
        .ToListAsync();





        //var PucModel = mapper.Map<List<CntPuc>,List<ListarPucModel>>(pucs);
        //Clase : primer digito
        //Grupo: dos digitos
        //Cuenta: cuatro digitos
        //SubCuenta: seis digitos 

        foreach (var registro in entidadesDto)
        {
            int longitud = registro.Codigo.Length;
            var codigoclase = registro.Codigo.Substring(0, 1);
            var Clase = from regi in entidadesDto
                        where regi.Codigo == codigoclase
                        select new { regi.Nombre };
            registro.Clase = Clase.First().Nombre;


            var codigogrupo = longitud > 1 ? registro.Codigo.Substring(0, 2) : "";
            if (longitud > 1)
            {
                var Grupo = from regi in entidadesDto
                            where regi.Codigo == codigogrupo
                            select new { regi.Nombre };
                registro.Grupo = Grupo.First().Nombre;
            }
            else { registro.Grupo = ""; }

            var codigocuenta = longitud > 3 ? registro.Codigo.Substring(0, 4) : "";
            if (longitud > 3)
            {
                var Cuenta = from regi in entidadesDto
                             where regi.Codigo == codigocuenta
                             select new { regi.Nombre };
                registro.Cuenta = Cuenta.First().Nombre;
            }
            else { registro.Cuenta = ""; }

            var codigosubcuenta = longitud > 5 ? registro.Codigo.Substring(0, 6) : "";
            if (longitud > 5)
            {
                var SubCuenta = from regi in entidadesDto
                                where regi.Codigo == codigosubcuenta
                                select new { regi.Nombre };
                registro.SubCuenta = SubCuenta.First().Nombre;
            }
            else { registro.SubCuenta = ""; }

        }

        return entidadesDto;

    }
}