namespace StudentAppln4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewDesk : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Student1",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        StudentId1 = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        RecStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Student1");
        }
    }
}
