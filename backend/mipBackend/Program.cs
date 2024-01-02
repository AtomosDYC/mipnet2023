using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

using mipBackend.Data;
using mipBackend.Data.Inmuebles;
using mipBackend.Data.Roles;
using mipBackend.Data.Regiones;
using mipBackend.Data.Comunas;
using mipBackend.Data.Zonas;
using mipBackend.Data.Usuarios;
using mipBackend.Data.UserAuths;
using mipBackend.Data.Tipoespecie;
using mipBackend.Data.MedidaUmbrales;
using mipBackend.Data.EstadosDanios;
using mipBackend.Data.SetSelect;
using mipBackend.Data.Plantillas;
using mipBackend.Data.TipoFlujos;
using mipBackend.Data.Tipopermisos;
using mipBackend.Data.NivelFlujos;
using mipBackend.Data.Nivelpermisos;
using mipBackend.Data.TipoParametros;
using mipBackend.Data.Saludos;
using mipBackend.Data.Tipopersonas;
using mipBackend.Data.TipoCompersonas;
using mipBackend.Data.TipoperComunicaciones;
using mipBackend.Data.TipoDocumentos;
using mipBackend.Data.WorkflowParametros;
using mipBackend.Data.Areas;
using mipBackend.Data.DefaultUsers;
using mipBackend.Data.Workflows;
using mipBackend.Data.Menus;
using mipBackend.Data.Temporada;
using mipBackend.Data.Especies;
using mipBackend.Data.EspecieTemporada;
using mipBackend.Data.Monitores;
using mipBackend.Data.Personas;
using mipBackend.Data.Movils;


using mipBackend.Middleware;
using mipBackend.Models;
using mipBackend.Profiles;
using mipBackend.Token;
using System.Text;
using mipBackend.Services.EmailService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.LogTo(Console.WriteLine, new [] 
    {
        DbLoggerCategory.Database.Command.Name
    }, LogLevel.Information).EnableSensitiveDataLogging();

    opt.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerConnection")!);
});

builder.Services.AddScoped<IInmuebleRepository, InmuebleRepository>();
builder.Services.AddScoped<IRegionRepository, RegionRepository>();
builder.Services.AddScoped<IComunaRepository, ComunaRepository>();
builder.Services.AddScoped<ISetSelectRepository, SetSelectRepository>();
builder.Services.AddScoped<IZonaRepository, ZonaRepository>();

//especie
builder.Services.AddScoped<IEspeciesRepository, EspeciesRepository>();
builder.Services.AddScoped<IEspecietemporadaRepository, EspecieTemporadaRepository>();


builder.Services.AddScoped<ITipoespecieRepository, TipoespecieRepository>();
builder.Services.AddScoped<IMedidaUmbralRepository, MedidaUmbralRepository>();
builder.Services.AddScoped<IEstadosDanioRepository, EstadosDanioRepository>();
builder.Services.AddScoped<IDanioEspecieRepository, DanioEspecieRepository>();
builder.Services.AddScoped<IUmbralEspecieRepository, UmbralEspecieRepository>();

builder.Services.AddScoped<IPlantillaRepository, PlantillaRepository>();
builder.Services.AddScoped<ITipoFlujosRepository, TipoFlujosRepository>();
builder.Services.AddScoped<ITipopermisosRepository, TipopermisosRepository>();
builder.Services.AddScoped<IAreaRepository, AreaRepository>();
builder.Services.AddScoped<INivelFlujoRepository, NivelFlujoRepository>();
builder.Services.AddScoped<INivelpermisoRepository, NivelpermisoRepository>();
builder.Services.AddScoped<ITipoParametroRepository, TipoParametroRepository>();
builder.Services.AddScoped<ISaludoRepository, SaludoRepository>();
builder.Services.AddScoped<ITipopersonaRepository, TipopersonaRepository>();
builder.Services.AddScoped<ITipoCompersonaRepository, TipoCompersonaRepository>();
builder.Services.AddScoped<ITipoperComunicacionRepository, TipoperComunicacionRepository>();
builder.Services.AddScoped<ITipoDocumentoRepository, TipoDocumentoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddScoped<IUserAuthsRepository, UserAuthsRepository>();
builder.Services.AddScoped<IDefaultUserRepository, DefaultUserRepository>();
builder.Services.AddScoped<IWorkflowParametroRepository, WorkflowParametroRepository>();
builder.Services.AddScoped<IWorkflowRepository, WorkflowRepository>();
builder.Services.AddScoped<IPlantillaFlujoRepository, PlantillaFlujoRepository>();
builder.Services.AddScoped<IMenuRepository, MenuRepository>();

builder.Services.AddScoped<ISegmentarTemporadaRepository, SegmentarTemporadaRepository>();
builder.Services.AddScoped<ITemporadaBaseRepository, TemporadaBaseRepository>();
builder.Services.AddScoped<ITemporadaRepository, TemporadaRepository>();

builder.Services.AddScoped<IRolesRepository, RolesRepository>();

builder.Services.AddScoped<IEmailService, EmailService>();

//monitores
builder.Services.AddScoped<IMonitorRepository, MonitorRepository>();
builder.Services.AddScoped<IMonitorComunicacionRepository, MonitorComunicacionRepository>();
builder.Services.AddScoped<IMonitorAccesoRepository, MonitorAccesoRepository>();
builder.Services.AddScoped<IMonitorEspecieRepository, MonitorEspecieRepository>();
builder.Services.AddScoped<IMonitorSincronizacionRepository, MonitorSincronizacionRepository>();
builder.Services.AddScoped<IMonitorTrampaRepository, MonitorTrampaRepository>();


//movil
builder.Services.AddScoped<IMovilAccesoRepository, MovilAccesoRepository>();
builder.Services.AddScoped<IMovilPeriodoRepository, MovilPeriodoRepository>();
builder.Services.AddScoped<IMovilTablaSincroRepository, MovilTablaSincroRepository>();



//personas
builder.Services.AddScoped<IPersonaRepository, PersonaRepository>();
builder.Services.AddScoped<IPersonaComunicacionRepository, PersonaComunicacionRepository>();
builder.Services.AddScoped<IPersonaAccesoRepository, PersonaAccesoRepository>();

// Add services to the container.

builder.Services.AddControllers( opt => 
{ 
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    opt.Filters.Add(new AuthorizeFilter(policy));   
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new InmuebleProfile());
    mc.AddProfile(new ZonaProfile());
    mc.AddProfile(new RegionProfile());
    mc.AddProfile(new ComunaProfile());
    mc.AddProfile(new SetSelectProfile());

    //
    mc.AddProfile(new EspecieProfile());
    mc.AddProfile(new TipoespecieProfile());
    mc.AddProfile(new MedidaUmbralProfile());
    mc.AddProfile(new EstadosDanioProfile());
    mc.AddProfile(new EspecieTemporadaProfile());


    mc.AddProfile(new PlantillaProfile());
    mc.AddProfile(new PlantillaFlujoProfile());
    //usuarios
    mc.AddProfile(new UsuarioProfile());
    mc.AddProfile(new DefaultUserProfile());

    //workflow
    mc.AddProfile(new WorkflowProfile());
    mc.AddProfile(new WorkflowParametroProfile());

    //personas
    mc.AddProfile(new SaludoProfile());
    mc.AddProfile(new TipopersonaProfile());
    mc.AddProfile(new TipoDocumentoProfile());
    mc.AddProfile(new TipoCompersonaProfile());
    mc.AddProfile(new TipoperComunicacionProfile());

    //workflow
    mc.AddProfile(new TipoFlujoProfile());
    mc.AddProfile(new TipopermisoProfile());
    mc.AddProfile(new TipoParametroProfile());
    mc.AddProfile(new NivelFlujoProfile());
    mc.AddProfile(new NivelpermisoProfile());

    //tempoerada
    mc.AddProfile(new SegmentarTemporadaProfile());
    mc.AddProfile(new TemporadaBaseProfile());
    mc.AddProfile(new TemporadaProfile());

    //Cliente
    mc.AddProfile(new TipoCuentaProfile());

    mc.AddProfile(new RolProfile());

    //monitor
    mc.AddProfile(new MonitorProfile());

    //persona
    mc.AddProfile(new PersonaProfile());
});



IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


//var builderSecurity = builder.Services.AddIdentityCore<Usuario>();

var builderSecurity = builder.Services.AddIdentityCore<Usuario>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<AppDbContext>()
                .AddTokenProvider<DataProtectorTokenProvider<Usuario>>(TokenOptions.DefaultProvider);


var identityBuilder = new IdentityBuilder(builderSecurity.UserType, builder.Services);

identityBuilder.AddEntityFrameworkStores<AppDbContext>();

identityBuilder.AddSignInManager<SignInManager<Usuario>>();


builder.Services.AddSingleton<ISystemClock, SystemClock>();

builder.Services.AddScoped<IJwtGenerador, JwtGenerador>();

builder.Services.AddScoped<IUsuarioSesion, UsuarioSesion>(); 

builder.Services.AddScoped<IUserAuthsRepository, UserAuthsRepository>();

var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Mi palabra secreta"));



builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {

        opt.TokenValidationParameters = new TokenValidationParameters
        {

            ValidateIssuerSigningKey = true,
            IssuerSigningKey = key,
            ValidateAudience = false,
            ValidateIssuer = false,
        };
    });


builder.Services.AddCors(o => o.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ManagerMiddleware>();

app.UseAuthentication();

app.UseCors("corsapp");

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var ambiente = app.Services.CreateScope())
{

    var services = ambiente.ServiceProvider;
    try
    {

        var userManager = services.GetRequiredService<UserManager<Usuario>>(); 

        var context = services.GetRequiredService<AppDbContext>();

        await context.Database.MigrateAsync();

        await LoadDatabase.InsertarDatos(context, userManager);


    } 
    catch (Exception ex)
    {

        var logging = services.GetRequiredService<ILogger<Program>>();
        logging.LogError(ex, "Ocurrio un error en la migracion");

    }

}

app.Run();
