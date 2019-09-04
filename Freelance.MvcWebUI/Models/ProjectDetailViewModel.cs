using Freelance.DAL.Concrete.EntityFramework;
using Freelance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Freelance.MvcWebUI.Models
{
    public class ProjectDetailViewModel
    {
        public Project Project { get; set; }

        public List<Offer> Offers { get; set; }

        public User Owner { get; set; }

        public User Worker { get; set; }

        public EFUserDal EFUserDal { get; set; }

    }
}