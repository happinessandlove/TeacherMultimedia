namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class empty : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Buildings",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Number = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClassRooms",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Number = c.String(nullable: false, maxLength: 10),
                        BuildingId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Buildings", t => t.BuildingId)
                .Index(t => t.BuildingId);
            
            CreateTable(
                "dbo.Devices",
                c => new
                    {
                        ClassRoomId = c.Guid(nullable: false),
                        Number = c.String(nullable: false),
                        AddTime = c.DateTime(nullable: false),
                        AddName = c.String(maxLength: 10),
                        State = c.Boolean(nullable: false),
                        Remark = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ClassRoomId)
                .ForeignKey("dbo.ClassRooms", t => t.ClassRoomId)
                .Index(t => t.ClassRoomId);
            
            CreateTable(
                "dbo.DeviceUseRecords",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        OpenTime = c.DateTime(nullable: false),
                        CloseTime = c.DateTime(nullable: false),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RoleId = c.Guid(nullable: false),
                        LoginName = c.String(nullable: false, maxLength: 10),
                        Password = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false, maxLength: 20),
                        LivingAddress = c.String(maxLength: 200),
                        TelephoneNumber = c.String(maxLength: 20),
                        MobileNumber = c.String(maxLength: 20),
                        IDCardNumber = c.String(maxLength: 50),
                        CreateTime = c.DateTime(nullable: false),
                        Introduction = c.String(maxLength: 1000),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 20),
                        MenuId = c.String(nullable: false),
                        Remarks = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.DeviceUseRecords", "UserId", "dbo.Users");
            DropForeignKey("dbo.Devices", "ClassRoomId", "dbo.ClassRooms");
            DropForeignKey("dbo.ClassRooms", "BuildingId", "dbo.Buildings");
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.DeviceUseRecords", new[] { "UserId" });
            DropIndex("dbo.Devices", new[] { "ClassRoomId" });
            DropIndex("dbo.ClassRooms", new[] { "BuildingId" });
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.DeviceUseRecords");
            DropTable("dbo.Devices");
            DropTable("dbo.ClassRooms");
            DropTable("dbo.Buildings");
        }
    }
}
