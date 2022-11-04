using NikahMetromoniApp.DAL;
using NikahMetromoniApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using NikahMetromoniApp.ViewModels;

namespace NikahMetromoniApp.Controllers
{
    [System.Web.Mvc.Authorize]
    public class UsersController : Controller
    {
        private readonly IdentityRepository _identityRepository = new IdentityRepository();
        private readonly DistrictRepository _districtRepository = new DistrictRepository(new ApplicationDbContext());
        private readonly MarriageRegisterDocumentRepository _marriageRegisterDocumentRepository= new MarriageRegisterDocumentRepository(new ApplicationDbContext());
        private readonly UpozilaRepostiory _upozilaRepostiory = new UpozilaRepostiory(new ApplicationDbContext());
        private readonly DivisionRepository _divisionRepository = new DivisionRepository(new ApplicationDbContext());

        // GET: Users
        [System.Web.Mvc.AllowAnonymous]
        public ActionResult Search(string userRole = null)
        {
            if (!string.IsNullOrEmpty(userRole))
            {
                ViewBag.UserRole = userRole;
            }
            else
            {
                if (!string.IsNullOrEmpty(User.Identity.GetUserName()))
                {
                    var personalId = GetPersonalId(User.Identity.GetUserName());
                    var profile = _identityRepository.GetUsers()
                        .FirstOrDefault(c => c.UserName.ToLower().Trim() == User.Identity.GetUserName().ToLower().Trim());
                    ViewBag.UserRole = profile != null ? profile.UserRole : "";
                }
                
            }
            
            ViewBag.DivisionId = new SelectList(new List<Division>(), "Id", "NameEnglish");
            ViewBag.DistrictId = new SelectList(new List<District>(), "Id", "NameEnglish");
            ViewBag.UpozilaId = new SelectList(new List<Upozila>(), "Id", "NameEnglish");
            return View();
        }

        
        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.AllowAnonymous]
        public ActionResult Search(SearchViewModel model)
        {
            ViewBag.DistrictId = new SelectList(new List<District>(), "Id", "NameEnglish");
            ViewBag.UpozilaId = new SelectList(new List<Upozila>(), "Id", "NameEnglish");
            model.UserRole = "Marriage Register";

            if (model != null)
            {  
                var users = _identityRepository.GetUsers().ToList();
                if (!string.IsNullOrEmpty(User.Identity.GetUserName()))
                {
                    var personalId = GetPersonalId(User.Identity.GetUserName()).ToLower().Trim();
                    users = users.Where(c => c.RequestId.ToLower().Trim() != personalId).ToList();
                }
                if (!string.IsNullOrEmpty(model.UserRole))
                {
                    users = users.Where(c => c.UserRole.ToLower().Trim() == model.UserRole.ToLower().Trim()).ToList();
                }

                if (model.DistrictId > 0)
                {
                    users = users.Where(c => c.DistrictId == model.DistrictId).ToList();
                }
                if (model.UpozilaId > 0)
                {
                    users = users.Where(c => c.UpozilaId == model.UpozilaId).ToList();
                }
                var list = users.Select(x => new SearchResultViewModel
                {
                    PersonalId = x.RequestId,
                    Name = x.FirstName + " " + x.LastName,
                    Email = x.Email,
                    Age = x.Age,
                    Gender = x.Gender,
                    Height = x.Height,
                    Occupation = x.Profession,
                    Religion = x.Religion,
                    Education = x.HigherDegree,
                    Division = x.DistrictId > 0 ? _divisionRepository.Get(_districtRepository.Get(x.DistrictId.GetValueOrDefault()).DivisionId).NameEnglish : "",
                    Area = _upozilaRepostiory.Get(x.UpozilaId.GetValueOrDefault())?.NameEnglish,
                    City = _districtRepository.Get(x.DistrictId.GetValueOrDefault())?.NameEnglish,
                    Country = x.Nationality,
                    Bio = x.Description
                }).Distinct().ToList();

                
                

                TempData["Results"] = list;

                if (model.UserRole.ToLower().Trim()== "Marriage Register".ToLower().Trim())
                {
                    return RedirectToAction("RegisterSearchResult");
                }

                return RedirectToAction("SearchResult");

            }
            return View();
        }

        [System.Web.Mvc.AllowAnonymous]
        public ActionResult SearchResult()
        {
            List<SearchResultViewModel> things = (List<SearchResultViewModel>)TempData["Results"];
            ViewBag.MatchesProfile = things;
            return View();
        }

        [System.Web.Mvc.AllowAnonymous]
        public ActionResult RegisterSearchResult()
        {
            List<SearchResultViewModel> things = (List<SearchResultViewModel>)TempData["Results"];
            ViewBag.MatchProfiles = things;
            return View();
        }

      
        public ActionResult UserProfile()
        {
            var personalId= GetPersonalId(User.Identity.GetUserName());
            var user = _identityRepository.GetUsers()
                .FirstOrDefault(c => c.RequestId.ToLower().Trim() == personalId.ToLower().Trim());
            if (user != null)
            {
                ViewBag.UserRole = user.UserRole;
            }
            ViewBag.PersonalId = personalId;
            return View();
        }

        [System.Web.Mvc.AllowAnonymous]
        public ActionResult MarriageRegisterProfile(string pid)
        {
            if (!string.IsNullOrEmpty(pid))
            {
                var user = _identityRepository.GetUsers()
                    .FirstOrDefault(c => c.RequestId.ToLower().Trim() == pid.ToLower().Trim());
                 ViewBag.SummaryModel= user;
                 var profile= _marriageRegisterDocumentRepository.GetAll().FirstOrDefault(c => c.PersonalId.ToLower().Trim() == pid.ToLower().Trim());
                 ViewBag.Profile = profile;
                return View();
            }
            
            return View("_LoginPartial");
        }

        public ActionResult EditMarriageRegister()
        {
            var personalId = GetPersonalId(User.Identity.GetUserName());
            var profile = _identityRepository.GetUsers()
                .FirstOrDefault(c => c.RequestId.ToLower().Trim() == personalId.ToLower().Trim());
            if (profile!= null)
            {
                var viewModel= new MarriageRegisterEditViewModel();
                viewModel.FirstName = profile.FirstName;
                viewModel.LastName = profile.LastName;
                viewModel.Gender = profile.Gender;
                viewModel.ContactNo = profile.PhoneNumber;
                viewModel.Religion = profile.Religion;
                viewModel.DivisionName = profile.DivisionName;
                viewModel.CityName = profile.CityName;
                viewModel.AreaName = profile.AreaName;
                ViewBag.Profile = viewModel;
            }
            return View();
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult EditMarriageRegister(MarriageRegisterEditViewModel model)
        {
            var status = _identityRepository.UpdateMarriageRegister(User.Identity.GetUserId(), model);
            ViewBag.Message = status ? "Information Update Successfully" : "Information Update Failed";

            var personalId = GetPersonalId(User.Identity.GetUserName());
            var profile = _identityRepository.GetUsers()
                .FirstOrDefault(c => c.RequestId.ToLower().Trim() == personalId.ToLower().Trim());
            if (profile != null)
            {
                var viewModel = new MarriageRegisterEditViewModel();
                viewModel.FirstName = profile.FirstName;
                viewModel.LastName = profile.LastName;
                viewModel.Gender = profile.Gender;
                viewModel.ContactNo = profile.PhoneNumber;
                viewModel.Religion = profile.Religion;
                viewModel.DivisionName = profile.DivisionName;
                viewModel.CityName = profile.CityName;
                viewModel.AreaName = profile.AreaName;
                ViewBag.Profile = viewModel;
            }

            return View();
        }

        public ActionResult MarriageRegisterDocument()
        {
            var personalId = GetPersonalId(User.Identity.GetUserName());
            var profilePicture = _marriageRegisterDocumentRepository.Find(c => c.PersonalId.ToLower().Trim() == personalId.ToLower().Trim()).FirstOrDefault();
            ViewBag.ProfilePictureModel = profilePicture;
            return View();
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult MarriageRegisterDocument(MarriageRegisterDocument model)
        {
            model.PersonalId = GetPersonalId(User.Identity.GetUserName());
            if (string.IsNullOrEmpty(model.PersonalId) || string.IsNullOrEmpty(model.ImageUrl))
            {
                return View();
            }

            var info = _marriageRegisterDocumentRepository
                .Find(c => c.PersonalId.ToLower().Trim() == model.PersonalId.ToLower().Trim()).LastOrDefault();
            if (info == null)
            {
                
                _marriageRegisterDocumentRepository.Add(model);
                var status = _marriageRegisterDocumentRepository.Save();
                ViewBag.Message = status > 0 ? "Documents Successfully Updated" : "Documents Update Failed";
                return View();
            }
            else
            {
                info.ImageUrl = model.ImageUrl;
                info.CertificateUrl = model.CertificateUrl;
                _marriageRegisterDocumentRepository.Update(info);
                var status = _marriageRegisterDocumentRepository.Save();
                ViewBag.Message = status > 0 ? "Documents Successfully Updated" : "Documents Update Failed";
                return View();
            }
        }
        

        
       
        

        public string GetPersonalId(string username)
        {
            var user = _identityRepository.GetUsers().ToList();
            var us = user.FirstOrDefault(c => c.UserName.Trim() == username.Trim());
            return us?.RequestId;
        }

        public void SMSSend(string messsage, string number)
        {

            
            //String message = System.Uri.EscapeUriString(messsage);

            //// Create a request using a URL that can receive a post.   
            //WebRequest request = WebRequest.Create("http://sms.iglweb.com/api/v1/send");
            //// Set the Method property of the request to POST.  
            //request.Method = "POST";
            //// Create POST data and convert it to a byte array.  
            //string postData = "api_key=" + apikey + "&contacts=" + number + "&senderid=" + senderId + "&msg=" + message;
            //byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            //// Set the ContentType property of the WebRequest.  
            //request.ContentType = "application/x-www-form-urlencoded";
            //// Set the ContentLength property of the WebRequest.  
            //request.ContentLength = byteArray.Length;
            //// Get the request stream.  
            //Stream dataStream = request.GetRequestStream();
            //// Write the data to the request stream.  
            //dataStream.Write(byteArray, 0, byteArray.Length);





            //Previous

            String userid = ""; //Your Login ID
            String password = ""; //Your Password


            //String userid = "01797803454"; //Your Login ID
            //String password = "Rakib1234@"; //Your Password



            //                          //Recipient Phone Number multiple number must be separated by comma
            String message = System.Uri.EscapeUriString(messsage);

            // Create a request using a URL that can receive a post.   
            WebRequest request = WebRequest.Create("http://66.45.237.70/api.php");
            //// Set the Method property of the request to POST.  
            request.Method = "POST";
            //// Create POST data and convert it to a byte array.  
            string postData = "username=" + userid + "&password=" + password + "&number=" + number + "&message=" + message;
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            //// Set the ContentType property of the WebRequest.  
            request.ContentType = "application/x-www-form-urlencoded";
            //// Set the ContentLength property of the WebRequest.  
            request.ContentLength = byteArray.Length;
            //// Get the request stream.  
            Stream dataStream = request.GetRequestStream();
            //// Write the data to the request stream.  
            dataStream.Write(byteArray, 0, byteArray.Length);
            // Close the Stream object. 

            dataStream.Close();
        }
        

    }
}