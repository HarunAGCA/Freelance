namespace Freelance.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Freelance.DAL.Concrete.EntityFramework.Contexts.FreelanceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Freelance.DAL.Concrete.EntityFramework.Contexts.FreelanceContext";
        }

        protected override void Seed(Freelance.DAL.Concrete.EntityFramework.Contexts.FreelanceContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
