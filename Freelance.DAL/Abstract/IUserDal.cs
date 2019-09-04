using Freelance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelance.DAL.Abstract
{
    public interface IUserDal
    {

        List<User> GetAll();

        User GetUser(int id);

        User CreateUser(User user);

        User UpdateUser(User userToUpdate);

        void DeleteUser(int id);

        int IncreaseCredit(int UserId, int amount);

        int DecreaseCredit(int UserId, int amount);

        int AddLikeHardware(int UserId, int amount);

        bool IsThereUserById(int userId);

        bool IsThereUserByMailAndPassword(string mail, string password);

        User GetUserByMailAndPassword(string mail, string password);

        User GetUserByMail(string mail);

    }
}
