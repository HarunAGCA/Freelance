using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Freelance.DAL.Abstract;
using Freelance.DAL.Concrete.EntityFramework;
using Freelance.Entities;

namespace Freelance.WebAPI.Controllers
{
    public class MessagesController : ApiController
    {

        IMessageDal messageDal = new EFMessageDal();

        [HttpGet]
        [ActionName("GetBySenderId")]
        public IHttpActionResult GetBySenderId(int senderId)
        {
            List<Message> messages = messageDal.GetBySenderId(senderId);
            return Ok(messages);
        }

        [HttpGet]
        [ActionName("GetByReceiverId")]
        public IHttpActionResult GetByReceiverId(int receiverId)
        {
            List<Message> messages = messageDal.GetByReceiverId(receiverId);
            return Ok(messages);
        }

        [HttpPost]
        [ActionName("Add")]
        public IHttpActionResult Post(Message message)
        {
            
            if (message != null)
            {
                if (ModelState.IsValid)
                {
                    Message createdMessage = messageDal.Create(message);
                    return CreatedAtRoute("DefaultApi", new { id = createdMessage.Id }, createdMessage);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            else
            {
                return BadRequest("Message can not be Null.");
            }




        }

        [HttpPut]
        [ActionName("Update")]
        public IHttpActionResult Put(Message message)
        {
            messageDal.Update(message);
            return Ok("Message updated");
        }

        [HttpDelete]
        [ActionName("Delete")]
        public IHttpActionResult Delete(int messageId)
        {
            messageDal.Delete(messageId);
            return Ok("Message deleted.");
        }

    }
}
