using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using mipBackend.Data;
using mipBackend.Data.Inmuebles;
using mipBackend.Data.Roles;
using mipBackend.Data.Regiones;
using mipBackend.Data.Comunas;
using mipBackend.Data.Zonas;
using mipBackend.Data.Usuarios;
using mipBackend.Data.UserAuths;
using mipBackend.Data.TipoEspecie;
using mipBackend.Data.MedidaUmbrales;
using mipBackend.Data.EstadosDanios;
using mipBackend.Data.SetSelect;
using mipBackend.Data.Plantillas;
using mipBackend.Data.TipoFlujos;
using mipBackend.Data.TipoPermisos;
using mipBackend.Data.NivelFlujos;
using mipBackend.Data.NivelPermisos;
using mipBackend.Data.TipoParametros;
using mipBackend.Data.Saludos;
using mipBackend.Data.TipoPersonas;
using mipBackend.Data.TipoComPersonas;
using mipBackend.Data.TipoPerComunicaciones;
using mipBackend.Data.TipoDocumentos;
using mipBackend.Data.WorkflowParametros;
using mipBackend.Data.Areas;
using mipBackend.Data.DefaultUsers;
using mipBackend.Data.Workflows;
using mipBackend.Middleware;
using mipBackend.Models;
using mipBackend.Profiles;
using mipBackend.Token;
using System.Text;

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
builder.Services.AddScoped<ITipoEspecieRepository, TipoEspecieRepository>();
builder.Services.AddScoped<IMedidaUmbralRepository, MedidaUmbralRepository>();
builder.Services.AddScoped<IEstadosDanioRepository, EstadosDanioRepository>();
builder.Services.AddScoped<IPlantillaRepository, PlantillaRepository>();
builder.Services.AddScoped<ITipoFlujosRepository, TipoFlujosRepository>();
builder.Services.AddScoped<ITipoPermisosRepository, TipoPermisosRepository>();
builder.Services.AddScoped<IAreaRepository, AreaRepository>();
builder.Services.AddScoped<INivelFlujoRepository, NivelFlujoRepository>();
builder.Services.AddScoped<INivelPermisoRepository, NivelPermisoRepository>();
builder.Services.AddScoped<ITipoParametroRepository, TipoParametroRepository>();
builder.Services.AddScoped<ISaludoRepository, SaludoRepository>();
builder.Services.AddScoped<ITipoPersonaRepository, TipoPersonaRepository>();
builder.Services.AddScoped<ITipoComPersonaRepository, TipoComPersonaRepository>();
builder.Services.AddScoped<ITipoPerComunicacionRepository, TipoPerComunicacionRepository>();
builder.Services.AddScoped<ITipoDocumentoRepository, TipoDocumentoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IDefaultUserRepository, DefaultUserRepository>();
builder.Services.AddScoped<IWorkflowParametroRepository, WorkflowParametroRepository>();
builder.Services.AddScoped<IWorkflowRepository, WorkflowRepository>();
builder.Services.AddScoped<IPlantillaFlujoRepository, PlantillaFlujoRepository>();

builder.Services.AddScoped<IRolesRepository, RolesRepository>();

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
    mc.AddProfile(new TipoEspecieProfile());
    mc.AddProfile(new MedidaUmbralProfile());
    mc.AddProfile(new EstadosDanioProfile());
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
    mc.AddProfile(new TipoPersonaProfile());
    mc.AddProfile(new TipoDocumentoProfile());
    mc.AddProfile(new TipoComPersonaProfile());
    mc.AddProfile(new TipoPerComunicacionProfile());

    //workflow
    mc.AddProfile(new TipoFlujoProfile());
    mc.AddProfile(new TipoPermisoProfile());
    mc.AddProfile(new TipoParametroProfile());
    mc.AddProfile(new NivelFlujoProfile());
    mc.AddProfile(new NivelPermisoProfile());

    //Cliente
    mc.AddProfile(new TipoCuentaProfile());

    mc.AddProfile(new RolProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var builderSecurity = builder.Services.AddIdentityCore<Usuario>();

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
