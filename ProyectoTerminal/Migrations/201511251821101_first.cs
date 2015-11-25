namespace ProyectoTerminal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UsuarioProyectoes", newName: "ProyectoUsuarios");
            DropPrimaryKey("dbo.ProyectoUsuarios");
            CreateTable(
                "dbo.Requerimientoes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nombre = c.String(nullable: false),
                        Descripcion = c.String(nullable: false),
                        Tipo = c.String(nullable: false),
                        Proyecto_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Proyectoes", t => t.Proyecto_Id, cascadeDelete: true)
                .Index(t => t.Proyecto_Id);
            
            AddPrimaryKey("dbo.ProyectoUsuarios", new[] { "Proyecto_Id", "Usuario_Id" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requerimientoes", "Proyecto_Id", "dbo.Proyectoes");
            DropIndex("dbo.Requerimientoes", new[] { "Proyecto_Id" });
            DropPrimaryKey("dbo.ProyectoUsuarios");
            DropTable("dbo.Requerimientoes");
            AddPrimaryKey("dbo.ProyectoUsuarios", new[] { "Usuario_Id", "Proyecto_Id" });
            RenameTable(name: "dbo.ProyectoUsuarios", newName: "UsuarioProyectoes");
        }
    }
}
