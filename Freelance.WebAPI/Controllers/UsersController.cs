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
    public class UsersController : ApiController
    {

        IUserDal userDal = new EFUserDal();

        [HttpGet]
        [ActionName("GetAll")]
        public IHttpActionResult Get()
        {
            List<User> users = userDal.GetAll();

            if (users != null)
            {
                return Ok(users);

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
            User user = userDal.GetUser(id);

            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [ActionName("GetByMailAndPassword")]
        public IHttpActionResult Get(string mail, string password)
        {
            User user = userDal.GetUserByMailAndPassword(mail, password);

            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpGet]
        [ActionName("GetByMail")]
        public IHttpActionResult Get(string mail)
        {
            User user = userDal.GetUserByMail(mail);

            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        [ActionName("Add")]
        public IHttpActionResult Post(User user)
        {
            if (user != null)
            {
                if (ModelState.IsValid)
                {
                    if (userDal.GetUserByMail(user.Mail) != null)
                    {
                        return Conflict();
                    }
                    else
                    {
                        User createdUser = userDal.CreateUser(user);
                        return CreatedAtRoute("DefaultApi", new { id = createdUser.Id }, createdUser);
                    }

                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            else
            {
                return BadRequest("User can not be Null.");
            }

        }

        [HttpPut]
        [ActionName("Update")]
        public IHttpActionResult Put(User user)
        {
            if (userDal.IsThereUserById(user.Id) == false)
            {
                return NotFound();
            }
            else if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            else
            {
                User updatedUser = userDal.UpdateUser(user);
                return Ok(updatedUser);
            }

        }

        [HttpPut]
        [ActionName("IncreaseCredit")]
        public IHttpActionResult IncreaseCredit(int userId, int amount)
        {
            if (ModelState.IsValid)
            {
                if (userDal.IsThereUserById(userId))
                {
                    int newCredit = userDal.IncreaseCredit(userId, amount);
                    return Ok(newCredit);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        [HttpPut]
        [ActionName("DecreaseCredit")]
        public IHttpActionResult DecreaseCredit(int userId, int amount)
        {
            if (ModelState.IsValid)
            {
                if (userDal.IsThereUserById(userId))
                {
                    int newCredit = userDal.DecreaseCredit(userId, amount);
                    return Ok(newCredit);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        [HttpPut]
        [ActionName("AddLikeHardware")]
        public IHttpActionResult AddLikeHardware(int userId, int amountToAdd)
        {
            if (ModelState.IsValid)
            {
                if (userDal.IsThereUserById(userId))
                {
                    int newCredit = userDal.DecreaseCredit(userId, amountToAdd);
                    return Ok(newCredit);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [ActionName("Delete")]
        public IHttpActionResult Delete(int id)
        {
            userDal.DeleteUser(id);
            return Ok();
        }
        
    }
}
