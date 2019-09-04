using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelance.Entities
{
    public class Project
    {
        public int Id { get; set; }

        public int OwnerId { get; set; }

        public int? WorkerId { get; set; }

        public string Header { get; set; }

        public string Description { get; set; }
        
        public bool IsCompletedOwner { get; set; }

        public bool IsCompletedWorker { get; set; }

        public DateTime ReleaseTime { get; set; }

        public DateTime DeadlineTime { get; set; }

        public int MaxPrice { get; set; }

        public int StateId { get; set; }

    }

    
}
