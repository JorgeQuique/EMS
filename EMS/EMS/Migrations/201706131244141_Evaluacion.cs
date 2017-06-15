namespace EMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Evaluacion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Evaluacions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        convocatoria = c.Int(nullable: false),
                        Trabajo1 = c.Int(nullable: false),
                        Trabajo2 = c.Int(nullable: false),
                        Trabajo3 = c.Int(nullable: false),
                        Examen = c.Int(nullable: false),
                        Practica = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        CursoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cursos", t => t.CursoId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.CursoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Evaluacions", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Evaluacions", "CursoId", "dbo.Cursos");
            DropIndex("dbo.Evaluacions", new[] { "CursoId" });
            DropIndex("dbo.Evaluacions", new[] { "UserId" });
            DropTable("dbo.Evaluacions");
        }
    }
}
