using Freelance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelance.DAL.Abstract
{
    public interface IProjectDal
    {
        List<Project> GetAll();
        
        List<Project> GetByHasNotWorker();

        List<Project> GetByOwnerId(int ownerId);

        List<Project> GetByWorkerId(int workerId);

        List<Project> GetConfirmedByWorker(int ownerId);

        Project GetProject(int id);

        Project CreateProject(Project project);

        Project UpdateProject(Project projectToUpdate);

        void DeleteProject(int id);

        bool IsExistByHeader(string header);

        bool IsExistById(int id);


    }
}
