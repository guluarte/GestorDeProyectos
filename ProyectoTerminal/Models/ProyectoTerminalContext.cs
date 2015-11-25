using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProyectoTerminal.Models
{
    public class ProyectoTerminalContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ProyectoTerminalContext() : base("name=ProyectoTerminalContext")
        {
        }

        public System.Data.Entity.DbSet<ProyectoTerminal.Models.Nota> Notas { get; set; }

        public System.Data.Entity.DbSet<ProyectoTerminal.Models.Requerimiento> Requerimientoes { get; set; }

        public System.Data.Entity.DbSet<ProyectoTerminal.Models.Documento> Documentoes { get; set; }

        public System.Data.Entity.DbSet<ProyectoTerminal.Models.Proyecto> Proyectoes { get; set; }

        public System.Data.Entity.DbSet<ProyectoTerminal.Models.Usuario> Usuarios { get; set; }

        public System.Data.Entity.DbSet<ProyectoTerminal.Models.Meta> Metas { get; set; }

        public System.Data.Entity.DbSet<ProyectoTerminal.Models.Tarea> Tareas { get; set; }

        public System.Data.Entity.DbSet<ProyectoTerminal.Models.Repositorio> Repositorios { get; set; }
    
    }
}
