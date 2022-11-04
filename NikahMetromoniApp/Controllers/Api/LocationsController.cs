using NikahMetromoniApp.DAL;
using NikahMetromoniApp.Models;
using System.Linq;
using System.Web.Http;

namespace NikahMetromoniApp.Controllers.Api
{
    public class LocationsController : ApiController
    {
        private readonly DivisionRepository _divisionRepository;
        private readonly DistrictRepository _districtRepository;
        private readonly UpozilaRepostiory _upozilaRepostiory;

        public LocationsController()
        {
            _divisionRepository = new DivisionRepository(new ApplicationDbContext());
            _districtRepository = new DistrictRepository(new ApplicationDbContext());
            _upozilaRepostiory = new UpozilaRepostiory(new ApplicationDbContext());
        }
        // GET: api/Locations
        [Route("api/Locations/Division")]
        [HttpGet]
        public IHttpActionResult Division()
        {
            var divisions = _divisionRepository.GetAll().ToList();
            return Ok(divisions);
        }


        [Route("api/Locations/District")]
        [HttpGet]
        public IHttpActionResult District()
        {
            return Ok(_districtRepository.GetAll());
        }

        [Route("api/Locations/Upozila")]
        [HttpGet]
        public IHttpActionResult Upozila(int districtId)
        {
            return Ok(_upozilaRepostiory.Find(c => c.DistrictId == districtId));
        }
    }
}
