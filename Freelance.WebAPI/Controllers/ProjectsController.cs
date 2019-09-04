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
    public class ProjectsController : ApiController
    {
        

        IProjectDal projectDal = new EFProjectDal();
        IPaymentDal paymentDal = new EFPaymentDal();

        [HttpGet]
        [ActionName("GetByHasNotWorker")]
        public IHttpActionResult GetByHasNotWorker()
        {
            List<Project> projects = projectDal.GetByHasNotWorker();

            if (projects != null)
            {
                return Ok(projects);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpGet]
        [ActionName("GetById")]
        public IHttpActionResult GetById(int id)
        {
            Project project = projectDal.GetProject(id);

            if (project != null)
            {
                return Ok(project);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpGet]
        [ActionName("GetByOwnerId")]
        public IHttpActionResult GetByOwnerId(int ownerId)
        {
            List<Project> projects = projectDal.GetByOwnerId(ownerId);

            if (projects != null)
            {
                return Ok(projects);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpGet]
        [ActionName("GetByWorkerId")]
        public IHttpActionResult GetByWorkerId(int workerId)
        {
            List<Project> projects = projectDal.GetByWorkerId(workerId);

            if (projects != null)
            {
                return Ok(projects);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpGet]
        [ActionName("GetConfirmedByWorker")]
        public IHttpActionResult GetConfirmedByWorker(int ownerId)
        {
            List<Project> projects = projectDal.GetConfirmedByWorker(ownerId);

            if (projects != null)
            {
                return Ok(projects);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        [ActionName("Add")]
        public IHttpActionResult Post(Project project)
        {
            if (project != null)
            {
                if (ModelState.IsValid)
                {
                    if (project.ReleaseTime == null)
                    {
                        project.ReleaseTime = DateTime.Now;
                    }

                    if (project.DeadlineTime == null)
                    {
                        project.DeadlineTime = DateTime.Now.AddDays(30);
                    }

                    Project createdProject = projectDal.CreateProject(project);
                    return CreatedAtRoute("DefaultApi", new { id = createdProject.Id }, createdProject);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            else
            {
                return BadRequest("Project can not be Null.");
            }

        }

        [HttpPost]
        [ActionName("MakePayment")]
        public IHttpActionResult MakePayment(int projectId)
        {
            Project project = projectDal.GetProject(projectId);


            if (project.IsCompletedOwner && project.IsCompletedWorker)
            {
                Payment payment = paymentDal.FindByProjectId(projectId);
                paymentDal.MakePayment(payment);
                return Ok();
            }
            else
            {
                return BadRequest("Payment cannot be made until the project is approved");
            }

        }

        [HttpPut]
        [ActionName("Update")]
        public IHttpActionResult Put(Project project)
        {
            if (projectDal.IsExistById(project.Id) == false)
            {
                return NotFound();
            }
            else if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            else
            {
                Project updatedProject = projectDal.UpdateProject(project);
                return Ok(updatedProject);
            }
        }

        [HttpPut]
        [ActionName("ConfirmByOwner")]
        public IHttpActionResult ConfirmByOwner(int projectId)
        {
            if (projectDal.IsExistById(projectId) == false)
            {
                return NotFound();
            }
            else if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            else
            {
                Project project = projectDal.GetProject(projectId);
                if (project.WorkerId != null)
                {
                    if (!project.IsCompletedOwner)
                    {
                        project.IsCompletedOwner = true;
                        projectDal.UpdateProject(project);

                        Payment payment = paymentDal.FindByProjectId(projectId);
                        paymentDal.MakePayment(payment);

                        return Ok();
                    }
                    else
                    {
                        return Conflict();
                    }
                }
                else
                {
                    return BadRequest();
                }

            }
        }

        [HttpPut]
        [ActionName("ConfirmByWorker")]
        public IHttpActionResult ConfirmByWorker(int projectId)
        {
            if (projectDal.IsExistById(projectId) == false)
            {
                return NotFound();
            }
            else if (ModelState.IsValid == false)
            {
                return BadRequest(ModelState);
            }
            else
            {
                Project project = projectDal.GetProject(projectId);

                if (project.WorkerId != null)
                {
                    if (!project.IsCompletedWorker)
                    {
                        project.IsCompletedWorker = true;
                        projectDal.UpdateProject(project);

                        return Ok();
                    }
                    else
                    {
                        return Conflict();
                    }
                }
                else
                {
                    return BadRequest();
                }

            }
        }

        [HttpDelete]
        [ActionName("Delete")]
        public IHttpActionResult Delete(int id)
        {
            if (projectDal.IsExistById(id))
            {
                Project project = projectDal.GetProject(id);
                if (project.WorkerId == null || (project.IsCompletedOwner && project.IsCompletedWorker))
                {
                    projectDal.DeleteProject(id);

                    return Ok("Deleted.");
                }
                else
                {
                    return BadRequest("This operation is denied.");
                    
                }

            }
            else
            {
                return NotFound();
            }


        }

    }
}
