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
        public AppContexto (DbContextOptions options) : base(options) { }


    }
}
