using SCABaseApplication.DataAccess.DataModels;
using SCABaseApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCABaseApplication.DataAccess.DataServices
{
    /// <summary>
    /// A service for Accessing Facilities
    /// </summary>
    public class FacilityService
    {
        /// <summary>
        /// Get all the Facilities
        /// </summary>
        /// <returns>All Facilities</returns>
        public List<FacilityModel> GetFacilities()
        {
            //TODO this should have Access Control based on who is logged in

            // Get teh DB context, this would normally be injected in.
            SchedulingDbContext scheduleContext = new SchedulingDbContext();
            //Simply query all Factilites
            List<FacilityDataModel> all = scheduleContext.Facilities.ToList();
            // Map the Data Objects back to the Models
            List<FacilityModel>models = AutoMapper.Mapper.Map< List<FacilityDataModel>, List<FacilityModel>>(all);

            return models;
        }

    }
}
