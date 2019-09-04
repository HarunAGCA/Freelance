using Freelance.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelance.DAL.Concrete.EntityFramework.CodeFirstMapping
{
    class StateMap:EntityTypeConfiguration<State>
    {

        public StateMap()
        {
            this.HasKey(x => x.Id);


            this.Property(x => x.Id)
                .HasColumnOrder(0);

            this.Property(x => x.StateString)
                .HasColumnOrder(1)
                .IsRequired();


            this.ToTable("States");
            this.Property(x => x.Id).HasColumnName("Id");
            this.Property(x => x.StateString).HasColumnName("StateString");
          
        }

    
    }
}
