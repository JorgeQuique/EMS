namespace EMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Docencia : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Docencias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CursoId = c.Int(nullable: false),
                        GrupoId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cursos", t => t.CursoId, cascadeDelete: true)
                .ForeignKey("dbo.GruposClases", t => t.GrupoId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.CursoId)
                .Index(t => t.GrupoId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Docencias", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Docencias", "GrupoId", "dbo.GruposClases");
            DropForeignKey("dbo.Docencias", "CursoId", "dbo.Cursos");
            DropIndex("dbo.Docencias", new[] { "UserId" });
            DropIndex("dbo.Docencias", new[] { "GrupoId" });
            DropIndex("dbo.Docencias", new[] { "CursoId" });
            DropTable("dbo.Docencias");
        }
    }
}
