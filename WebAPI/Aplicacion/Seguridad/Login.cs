namespace ContabilidadWebAPI.Aplicacion.Seguridad;

public class LoginRequest : IRequest<UsuarioData>
{

    public string Password { get; set; }
    public string Email { get; set; }

}

public class LoginValidator : AbstractValidator<LoginRequest>
{
    public LoginValidator()
    {
        RuleFor(x => x.Email).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();


    }


}


public class LoginHandler : IRequestHandler<LoginRequest, UsuarioData>
//Clase Manejador que representa la logica en si.
//Recibe dos pmts: 1-Ejecuta(para que ingresesn los valores de Email y password)
//y el 2-Tipo de entidad que va a trabajar sobre la cual va a hacer la transaccion que es UsuarioData
{
    private readonly UserManager<CnfUsuario> _userManager;
    private readonly SignInManager<CnfUsuario> _signInManager;
    private readonly IJwtGenerador _jwtGenerador;

    public LoginHandler(UserManager<CnfUsuario> userManager, SignInManager<CnfUsuario> signInManager, IJwtGenerador jwtGenerador)
    // Para trabajar la logica de loginDebemos inyectar en el constructor de manejador 
    //dos objetos:UserManager, SignInManager que vienen de CoreIdentity y referencian 
    //a la base de datos para hacer la comparacion del Email y password que entran como pmts

    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtGenerador = jwtGenerador;
    }


    public async Task<UsuarioData> Handle(LoginRequest request, CancellationToken cancellationToken)
    {

        var Usuario = await _userManager.FindByEmailAsync(request.Email);
        if (Usuario == null)
        {
            throw new Exception("Error  Login");

        }

        var resultado = await _signInManager.CheckPasswordSignInAsync(Usuario, request.Password, false);
        if (resultado.Succeeded)
        {
            return new UsuarioData
            {
                IdTercero = Usuario.IdTercero,
                Token = _jwtGenerador.CrearToken(Usuario),
                Email = Usuario.Email,
                UserName = Usuario.UserName
            };
        }
        throw new Exception("Error Login Usuario");


    }



}