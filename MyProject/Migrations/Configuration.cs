namespace MyProject.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyProject.Models.UserDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MyProject.Models.UserDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //Use on initial setup to populate the local database with dummy data for testing

            //context.Users.AddOrUpdate(
            //    new Models.User() { Username = "Denis", Password = "Denis" },
            //    new Models.User() { Username = "Sergio", Password = "Sergio" },
            //    new Models.User() { Username = "James", Password = "Jammy" }
            //    );
        }
    }
}
