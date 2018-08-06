using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SCABaseApplication.DataAccess.DataServices;
using SCABaseApplication.Models;

namespace SCABaseApplication.Controllers
{

    //TODO there should be access control on this if it were a real app
    [Route("api/[controller]")]
    public class FacilityController : Controller
    {
        private FacilityService service { get; set; }

        public FacilityController()
        {
            //TODO this should use Dependency Injection
            service = new FacilityService();
        }

        [HttpGet("[action]")]
        public IEnumerable<FacilityModel> Facilities()
        {
            return service.GetFacilities();
        }

    }
}
