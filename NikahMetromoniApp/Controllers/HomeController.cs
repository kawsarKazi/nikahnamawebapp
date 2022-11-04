using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using NikahMetromoniApp.DAL;
using NikahMetromoniApp.Models;
using NikahMetromoniApp.ViewModels;

namespace NikahMetromoniApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ContactRequestRepository _contactRequestRepository= new ContactRequestRepository(new ApplicationDbContext());
        private readonly IdentityRepository _identityRepository= new IdentityRepository();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public string GetPersonalId(string username)
        {
            var user = _identityRepository.GetUsers().ToList();
            var us = user.FirstOrDefault(c => c.UserName.Trim() == username.Trim());
            return us?.RequestId;
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactRequest model)
        {
            model.PersonalId = GetPersonalId(User.Identity.GetUserName());
            ViewBag.Category = 3;
            if (string.IsNullOrEmpty(model.PersonalId) || string.IsNullOrEmpty(model.Name) || string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Mobile) || string.IsNullOrEmpty(model.Message))
            {
                return View();
            }

            var info = _contactRequestRepository
                .Find(c => c.PersonalId.ToLower().Trim() == model.PersonalId.ToLower().Trim()).LastOrDefault();
            if (info == null)
            {
                _contactRequestRepository.Add(model);
                var status = _contactRequestRepository.Save();
                ViewBag.Message = status > 0 ? "Contact Request Sent Successfully" : "Contact Request Sent Failed";
                return View();
            }
            return View();
        }

        public ActionResult ContactList()
        {
            var models = _contactRequestRepository.GetAll().ToList();
            var model = new ContactViewModel();
            model.ContactRequests = models;
            return View(model);
        }

        public ActionResult Service()
        {
            return View();
        }

        public ActionResult LegalAdvice()
        {
            return View();
        }
    }
}