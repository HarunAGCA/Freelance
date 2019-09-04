using Freelance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Freelance.MvcWebUI.Models
{
    public class MyProjectsAsOwnerViewModel
    {
        public List<Project> Projects { get; set; }

        public List<OfferViewModel> Offers { get; set; }

    }
}