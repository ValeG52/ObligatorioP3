using CasosDeUso.InterfacesCasosDeUso;
using CasosDeUso.InterfacesCasosDeUso.ICUEnumerados;
using CasosDeUso.InterfacesCasosDeUso.ICUEquipo;
using CasosDeUso.InterfacesCasosDeUso.ICUPrestamo;
using CasosDeUso.InterfacesCasosDeUso.ICUUsuarios;
using CasosDeUso.ManejoUsuarios;
using LogicaAccesoDatos;
using LogicaAccesoDatos.Repositorios;
using LogicaAplicacion.CasosDeUsoEnum;
using LogicaAplicacion.CasosDeUsoEquipo;
using LogicaAplicacion.CasosDeUsoPrestamo;
using LogicaAplicacion.CasosDeUsoUsuario;
using LogicaDeAplicacion.CasosDeUsoUsuario;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<ICULoginUsuario, CULoginUsuario>();
builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuarioEF>();
builder.Services.AddScoped<IRepositorioEquipo, RepositorioEquipoEF>();
builder.Services.AddScoped<ICUAltaUsuario, CUAltaUsuario>();
builder.Services.AddScoped<ICUAltaCamara, CUAltaCamara>();
builder.Services.AddScoped<ICUListadoSensor, CUListadoSensor>();
builder.Services.AddScoped<ICUAltaTelescopio, CUAltaTelescopio>();
builder.Services.AddScoped<ICUListadoTipoMontura, CUListadoTipoMontura>();
builder.Services.AddScoped<ICUAltaMontura, CUAltaMontura>();
builder.Services.AddScoped<ICUAltaOcular, CUAltaOcular>();
builder.Services.AddScoped<ICUListadoEquipo, CUListadoEquipo>();
builder.Services.AddScoped<ICUDeleteEquipo, CUDeleteEquipo>();
builder.Services.AddScoped<ICUBuscarEquipo, CUBuscarEquipo>();
builder.Services.AddScoped<ICUModificarEquipo, CUModificarEquipo>();
builder.Services.AddScoped<ICUListadoMontura, CUListadoMontura>();
builder.Services.AddScoped<ICUListadoOcular, CUListadoOcular>();
builder.Services.AddScoped<ICUListadoTelescopio, CUListadoTelescopio>();
builder.Services.AddScoped<ICUListadoUsuario, CUListadoUsuario>();
builder.Services.AddScoped<ICUListadoCamara, CUListadoCamara>();
builder.Services.AddScoped<ICUAltaPrestamo, CUAltaPrestamo>();
builder.Services.AddScoped<IRepositorioPrestamo, RepositorioPrestamoEF>();
builder.Services.AddScoped<ICUListadoPrestamo, CUListadoPrestamo>();
builder.Services.AddScoped<ICUModificarPrestamo, CUModificarPrestamo>();



string cadenaConexion = builder.Configuration.GetConnectionString("CadenaConexion");
builder.Services.AddDbContext<AppContexto>(options => options.UseSqlServer(cadenaConexion));

var app = builder.Build();

////Comienza JWT////
var claveSecreta = "ZWRpw6fDo28gZW0gY29tcHV0YWRvcmE=";

builder.Services.AddAuthentication(aut =>
{
    aut.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    aut.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(aut =>
{
    aut.RequireHttpsMetadata = false;
    aut.SaveToken = true;
    aut.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(claveSecreta)),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true
    };
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
