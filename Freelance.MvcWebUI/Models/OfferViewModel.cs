using Freelance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Freelance.MvcWebUI.Models
{
    public class OfferViewModel
    {
        public Offer Offer { get; set; }

        public User OfferOwner { get; set; }
    }
}