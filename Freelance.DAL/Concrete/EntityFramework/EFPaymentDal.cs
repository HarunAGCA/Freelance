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
    public class EFPaymentDal : IPaymentDal
    {
        FreelanceContext freelanceContext = new FreelanceContext();
        IUserDal userDal = new EFUserDal();
        
        public void AddToPool(Payment payment)
        {
            freelanceContext.Payments.Add(payment);
            freelanceContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Payment payment = freelanceContext.Payments.FirstOrDefault(x => x.Id == id);
            freelanceContext.Payments.Remove(payment);
            freelanceContext.SaveChanges();
        }

        public Payment FindByProjectId(int projectId)
        {
            return freelanceContext.Payments.FirstOrDefault(x => x.ProjectId == projectId);
        }

        public List<Payment> getByProjectId(int projectId)
        {
            List<Payment> payments = freelanceContext.Payments.Where(x => x.ProjectId == projectId).ToList();
            return payments;
        }

        public void MakePayment(Payment payment)
        {
            Project project = freelanceContext.Projects.FirstOrDefault(x => x.Id == payment.ProjectId);
            int ownerId = project.OwnerId;
            int workerId = (int)project.WorkerId;
            int acceptedPrice = payment.AcceptedPrice;
            userDal.IncreaseCredit(workerId, acceptedPrice);
            userDal.DecreaseCredit(ownerId, acceptedPrice);
        }

        
    }
}
