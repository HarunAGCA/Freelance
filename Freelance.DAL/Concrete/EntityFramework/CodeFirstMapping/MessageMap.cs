using Freelance.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelance.DAL.Concrete.EntityFramework.CodeFirstMapping
{
    public class MessageMap: EntityTypeConfiguration<Message>
    {

        public MessageMap()
        {
            this.HasKey(x => x.Id);


            this.Property(x => x.Id)
                .HasColumnOrder(0);

            this.Property(x => x.SenderId)
                .HasColumnOrder(1)
                .IsRequired();

            this.Property(x => x.ReceiverId)
                .HasColumnOrder(2)
                .IsRequired();

            this.Property(x => x.Content)
                .HasColumnOrder(3)
                .IsRequired();
            

            this.ToTable("Messages");
            this.Property(x => x.Id).HasColumnName("Id");
            this.Property(x => x.SenderId).HasColumnName("SenderId");
            this.Property(x => x.ReceiverId).HasColumnName("ReceiverId");
            this.Property(x => x.Content).HasColumnName("Content");

        }
    }
}
