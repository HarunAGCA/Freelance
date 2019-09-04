using Freelance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelance.DAL.Abstract
{
    public interface IPaymentDal
    {

        void AddToPool(Payment payment);

        void MakePayment(Payment payment);

        Payment FindByProjectId(int projectId);

        List<Payment> getByProjectId(int projectId);

        void Delete(int id);

    }
}
