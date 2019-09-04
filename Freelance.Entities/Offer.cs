using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelance.Entities
{
    public class Offer
    {

        public int Id { get; set; }

        public int ProjectId { get; set; }

        public int UserId { get; set; }

        public int OfferPrice { get; set; }

        public string Description { get; set; }

        public Project Project { get; set; }

        public User User { get; set; }

    }
}
