using Freelance.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelance.DAL.Concrete.EntityFramework.CodeFirstMapping
{
    public class OfferMap : EntityTypeConfiguration<Offer>
    {

        public OfferMap()
        {

            this.HasKey(x => x.Id);


            this.Property(x => x.Id)
                .HasColumnOrder(0);

            this.Property(x => x.UserId)
                .HasColumnOrder(1)
                .IsRequired();

            this.Property(x => x.ProjectId)
                .HasColumnOrder(2)
                .IsRequired();

            this.Property(x => x.OfferPrice)
                .HasColumnOrder(3)
                .IsRequired();

            this.Property(x => x.Description)
                .HasColumnOrder(4);


            this.ToTable("Offers");
            this.Property(x => x.Id).HasColumnName("Id");
            this.Property(x => x.UserId).HasColumnName("UserId");
            this.Property(x => x.ProjectId).HasColumnName("ProjectId");
            this.Property(x => x.OfferPrice).HasColumnName("OfferPrice");
            this.Property(x => x.Description).HasColumnName("Description");














        }
    }
}
