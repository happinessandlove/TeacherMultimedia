namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Devices", "IP", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Devices", "IP");
        }
    }
}
