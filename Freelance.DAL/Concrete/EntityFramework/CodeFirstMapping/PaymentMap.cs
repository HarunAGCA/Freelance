using Freelance.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelance.DAL.Concrete.EntityFramework.CodeFirstMapping
{
    public class PaymentMap : EntityTypeConfiguration<Payment>
    {
        public PaymentMap()
        {
            this.HasKey(x => x.Id);


            this.Property(x => x.Id)
                .HasColumnOrder(0);

            this.Property(x => x.ProjectId)
                .HasColumnOrder(1)
                .IsRequired();

            this.Property(x => x.AcceptedPrice)
                .HasColumnOrder(2)
                .IsRequired();


            this.ToTable("Payments");
            this.Property(x => x.Id).HasColumnName("Id");
            this.Property(x => x.ProjectId).HasColumnName("ProjectId");
            this.Property(x => x.AcceptedPrice).HasColumnName("AcceptedPrice");
            
        }
    }
}
