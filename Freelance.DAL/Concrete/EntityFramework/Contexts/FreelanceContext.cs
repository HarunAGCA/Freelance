using Freelance.DAL.Concrete.EntityFramework.CodeFirstMapping;
using Freelance.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelance.DAL.Concrete.EntityFramework.Contexts
{
    class FreelanceContext:DbContext
    {

        public DbSet<Project> Projects { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Offer> Offers { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<State> States { get; set; }


        public FreelanceContext():base("name=FreelanceTestConnectionString")
        {
            Database.SetInitializer<FreelanceContext>(new DropCreateDatabaseIfModelChanges<FreelanceContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new ProjectMap());
            modelBuilder.Configurations.Add(new OfferMap());
            modelBuilder.Configurations.Add(new MessageMap());
            modelBuilder.Configurations.Add(new PaymentMap());
            modelBuilder.Configurations.Add(new StateMap());
            

        }

    }
}
