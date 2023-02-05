namespace ContabilidadWebAPI;

public class Program
{
    public static void Main(string[] args)
    {

        
        //Inciamos Host y los parametros yh propiedades devueltos quedan en hostServer
        var hostServer= CreateHostBuilder(args).Build();
        //Creamos Ambiente:
        using(var ambiente = hostServer.Services.CreateScope())
        {
            var services = ambiente.ServiceProvider;

            try {
            var userManager =services.GetRequiredService<UserManager<CnfUsuario>>();    
            var context = services.GetRequiredService<CntContext>();
            context.Database.Migrate();
            DataInicial.InsertarData(context,userManager).Wait();
            }catch(Exception e)
            {
                var logging = services.GetRequiredService<ILogger<Program>>();
                logging.LogError(e, "Error al Migrar");

            }

        }
         hostServer.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}
