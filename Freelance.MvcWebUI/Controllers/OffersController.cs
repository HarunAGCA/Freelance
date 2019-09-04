using Freelance.DAL.Abstract;
using Freelance.DAL.Concrete.EntityFramework;
using Freelance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Freelance.MvcWebUI.Controllers
{
    public class OffersController : Controller
    {
        IOfferDal _offerDal = new EFOfferDal();
        IProjectDal _projectDal = new EFProjectDal();
        IPaymentDal _paymentDal = new EFPaymentDal();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ActionName("AcceptOffer")]
        public ActionResult AcceptOffer(int offerId)
        {
            Offer offer = _offerDal.GetOffer(offerId);
            Project project = _projectDal.GetProject(offer.ProjectId);
            project.StateId = 2;
            _projectDal.UpdateProject(project);
            _offerDal.AcceptOffer(offer);
            TempData.Add("message", String.Format("Teklif kabul edildi."));
            return RedirectToAction("index", "Home");
        }

        [HttpPost]
        [ActionName("GiveOffer")]
        public ActionResult GiveOffer(int projectId, FormCollection formCollection)
        {
            int offerAmount = Convert.ToInt32(formCollection["offerAmount"]);
            string offerDescription = formCollection["offerDescription"].ToString();

            Offer offer = new Offer
            {
                OfferPrice = offerAmount,
                Description = offerDescription,
                ProjectId = projectId,
                UserId = Convert.ToInt32(Session["userID"])
            };

            _offerDal.CreateOffer(offer);

            TempData.Add("message", String.Format("{0} projesine {1} TL teklif verildi.",_projectDal.GetProject(projectId).Header, offerAmount));

            return RedirectToAction("index", "Home");
        }
    }
}