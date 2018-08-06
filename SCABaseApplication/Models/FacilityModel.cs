using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCABaseApplication.Models
{
    /// <summary>
    /// A model representing high level data about a Facility
    /// </summary>
    public class FacilityModel
    {
        /// <summary>
        /// The System ID of the Facility
        /// </summary>
        public string FacilityId { get; set; }

        /// <summary>
        /// The Human Readable Name of the Facility
        /// </summary>
        public string FacilityName { get; set; }
    }
}
