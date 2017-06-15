namespace EMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Curso : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Cursos", "numAlumnos");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cursos", "numAlumnos", c => c.String());
        }
    }
}
