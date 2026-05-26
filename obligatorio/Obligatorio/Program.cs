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

namespace Obligatorio
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // La sesión dura 30 min
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });



            // Add services to the container.
            builder.Services.AddControllersWithViews();


            // Conectamos las interfaces con las clases reales
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








            string cadenaConexion = builder.Configuration.GetConnectionString("CadenaConexion");
            builder.Services.AddDbContext<AppContexto>(options => options.UseSqlServer(cadenaConexion));

            var app = builder.Build();

            app.UseSession();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
