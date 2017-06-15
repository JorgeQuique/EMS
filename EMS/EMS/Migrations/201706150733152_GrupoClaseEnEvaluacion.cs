namespace EMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GrupoClaseEnEvaluacion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Evaluacions", "GrupoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Evaluacions", "GrupoId");
            AddForeignKey("dbo.Evaluacions", "GrupoId", "dbo.GruposClases", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Evaluacions", "GrupoId", "dbo.GruposClases");
            DropIndex("dbo.Evaluacions", new[] { "GrupoId" });
            DropColumn("dbo.Evaluacions", "GrupoId");
        }
    }
}
