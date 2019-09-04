using Freelance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelance.DAL.Abstract
{
    public interface IMessageDal
    {

        List<Message> GetBySenderId(int senderId);

        List<Message> GetByReceiverId(int receiverId);

        Message Create(Message message);

        Message Update(Message messageToUpdate);

        void Delete(int messageId);

    }
}
