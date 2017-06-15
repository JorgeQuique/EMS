namespace EMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GruposClase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GruposClases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        descripcion = c.String(),
                        numAlumnos = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GruposClases");
        }
    }
}
