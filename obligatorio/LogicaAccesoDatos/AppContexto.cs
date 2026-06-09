using LogicaNegocio.EntidadesNegocio;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace LogicaAccesoDatos
{
    public class AppContexto : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Equipo>Equipos { get; set; }
        public DbSet<Camara>Camaras { get; set; }
        public DbSet<Montura>Monturas { get; set; }
        public DbSet<Telescopio>Telescopios { get; set; }
        public DbSet<Ocular>Oculares { get; set; }
        public DbSet<Prestamo>Prestamos { get; set; }
        public DbSet<Auditoria>Auditorias { get; set; } 
        public DbSet<Observacion>Observaciones { get; set; }
        public DbSet<CuerpoCeleste> CuerposCelestes { get; set; }
        public AppContexto (DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}
