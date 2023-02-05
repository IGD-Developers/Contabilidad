namespace ContabilidadWebAPI.Aplicacion.Seguridad;

public class RegistrarUsuarioRequest : IRequest<UsuarioData>
{
    public string Nombre { get; set; }
    public string Apellidos { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Username { get; set; }
    public int IdTercero { get; set; }

}


public class RegistrarUsuarioValidator : AbstractValidator<RegistrarUsuarioRequest>
{
    public RegistrarUsuarioValidator()
    {
        RuleFor(x => x.Nombre).NotEmpty();
        RuleFor(x => x.Apellidos).NotEmpty();
        RuleFor(x => x.Email).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();
        RuleFor(x => x.Username).NotEmpty();
    }
}

public class RegistrarUsuarioHandler : IRequestHandler<RegistrarUsuarioRequest, UsuarioData>
{

    private readonly CntContext _context;
    private readonly UserManager<CnfUsuario> _userManager;
    private readonly IJwtGenerador _jwtGenerador;

    //UserManager<CnfUsuario> para poder aplicar  la seguridad Identity
    //IJwtGenerador para poder trabajar con los Tokens 
    public RegistrarUsuarioHandler(CntContext context, UserManager<CnfUsuario> userManager, IJwtGenerador jwtGenerador)
    {
        _context = context;
        _userManager = userManager;
        _jwtGenerador = jwtGenerador;
    }

    public async Task<UsuarioData> Handle(RegistrarUsuarioRequest request, CancellationToken cancellationToken)
    {

        //x representa los registros dentro de la tabla users. Existe tiene un valor booleano
        var existe = await _context.Users.Where(x => x.Email == request.Email).AnyAsync();
        if (existe)
        {
            throw new Exception("Ya existe el Email1");
        }

        var existeUserName = await _context.Users.Where(x => x.UserName == request.Username).AnyAsync();
        if (existeUserName)
        {
            throw new Exception("Nombre de Usurio no disponible");

        }

        var Usuario = new CnfUsuario
        {
            IdTercero = request.IdTercero,
            UsuEstado = true,
            UsuSupervisor = false,
            Email = request.Email,
            UserName = request.Username

        };

        var resultado = await _userManager.CreateAsync(Usuario, request.Password);

        if (resultado.Succeeded)
        {
            return new UsuarioData
            {
                IdTercero = Usuario.IdTercero,
                Token = _jwtGenerador.CrearToken(Usuario),
                UserName = Usuario.UserName,
                Email = Usuario.Email

            };
        }

        throw new Exception("Ya existe el Email");

    }
}