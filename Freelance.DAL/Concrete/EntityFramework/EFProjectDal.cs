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
    public class EFProjectDal : IProjectDal
    {
        //IOfferDal offerDal = new EFOfferDal();
        IPaymentDal paymentDal = new EFPaymentDal();
        IStateDal _stateDal = new EFStateDal();
        FreelanceContext freelanceContext = new FreelanceContext();
        

        public List<Project> GetAll()
        {
            return freelanceContext.Projects.ToList();
        }

        public Project GetProject(int id)
        {
            return freelanceContext.Projects.FirstOrDefault(x => x.Id == id);
        }
        
        public List<Project> GetByHasNotWorker()
        {
            List<Project> projects = freelanceContext.Projects.Where(x => x.WorkerId == null).ToList();
            return projects;
        }

        public List<Project> GetByOwnerId(int ownerId)
        {
            List<Project> projects = freelanceContext.Projects.Where(x => x.OwnerId == ownerId).ToList();
            return projects;
        }

        public List<Project> GetByWorkerId(int workerId)
        {
            List<Project> projects = freelanceContext.Projects.Where(x => x.WorkerId == workerId).ToList();
            return projects;
        }

        public List<Project> GetConfirmedByWorker(int ownerId)
        {
            List<Project> projects = freelanceContext.Projects.Where(x => x.OwnerId == ownerId && x.IsCompletedWorker == true).ToList();
            return projects;
        }

        public Project CreateProject(Project project)
        {
            
            freelanceContext.Projects.Add(project);
            freelanceContext.SaveChanges();
            return project;
        }

        public Project UpdateProject(Project projectToUpdate)
        {
            Project oldProject = freelanceContext.Projects.FirstOrDefault(x => x.Id == projectToUpdate.Id);
            oldProject.Header = projectToUpdate.Header;
            oldProject.Description = projectToUpdate.Description;
            oldProject.OwnerId = projectToUpdate.OwnerId;
            oldProject.WorkerId = projectToUpdate.WorkerId;
            oldProject.ReleaseTime = projectToUpdate.ReleaseTime;
            oldProject.DeadlineTime = projectToUpdate.DeadlineTime;
            oldProject.MaxPrice = projectToUpdate.MaxPrice;
            oldProject.IsCompletedOwner = projectToUpdate.IsCompletedOwner;
            oldProject.IsCompletedWorker = projectToUpdate.IsCompletedWorker;


            freelanceContext.Entry(oldProject).State = EntityState.Modified;
            freelanceContext.SaveChanges();

            Project updatedProject = freelanceContext.Projects.FirstOrDefault(x => x.Id == projectToUpdate.Id);

            return updatedProject;
        }

        public void DeleteProject(int id)
        {
            Project project = freelanceContext.Projects.FirstOrDefault(x => x.Id == id);
            List<Offer> offersOfProject = freelanceContext.Offers.Where(x=> x.ProjectId == project.Id).ToList();
            List<Payment> paymentsOfProject = paymentDal.getByProjectId(project.Id);

            foreach (Offer offer in offersOfProject)
            {
                freelanceContext.Offers.Remove(offer);
                freelanceContext.SaveChanges();
            }

            foreach (Payment payment in paymentsOfProject)
            {
                paymentDal.Delete(payment.Id);
            }

            freelanceContext.Projects.Remove(project);
            freelanceContext.SaveChanges();
        }

        public bool IsExistById(int id)
        {

            Project project = freelanceContext.Projects.FirstOrDefault(x => x.Id == id);

            if (project != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsExistByHeader(string header)
        {
            Project project = freelanceContext.Projects.FirstOrDefault(x => x.Header == header);

            if (project != null)
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
