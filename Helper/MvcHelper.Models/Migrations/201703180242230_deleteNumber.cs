namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteNumber : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Devices", "Number");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Devices", "Number", c => c.String(nullable: false));
        }
    }
}
