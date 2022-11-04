using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using NikahMetromoniApp.DAL;
using NikahMetromoniApp.Models;

namespace NikahMetromoniApp.Controllers
{
    public class RegistrationsController : Controller
    {
        private readonly MarriageRegistrationRepository _marriageRepository;
        private readonly DivorceRegistrationRepository _divorceRepository;
        private readonly IdentityRepository _identityRepository;

        public RegistrationsController()
        {
            _marriageRepository = new MarriageRegistrationRepository(new ApplicationDbContext());
            _divorceRepository= new DivorceRegistrationRepository(new ApplicationDbContext());
            _identityRepository = new IdentityRepository();
        }
        // GET: Registrations
        public ActionResult MarriageRegistration()  
        {
            return View();
        }

        [HttpPost]
        public ActionResult MarriageRegistration(MarriageRegistration model)
        {
            model.FilePath = model.GroomIdentity+"-"+model.BrideIdentity + ".pdf";
            if (string.IsNullOrEmpty(model.GroomName) || string.IsNullOrEmpty(model.GroomName) ||
                string.IsNullOrEmpty(model.BrideName) || string.IsNullOrEmpty(model.BrideIdentity))
            {
                ViewBag.Message = "Please Fill up required all fields";
                return View();
            }

            var user = _identityRepository.GetUsers().FirstOrDefault(c => c.UserName == User.Identity.GetUserName());
            if (user!= null)
            {
                model.Address = user.Address;
            }
            model.DownloadPermission = 0;
            model.UserId = User.Identity.GetUserId();
            _marriageRepository.Add(model);
            var status =_marriageRepository.Save();
            if (status > 0)
            {
                ViewBag.Message = "Save Success";
            }
            else
            {
                ViewBag.Message = "Save Failed";
            }
            return View();
        }

        public ActionResult MarriageList()
        {
            return View();
        }
            
        public FileResult DownloadPaper(string fileName)
        {
            string fullPath = Path.Combine(Server.MapPath("~/FileUploads"), fileName);
            byte[] fileBytes = System.IO.File.ReadAllBytes(fullPath);

            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }

        [HttpGet]
        public JsonResult GetMarriageList()
        {
            var list = _marriageRepository.GetAll().ToList();
            var list2 = list.Select(x => new MarriageRegistration
            {
                Id = x.Id,
                GroomName = x.GroomName,
                GroomFatherName = x.GroomFatherName,
                GroomIdentity = x.GroomIdentity,
                BrideName = x.BrideName,
                BrideFatherName = x.BrideFatherName,
                BrideIdentity = x.BrideIdentity,
                RegisterVolumeNo = x.RegisterVolumeNo,
                PageNo = x.PageNo,
                RegistrationDate = x.RegistrationDate,
                AmountOfDower = x.AmountOfDower,
                FilePath = x.FilePath,
                UserId = x.UserId,
                Address = x.Address,
                DownloadPermission = x.UserId== User.Identity.GetUserId() ? 1 :0
            }).ToList();
            return Json(list2, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DivorceList()   
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetDivorceList()
        {
            var list = _divorceRepository.GetAll().ToList();
            var list2 = list.Select(x => new DivorceRegistration
            {
                Id = x.Id,
                GroomName = x.GroomName,
                GroomFatherName = x.GroomFatherName,
                GroomIdentity = x.GroomIdentity,
                BrideName = x.BrideName,
                BrideFatherName = x.BrideFatherName,
                BrideIdentity = x.BrideIdentity,
                RegisterVolumeNo = x.RegisterVolumeNo,
                PageNo = x.PageNo,
                Address = x.Address,
                UserId = x.UserId,
                DivorceDate = x.DivorceDate,
                DivorceType = x.DivorceType,
                FilePath = x.FilePath,
                DownloadPermission = x.UserId == User.Identity.GetUserId() ? 1 : 0
            }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DivorceRegistration()   
        {
            return View();
        }

        [HttpPost]
        public ActionResult DivorceRegistration(DivorceRegistration model)
        {
            model.FilePath = "D-"+model.GroomIdentity+"-"+model.BrideIdentity + ".pdf";
            if (string.IsNullOrEmpty(model.GroomName) || string.IsNullOrEmpty(model.GroomName) ||
                string.IsNullOrEmpty(model.BrideName) || string.IsNullOrEmpty(model.BrideIdentity))
            {
                ViewBag.Message = "Please Fill up required all fields";
                return View();
            }
            var user = _identityRepository.GetUsers().FirstOrDefault(c => c.UserName == User.Identity.GetUserName());
            if (user != null)
            {
                model.Address = user.Address;
            }
            model.DownloadPermission = 0;
            model.UserId = User.Identity.GetUserId();
            _divorceRepository.Add(model);
            var status = _divorceRepository.Save();
            if (status > 0)
            {
                ViewBag.Message = "Save Success";
            }
            else
            {
                ViewBag.Message = "Save Failed";
            }
            return View();
        }
    }
}