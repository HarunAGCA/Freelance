using Freelance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelance.DAL.Abstract
{
    public interface IStateDal
    {
        State GetStateById(int id);

        

    }


}
