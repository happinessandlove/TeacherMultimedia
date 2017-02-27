namespace Models.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Models.DbEntity>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Models.DbEntity context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
             context.Roles.AddOrUpdate(
                 p => p.Name,
                 new Role { Id = Guid.Parse("00000000-0000-0000-0000-000000000001"), Name = "admin", MenuId = "{\"SystemManage\":true,\"PersonalUser\":true,\"Details_PersonalUser\":true,\"Edit_PersonalUser\":true,\"ModifyPwd_PersonalUser\":true,\"User\":true,\"Index_User\":true,\"Create_User\":true,\"Edit_User\":true,\"Delete_User\":true,\"Details_User\":true,\"Role\":true,\"Index_Role\":true,\"Create_Role\":true,\"Edit_Role\":true,\"Delete_Role\":true}" }
                 );
             context.Users.AddOrUpdate(
                 p => p.LoginName,
                 new User { Id = Guid.Parse("00000000-0000-0000-0000-000000000001"), LoginName = "admin", Password = "E82E3BDFC2D138E66BF4AE06F3168583", Name = "admin", CreateTime = DateTime.Now, Status = UserStatus.Normal, RoleId = Guid.Parse("00000000-0000-0000-0000-000000000001") }
                 );
             context.DeviceUseRecords.AddOrUpdate(
                 p => p.OpenTime,
                 new DeviceUseRecord { Id = Guid.Parse("00000000-0000-0001-0000-000000000000"), OpenTime = DateTime.Now, CloseTime = DateTime.Now, UserId = Guid.Parse("00000000-0000-0000-0000-000000000001") },
                 new DeviceUseRecord { Id = Guid.Parse("00000000-0000-0002-0000-000000000000"), OpenTime = DateTime.Now, CloseTime = DateTime.Now, UserId = Guid.Parse("00000000-0000-0000-0000-000000000001") }
                 );

             var Buildings = new[]
             {
                 new Building { Id = Guid.Parse("00000000-0000-0000-0001-000000000000"), Number="1号楼"},
                 new Building { Id = Guid.Parse("00000000-0000-0000-0002-000000000000"), Number = "2号楼" }

             };


             context.Buildings.AddOrUpdate(p => p.Number, Buildings);
             context.SaveChanges();

             var ClassRooms = new ClassRoom[]
             {
                 new ClassRoom { Id = Guid.Parse("00000000-0001-0000-0000-000000000000"), BuildingId = Guid.Parse("00000000-0000-0000-0001-000000000000"), Number = "101" },
                 new ClassRoom { Id = Guid.Parse("00000000-0002-0000-0000-000000000000"), BuildingId = Guid.Parse("00000000-0000-0000-0001-000000000000"), Number = "102" },
                 new ClassRoom { Id = Guid.Parse("00000000-0003-0000-0000-000000000000"), BuildingId = Guid.Parse("00000000-0000-0000-0001-000000000000"), Number = "103" },
                 new ClassRoom { Id = Guid.Parse("00000000-0004-0000-0000-000000000000"), BuildingId = Guid.Parse("00000000-0000-0000-0002-000000000000"), Number = "101" },
                 new ClassRoom { Id = Guid.Parse("00000000-0005-0000-0000-000000000000"), BuildingId = Guid.Parse("00000000-0000-0000-0002-000000000000"), Number = "102" },
                 new ClassRoom { Id = Guid.Parse("00000000-0006-0000-0000-000000000000"), BuildingId = Guid.Parse("00000000-0000-0000-0002-000000000000"), Number = "103" }

             };

             context.ClassRooms.AddOrUpdate(p => p.Number, ClassRooms);
             context.SaveChanges();


            context.Devices.Add(new Device { ClassRoomId = Guid.Parse("00000000-0001-0000-0000-000000000000"), Number = "45672458", AddTime = DateTime.Now, AddName = "刘明", State = true, Remark = "无" });
             context.Devices.Add(new Device { ClassRoomId = Guid.Parse("00000000-0002-0000-0000-000000000000"), Number = "05672458", AddTime = DateTime.Now, AddName = "刘明", State = true, Remark = "无" });
             context.Devices.Add(new Device { ClassRoomId = Guid.Parse("00000000-0003-0000-0000-000000000000"), Number = "95672458", AddTime = DateTime.Now, AddName = "刘明", State = true, Remark = "无" });
             context.Devices.Add(new Device { ClassRoomId = Guid.Parse("00000000-0004-0000-0000-000000000000"), Number = "35672458", AddTime = DateTime.Now, AddName = "刘明", State = true, Remark = "无" });
             context.Devices.Add(new Device { ClassRoomId = Guid.Parse("00000000-0005-0000-0000-000000000000"), Number = "15672458", AddTime = DateTime.Now, AddName = "刘明", State = true, Remark = "无" });
             context.Devices.Add(new Device { ClassRoomId = Guid.Parse("00000000-0006-0000-0000-000000000000"), Number = "25672458", AddTime = DateTime.Now, AddName = "刘明", State = true, Remark = "无" });
             base.Seed(context);
        }
    }
    }
