using Freelance.DAL.Abstract;
using Freelance.DAL.Concrete;
using Freelance.DAL.Concrete.EntityFramework;
using Freelance.Entities;
using Freelance.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Freelance.MvcWebUI.Controllers
{
    public class ProfileController : Controller
    {
        IUserDal _userDal = new EFUserDal();
        IProjectDal _projectDal = new EFProjectDal();
        IStateDal _stateDal = new EFStateDal();

        [HttpGet]
        public ActionResult Index()
        {
            int id = Convert.ToInt32(HttpContext.Session["userID"]);

            UserProfileViewModel userProfileViewModel = new UserProfileViewModel();

            User user;
            List<Project> myProjectsAsOwner;
            List<Project> myProjectsAsWorker;

            user = _userDal.GetUser(id);
            myProjectsAsOwner = _projectDal.GetByOwnerId(id);
            myProjectsAsWorker = _projectDal.GetByWorkerId(id);

            userProfileViewModel.User = user;
            userProfileViewModel.MyProjectsAsOwner = myProjectsAsOwner;
            userProfileViewModel.MyProjectsAsWorker = myProjectsAsWorker;

            return View(userProfileViewModel);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            int userId = Convert.ToInt32(HttpContext.Session["userID"]);
            User user = _userDal.GetUser(userId);
            return View(user);
        }

        public ActionResult MyProjectsAsOwner()
        {
            List<ProjectStateViewModel> projectStateViewModels = new List<ProjectStateViewModel>();
            List<Project> Projects = _projectDal.GetByOwnerId(Convert.ToInt32(Session["userID"]));


             foreach (var project in Projects)
            {
                ProjectStateViewModel projectStateViewModel =  new ProjectStateViewModel();
                projectStateViewModel.Project = project;
                projectStateViewModel.State = _stateDal.GetStateById(project.StateId);
                projectStateViewModels.Add(projectStateViewModel);
            }

            projectStateViewModels = projectStateViewModels.OrderBy(p => p.Project.StateId).ToList();
            return View(projectStateViewModels); 
        }

        public ActionResult MyProjectsAsWorker()
        {
            List<ProjectStateViewModel> projectStateViewModels = new List<ProjectStateViewModel>();
            List<Project> Projects = _projectDal.GetByWorkerId(Convert.ToInt32(Session["userID"]));


            foreach (var project in Projects)
            {
                ProjectStateViewModel projectStateViewModel = new ProjectStateViewModel();
                projectStateViewModel.Project = project;
                projectStateViewModel.State = _stateDal.GetStateById(project.StateId);
                projectStateViewModels.Add(projectStateViewModel);
            }

            projectStateViewModels = projectStateViewModels.OrderBy(p => p.Project.StateId).ToList();
            return View(projectStateViewModels);



        }

        [HttpGet]
        public ActionResult AddCredit()
        {
            return View();
        }

        [HttpPost]
        [ActionName("AddCredit")]
        public ActionResult AddCredit(int currentUserId, FormCollection formCollection)
        {
            string creditAmount = formCollection["creditAmount"].ToString();
            _userDal.IncreaseCredit(currentUserId, Convert.ToInt32(creditAmount));
            User user = _userDal.GetUser(currentUserId);
            Session["Credit"] = user.Credit.ToString();

            TempData.Add("message", String.Format("Hesabınıza {0} TL yüklendi.",creditAmount));

            return RedirectToAction("index", "Home");
        }
        
        [HttpPost]
        public ActionResult Edit(User user)
        {
            user.Id = Convert.ToInt32(HttpContext.Session["userID"]);
            User dbUser = _userDal.GetUser(user.Id);
            dbUser.Name = user.Name;
            dbUser.Password = user.Password;
            _userDal.UpdateUser(dbUser);
            Session["Name"] = _userDal.GetUser(Convert.ToInt32(Session["userID"])).Name;

            TempData.Add("message", String.Format("Kullanıcı bilgileriniz güncellendi."));

            return RedirectToAction("index","Home");
        }


    }
}