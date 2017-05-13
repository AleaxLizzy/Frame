namespace Frame.Data.Migrations
{
    using Frame.Core.Domain.Users;
    using Frame.Util;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Frame.Data.FrameDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(FrameDbContext context)
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


            context.Set<Customer>().AddOrUpdate(
             p => p.Type,
             new Customer
             {
                 Name = "Admin",
                 Email = "admin@hotmail.com",
                 PassWord = SignUtil.MD5Sign("888888"),
                 Active = true,
                 Type = CustomerTypeEnum.SuperAdmin,
                 CreatedTime = DateTime.Now,
                 ParentId=0,
                 Roles = new List<Role>
                 { 
                     new Role
                     {
                         Name = "超级管理员",
                         Active = true,
                         ParentId=0,
                         Type = RoleTypeEnum.SuperAdminRole,
                         CreatedTime = DateTime.Now,
                         SystemName="Admin_SuperRole"
                     }
                 }
             }
           );

        }
    }
}
