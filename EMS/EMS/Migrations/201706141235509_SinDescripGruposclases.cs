namespace EMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SinDescripGruposclases : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.GruposClases", "numAlumnos");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GruposClases", "numAlumnos", c => c.Int(nullable: false));
        }
    }
}
