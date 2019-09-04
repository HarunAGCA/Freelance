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
    public class EFUserDal : IUserDal
    {
        FreelanceContext freelanceContext = new FreelanceContext();

        public List<User> GetAll()
        {
            return freelanceContext.Users.ToList();
        }

        public User GetUser(int id)
        {
            return freelanceContext.Users.FirstOrDefault(x => x.Id == id);
        }

        public User GetUserByMail(string mail)
        {
            User user = freelanceContext.Users.FirstOrDefault(x => x.Mail == mail);
            return user;
        }

        public User GetUserByMailAndPassword(string mail, string password)
        {
            User user = freelanceContext.Users.FirstOrDefault(x => x.Mail == mail && x.Password == password);
            return user;
        }

        public User CreateUser(User user)
        {
            freelanceContext.Users.Add(user);
            freelanceContext.SaveChanges();
            return user;
        }

        public User UpdateUser(User userToUpdate)
        {
            freelanceContext.Entry(userToUpdate).State = EntityState.Modified;
            freelanceContext.SaveChanges();

            User updatedUser = freelanceContext.Users.FirstOrDefault(x => x.Id == userToUpdate.Id);

            return updatedUser;
        }

        public void DeleteUser(int id)
        {
            User user = freelanceContext.Users.FirstOrDefault(x => x.Id == id);
            freelanceContext.Users.Remove(user);
            freelanceContext.SaveChanges();
        }

        public int IncreaseCredit(int UserId, int amount)
        {
            User user = freelanceContext.Users.FirstOrDefault(x => x.Id == UserId);
            user.Credit += amount;

            freelanceContext.Entry(user).State = EntityState.Modified;
            freelanceContext.SaveChanges();

            return freelanceContext.Users.FirstOrDefault(x => x.Id == UserId).Credit;

        }

        public int DecreaseCredit(int UserId, int amount)
        {
            User user = freelanceContext.Users.FirstOrDefault(x => x.Id == UserId);
            user.Credit -= amount;

            freelanceContext.Entry(user).State = EntityState.Modified;
            freelanceContext.SaveChanges();

            return freelanceContext.Users.FirstOrDefault(x => x.Id == UserId).Credit;
        }

        public int AddLikeHardware(int UserId, int amount)
        {
            User user = freelanceContext.Users.FirstOrDefault(x => x.Id == UserId);
            user.Credit += amount;

            freelanceContext.Entry(user).State = EntityState.Modified;
            freelanceContext.SaveChanges();

            return freelanceContext.Users.FirstOrDefault(x => x.Id == UserId).Credit;
        }

        public bool IsThereUserById(int id)
        {
            return freelanceContext.Users.Any(x => x.Id == id);
        }

        public bool IsThereUserByMailAndPassword(string mail, string password)
        {
            User user;

            user = freelanceContext.Users.FirstOrDefault(x => x.Mail == mail && x.Password == password);
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

       
    }
}
