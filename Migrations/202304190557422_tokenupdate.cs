namespace StudentAppln4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tokenupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logins", "Token", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Logins", "Token");
        }
    }
}
