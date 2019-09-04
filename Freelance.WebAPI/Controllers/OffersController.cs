using Freelance.DAL.Abstract;
using Freelance.DAL.Concrete.EntityFramework;
using Freelance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Freelance.WebAPI.Controllers
{
    public class OffersController : ApiController
    {
        IOfferDal offerDal = new EFOfferDal();
        

        [HttpGet]
        [ActionName("GetAll")]
        public IHttpActionResult Get()
        {
            List<Offer> offers = offerDal.GetAll();

            if (offers != null)
            {
                return Ok(offers);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [ActionName("GetById")]
        public IHttpActionResult Get(int id)
        {
            Offer offer = offerDal.GetOffer(id);

            if (offer != null)
            {
                return Ok(offer);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpGet]
        [ActionName("GetByProjectId")]
        public IHttpActionResult GetOffersByProjectId(int projectId)
        {
            List<Offer> offers = offerDal.GetOffersByProjectId(projectId);

            if (offers != null)
            {
                return Ok(offers);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        [ActionName("Add")]
        public IHttpActionResult Post(Offer offer)
        {

            if (offer != null)
            {
                if (ModelState.IsValid)
                {
                    Offer createdOffer = offerDal.CreateOffer(offer);
                    return CreatedAtRoute("DefaultApi", new { id = createdOffer.Id }, createdOffer);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            else
            {
                return BadRequest("Offer can not be Null.");
            }

        }

        [HttpPost]
        [ActionName("Accept")]
        public IHttpActionResult Accept(Offer offer)
        {

            if (offer != null)
            {
                if (ModelState.IsValid)
                {
                    bool isAccepted = offerDal.AcceptOffer(offer);
                    if (isAccepted)
                    {
                        return Ok(true);
                    }
                    else
                    {
                        return Conflict();
                    }
                    
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            else
            {
                return BadRequest("Offer can not be Null.");
            }

        }

        [HttpPut]
        [ActionName("Update")]
        public void Put()
        {

        }

        [HttpDelete]
        [ActionName("Delete")]
        public IHttpActionResult Delete(int id)
        {
            offerDal.DeleteOffer(id);
            return Ok("Offer deleted");
        }
    }
}
