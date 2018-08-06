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
    public class ScheduleController : Controller
    {
        private ScheduleService service { get; set; }

        public ScheduleController()
        {
            //TODO this should use Dependency Injection
            service = new ScheduleService();
        }

        [HttpGet("[action]/{FacilityId}/{Date}")]
        public IEnumerable<ScheduleModel> Schedules(string FacilityId, string Date)
        {
            DateTime day = DateTime.Parse(Date);

            return service.GetSchedules(FacilityId, day);
        }

    }
}
