namespace ProjectManagementTool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResourcePerson : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ResourcePerson",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ResourcePerson");
        }
    }
}
