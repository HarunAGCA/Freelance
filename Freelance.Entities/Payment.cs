using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelance.Entities
{
    public class Payment
    {

        public int Id { get; set; }

        public int ProjectId { get; set; }

        public int AcceptedPrice { get; set; }

        public Project Project { get; set; }

    }
}
