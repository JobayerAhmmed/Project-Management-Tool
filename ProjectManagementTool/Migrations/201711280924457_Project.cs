namespace ProjectManagementTool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProjectInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Project",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CodeName = c.String(),
                        Description = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Duration = c.String(),
                        FilePath = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Project");
        }
    }
}
