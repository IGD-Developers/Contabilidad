using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Persistencia;
using Dominio;
using Aplicacion;
using MediatR;
using Dominio.Configuracion;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Authentication;
using FluentValidation.AspNetCore;
using Aplicacion.Seguridad;
using Aplicacion.Interfaces;
using Seguridad.TokenSeguridad;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Seguridad;
using System.Text.Json.Serialization;
using AutoMapper;
using Persistencia.DapperConexion;
using Persistencia.DapperConexion.Contabilidad.Pucs;
using Aplicacion.Contabilidad.Consecutivos;
using Aplicacion.Contabilidad.Terceros;
using Aplicacion.Contabilidad.Comprobantes;

namespace WebAPI;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }


   public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {

        //agregamos Cors para permitir que se conecten y consuman las apis desde cualquier sitio
        //luego en la parte de abajo en el metodo configure indicamos que la app use los cors aqui declarado
        services.AddCors(o => o.AddPolicy("corsApp", builder => {
            builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        }));


        services.AddDbContext<CntContext>( opt => 
            opt.UseMySql(Configuration.GetConnectionString("Conexion"), new MySqlServerVersion(new Version(8, 0, 19))));

        //Configuracion Dapper: indicamos la cadena de conexion de la BD  
        //Debemos referirnos al objeto padre donde tenemos la conexion 
        //pero en la clase que modela la conexion-Persistencia-ConexionConfiguracion si debemos indicar el nombre del objeto que tiene directamente la conexion   
        services.AddOptions();
        services.Configure<ConexionConfiguracion>(Configuration.GetSection("ConnectionStrings"));


       // services.AddMediatR(typeof(Aplicacion.CntComprobantes.Consulta.Manejador).Assembly);
        services.AddMediatR(typeof(Aplicacion.Contabilidad.CategoriaComprobantes.Consulta.Manejador).Assembly);
        services.AddTransient(typeof(IInsertarConsecutivo), typeof(InsertarConsecutivo));
        services.AddTransient(typeof(IInsertarComprobante), typeof(InsertarComprobante));
        services.AddTransient(typeof(IFunciones), typeof(Funciones));


        // services.AddControllers().AddFluentValidation( cfg => cfg.RegisterValidatorsFromAssemblyContaining<Login>());
        services.AddControllers( opt => {
            var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
            opt.Filters.Add(new AuthorizeFilter(policy));
        })
        .AddFluentValidation( cfg => cfg.RegisterValidatorsFromAssemblyContaining<Login>());
        // services.AddControllers().AddJsonOptions(x =>
        // x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
    



        var builder = services.AddIdentityCore<CnfUsuario>();
        var identitityBuilder =  new IdentityBuilder(builder.UserType,builder.Services);
        identitityBuilder.AddEntityFrameworkStores<CntContext>();           
        identitityBuilder.AddSignInManager<SignInManager<CnfUsuario>>();
        services.TryAddSingleton<ISystemClock,SystemClock>();

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Mi palabra secreto"));
        //para que no permita consumir los endpoints sin token:  
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(opt=> { opt.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,    
                IssuerSigningKey = key, 
                ValidateAudience = false,     
                ValidateIssuer = false
 
            };
        });


        services.AddScoped<IUsuarioSesion, UsuarioSesion>();
        services.AddScoped<IJwtGenerador,JwtGenerador>();
        //Ojo le agrego Aplicacion.Seguridad porque me da referencia Ambigua:
        services.AddAutoMapper(typeof(Aplicacion.Seguridad.Consulta.Manejador));

        services.AddTransient<IFactoryConnection, FactoryConnection>();
        services.AddScoped<IPucRepositorio, PucRepositorio>();




        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo {
                 Title = "Services para IGD Contador",
                 Version = "v1" 
            });
            c.CustomSchemaIds(c=>c.FullName);
        });
        // FullName Para que trabaje con nombre completo incluido namesapce de las clases 
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        
        app.UseCors("corsApp");

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
           //OJO ESTA DA ERROR app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "IGD Contador v1"));
        }

        //app.UseHttpsRedirection(); //para modo de produccion
        //app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Services IGD Contador v1"));
        


    }
}
