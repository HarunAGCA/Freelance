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
    public class EFMessageDal : IMessageDal
    {
        FreelanceContext freelanceContext = new FreelanceContext();

        public List<Message> GetByReceiverId(int receiverId)
        {
            List<Message> messages = freelanceContext.Messages.Where(x => x.ReceiverId == receiverId).ToList();
            return messages;
        }

        public List<Message> GetBySenderId(int senderId)
        {
            List<Message> messages = freelanceContext.Messages.Where(x => x.SenderId == senderId).ToList();
            return messages;
        }

        public Message Create(Message message)
        {
            freelanceContext.Messages.Add(message);
            freelanceContext.SaveChanges();
            return message;
        }

        public Message Update(Message messageToUpdate)
        {
            freelanceContext.Entry(messageToUpdate).State = EntityState.Modified;
            freelanceContext.SaveChanges();

            Message updatedMessage = freelanceContext.Messages.FirstOrDefault(x => x.Id == messageToUpdate.Id);

            return updatedMessage;
        }

        public void Delete(int messageId)
        {
            Message message = freelanceContext.Messages.FirstOrDefault(x => x.Id == messageId);
            freelanceContext.Messages.Remove(message);
            freelanceContext.SaveChanges();
        }

        
    }
}
