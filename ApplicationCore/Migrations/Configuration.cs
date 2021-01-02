namespace ApplicationCore.Migrations
{
    using DomainModels.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationCore.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationCore.DatabaseContext context)
        {
            //Category c1 = new Category { Name = "Book" };
            //Category c2 = new Category { Name = "Toys" };

            //context.categories.Add(c1);
            //context.categories.Add(c2);

            //Role r1 = new Role { Name = "admin", Description = "Administration" };
            //Role r2 = new Role { Name = "user", Description = "End User" };

            //User user1 = new User
            //{
            //    Name = "Admin",
            //    UserName = "admin",
            //    Password = "123456",
            //    ContactNo = "01677180033",
            //    Address = "Dhaka"
            //};
            //User user2 = new User
            //{
            //    Name = "User",
            //    UserName = "user",
            //    Password = "123456",
            //    ContactNo = "01677180033",
            //    Address = "Dhaka"
            //};

            //user1.Roles.Add(r1);
            //user2.Roles.Add(r2);

            //context.Users.Add(user1);
            //context.Users.Add(user2);
        }
    }
}
