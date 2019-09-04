using Freelance.DAL.Abstract;
using Freelance.DAL.Concrete.EntityFramework.Contexts;
using Freelance.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelance.DAL.Concrete.EntityFramework
{
    public class EFOfferDal : IOfferDal
    {
        FreelanceContext freelanceContext = new FreelanceContext();
        IProjectDal projectDal = new EFProjectDal();
        IPaymentDal paymentDal = new EFPaymentDal();

        public List<Offer> GetAll()
        {
            return freelanceContext.Offers.ToList();
        }

        public Offer GetOffer(int id)
        {
            return freelanceContext.Offers.FirstOrDefault(x => x.Id == id);
        }

        public List<Offer> GetOffersByProjectId(int projectId)
        {
            List<Offer> offers = freelanceContext.Offers.Where(x => x.ProjectId == projectId).ToList();
            return offers;
        }

        public Offer CreateOffer(Offer offer)
        {
            freelanceContext.Offers.Add(offer);
            freelanceContext.SaveChanges();
            return offer;
        }

        public Offer UpdateOffer(Offer offerToUpdate)
        {
            freelanceContext.Entry(offerToUpdate).State = EntityState.Modified;
            freelanceContext.SaveChanges();

            Offer updatedOffer = freelanceContext.Offers.FirstOrDefault(x => x.Id == offerToUpdate.Id);

            return updatedOffer;
        }

        public void DeleteOffer(int id)
        {
            Offer offer = freelanceContext.Offers.FirstOrDefault(x => x.Id == id);
            freelanceContext.Offers.Remove(offer);
            freelanceContext.SaveChanges();
        }

        public bool IsExistById(int id)
        {
            Offer offer = freelanceContext.Offers.FirstOrDefault(x => x.Id == id);

            if (offer != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AcceptOffer(Offer offer)
        {
            try
            {
                if (paymentDal.FindByProjectId(offer.ProjectId) == null)
                {

                    Project project = projectDal.GetProject(offer.ProjectId);
                    project.WorkerId = offer.UserId;
                    projectDal.UpdateProject(project);
                    freelanceContext.SaveChanges();

                    Payment payment = new Payment();
                    payment.ProjectId = offer.ProjectId;
                    payment.AcceptedPrice = offer.OfferPrice;

                    paymentDal.AddToPool(payment);

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }



        }
    }
}
