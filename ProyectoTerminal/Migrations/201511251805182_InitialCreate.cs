namespace ProyectoTerminal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notas",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Texto = c.String(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        Proyecto_Id = c.Guid(nullable: false),
                        Usuario_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Proyectoes", t => t.Proyecto_Id, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_Id, cascadeDelete: true)
                .Index(t => t.Proyecto_Id)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "dbo.Proyectoes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nombre = c.String(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        Activo = c.Boolean(nullable: false),
                        Descripcion = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Documentoes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Texto = c.String(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        FechaModificacion = c.DateTime(nullable: false),
                        CreadoPor_Id = c.Guid(nullable: false),
                        Proyecto_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.CreadoPor_Id, cascadeDelete: true)
                .ForeignKey("dbo.Proyectoes", t => t.Proyecto_Id, cascadeDelete: true)
                .Index(t => t.CreadoPor_Id)
                .Index(t => t.Proyecto_Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nombre = c.String(nullable: false),
                        Direccion = c.String(),
                        Telefono = c.String(),
                        Email = c.String(nullable: false),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tareas",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nombre = c.String(nullable: false),
                        Descripcion = c.String(nullable: false),
                        Activa = c.Boolean(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        FechaCompleatacion = c.DateTime(nullable: false),
                        Proyecto_Id = c.Guid(nullable: false),
                        UsuarioAsignado_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Proyectoes", t => t.Proyecto_Id, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioAsignado_Id, cascadeDelete: true)
                .Index(t => t.Proyecto_Id)
                .Index(t => t.UsuarioAsignado_Id);
            
            CreateTable(
                "dbo.Metas",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FechaCompletacionPlaneada = c.DateTime(nullable: false),
                        Nombre = c.String(nullable: false),
                        FechaCompletacionActual = c.DateTime(nullable: false),
                        Proyecto_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Proyectoes", t => t.Proyecto_Id)
                .Index(t => t.Proyecto_Id);
            
            CreateTable(
                "dbo.Repositorios",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nombre = c.String(nullable: false),
                        Url = c.String(nullable: false),
                        Usuario_Id = c.Guid(),
                        Proyecto_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_Id)
                .ForeignKey("dbo.Proyectoes", t => t.Proyecto_Id)
                .Index(t => t.Usuario_Id)
                .Index(t => t.Proyecto_Id);
            
            CreateTable(
                "dbo.UsuarioProyectoes",
                c => new
                    {
                        Usuario_Id = c.Guid(nullable: false),
                        Proyecto_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Usuario_Id, t.Proyecto_Id })
                .ForeignKey("dbo.Usuarios", t => t.Usuario_Id, cascadeDelete: true)
                .ForeignKey("dbo.Proyectoes", t => t.Proyecto_Id, cascadeDelete: true)
                .Index(t => t.Usuario_Id)
                .Index(t => t.Proyecto_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notas", "Usuario_Id", "dbo.Usuarios");
            DropForeignKey("dbo.Notas", "Proyecto_Id", "dbo.Proyectoes");
            DropForeignKey("dbo.Repositorios", "Proyecto_Id", "dbo.Proyectoes");
            DropForeignKey("dbo.Repositorios", "Usuario_Id", "dbo.Usuarios");
            DropForeignKey("dbo.Metas", "Proyecto_Id", "dbo.Proyectoes");
            DropForeignKey("dbo.Documentoes", "Proyecto_Id", "dbo.Proyectoes");
            DropForeignKey("dbo.Documentoes", "CreadoPor_Id", "dbo.Usuarios");
            DropForeignKey("dbo.Tareas", "UsuarioAsignado_Id", "dbo.Usuarios");
            DropForeignKey("dbo.Tareas", "Proyecto_Id", "dbo.Proyectoes");
            DropForeignKey("dbo.UsuarioProyectoes", "Proyecto_Id", "dbo.Proyectoes");
            DropForeignKey("dbo.UsuarioProyectoes", "Usuario_Id", "dbo.Usuarios");
            DropIndex("dbo.UsuarioProyectoes", new[] { "Proyecto_Id" });
            DropIndex("dbo.UsuarioProyectoes", new[] { "Usuario_Id" });
            DropIndex("dbo.Repositorios", new[] { "Proyecto_Id" });
            DropIndex("dbo.Repositorios", new[] { "Usuario_Id" });
            DropIndex("dbo.Metas", new[] { "Proyecto_Id" });
            DropIndex("dbo.Tareas", new[] { "UsuarioAsignado_Id" });
            DropIndex("dbo.Tareas", new[] { "Proyecto_Id" });
            DropIndex("dbo.Documentoes", new[] { "Proyecto_Id" });
            DropIndex("dbo.Documentoes", new[] { "CreadoPor_Id" });
            DropIndex("dbo.Notas", new[] { "Usuario_Id" });
            DropIndex("dbo.Notas", new[] { "Proyecto_Id" });
            DropTable("dbo.UsuarioProyectoes");
            DropTable("dbo.Repositorios");
            DropTable("dbo.Metas");
            DropTable("dbo.Tareas");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Documentoes");
            DropTable("dbo.Proyectoes");
            DropTable("dbo.Notas");
        }
    }
}
