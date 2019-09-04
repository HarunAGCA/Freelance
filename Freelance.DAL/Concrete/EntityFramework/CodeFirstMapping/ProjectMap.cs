using Freelance.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelance.DAL.Concrete.EntityFramework.CodeFirstMapping
{
    public class ProjectMap : EntityTypeConfiguration<Project>
    {

        public ProjectMap()
        {
            this.HasKey(x => x.Id);


            this.Property(x => x.Id)
                .HasColumnOrder(0);

            this.Property(x => x.Header)
                .HasColumnOrder(1)
                .IsRequired();

            this.Property(x => x.Description)
                .HasColumnOrder(2)
                .IsRequired();

            this.Property(x => x.MaxPrice)
                .HasColumnOrder(3)
                .IsRequired();

            this.Property(x => x.ReleaseTime)
                .HasColumnOrder(4)
                .HasColumnType("DateTime2");

            this.Property(x => x.DeadlineTime)
                .HasColumnOrder(5)
                .HasColumnType("DateTime2");

            this.Property(x => x.OwnerId)
                .HasColumnOrder(6)
                .IsRequired();

            this.Property(x => x.WorkerId)
                .HasColumnOrder(7);

            this.Property(x => x.IsCompletedOwner)
                .HasColumnOrder(8);

            this.Property(x => x.IsCompletedWorker)
                .HasColumnOrder(9);

            this.Property(x => x.StateId)
                .HasColumnOrder(10);


            this.ToTable("Projects");
            this.Property(x => x.Id).HasColumnName("Id");
            this.Property(x => x.Header).HasColumnName("Header");
            this.Property(x => x.Description).HasColumnName("Description");
            this.Property(x => x.MaxPrice).HasColumnName("MaxPrice");
            this.Property(x => x.ReleaseTime).HasColumnName("ReleaseTime");
            this.Property(x => x.DeadlineTime).HasColumnName("DeadlineTime");
            this.Property(x => x.OwnerId).HasColumnName("OwnerId");
            this.Property(x => x.WorkerId).HasColumnName("WorkerId");
            this.Property(x => x.IsCompletedOwner).HasColumnName("IsCompletedOwner");
            this.Property(x => x.IsCompletedWorker).HasColumnName("IsCompletedWorker");
            this.Property(x => x.StateId).HasColumnName("StateId");

        }

    }
}
