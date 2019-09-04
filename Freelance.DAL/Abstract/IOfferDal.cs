using Freelance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelance.DAL.Abstract
{
    public interface IOfferDal
    {

        List<Offer> GetAll();

        Offer GetOffer(int id);

        List<Offer> GetOffersByProjectId(int projectId);

        Offer CreateOffer(Offer offer);

        Offer UpdateOffer(Offer offerToUpdate);

        void DeleteOffer(int id);

        bool IsExistById(int id);

        bool AcceptOffer(Offer offer);

    }
}
