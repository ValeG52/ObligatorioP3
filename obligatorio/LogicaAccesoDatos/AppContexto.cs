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
        public DbSet<Oculares>Oculares { get; set; }
        public AppContexto (DbContextOptions options) : base(options) { }


    }
}
