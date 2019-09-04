using Freelance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Freelance.MvcWebUI.Models
{
    public class UserProfileViewModel
    {
        public User User { get; set; }

        public List<Project> MyProjectsAsOwner { get; set; }

        public List<Project> MyProjectsAsWorker { get; set; }

    }
}