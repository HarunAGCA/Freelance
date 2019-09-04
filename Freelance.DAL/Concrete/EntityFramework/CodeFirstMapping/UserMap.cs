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
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            this.HasKey(x => x.Id);


            this.Property(x => x.Id)
                .IsRequired()
                .HasColumnOrder(0);

            this.Property(x => x.Name)
                .HasColumnOrder(1)
                .IsRequired();

            this.Property(x => x.Mail)
                .HasColumnOrder(2)
                .IsRequired();

            this.Property(x => x.Password)
                .HasColumnOrder(3)
                .IsRequired();

            this.Property(x => x.Credit)
                .HasColumnOrder(4);


            this.ToTable("Users");
            this.Property(x => x.Id).HasColumnName("Id");
            this.Property(x => x.Name).HasColumnName("Name");
            this.Property(x => x.Mail).HasColumnName("Mail");
            this.Property(x => x.Password).HasColumnName("Password");
            this.Property(x => x.Credit).HasColumnName("Credit");

        }
    }
}
