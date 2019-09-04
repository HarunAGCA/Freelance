using Freelance.DAL.Concrete.EntityFramework;
using Freelance.DAL.Abstract;
using Freelance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Freelance.MvcWebUI.Models
{
    public class ProjectStateViewModel
    {
        public Project Project { get; set; }
        public State State { get; set; }
        public IStateDal _stateDal;
    }
}