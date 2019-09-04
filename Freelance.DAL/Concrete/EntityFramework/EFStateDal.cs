using Freelance.DAL.Abstract;
using Freelance.DAL.Concrete.EntityFramework.Contexts;
using Freelance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelance.DAL.Concrete.EntityFramework
{
    public class EFStateDal : IStateDal
    {
        FreelanceContext freelanceContext = new FreelanceContext();
        


        public State GetStateById(int id)
        {
            return freelanceContext.States.FirstOrDefault(x => x.Id == id);
        }

      
    }
}
