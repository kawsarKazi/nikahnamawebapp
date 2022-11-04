using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using NikahMetromoniApp.DAL;
using NikahMetromoniApp.Models;

namespace NikahMetromoniApp.Controllers.Api
{
    public class RegistrationsController : ApiController
    {
        private readonly MarriageRegistrationRepository _marriageRepository;
        private readonly DivorceRegistrationRepository _divorceRepository;
        private readonly IdentityRepository _identityRepository;

        public RegistrationsController()
        {
            _marriageRepository = new MarriageRegistrationRepository(new ApplicationDbContext());
            _divorceRepository = new DivorceRegistrationRepository(new ApplicationDbContext());
            _identityRepository = new IdentityRepository();
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Registrations/GetMarriageList")]
        public IHttpActionResult GetMarriageList()
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
                DownloadPermission = x.UserId == User.Identity.GetUserId() ? 1 : 0
            }).ToList();
            return Ok(list2);
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/Registrations/GetDivorceList")]
        public IHttpActionResult GetDivorceList()
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
            return Ok(list2);
        }

    }
}
