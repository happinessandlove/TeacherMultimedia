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
            context.SaveChanges();
        }
    }
}
