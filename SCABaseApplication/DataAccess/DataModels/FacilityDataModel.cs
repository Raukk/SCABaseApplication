using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SCABaseApplication.DataAccess.DataModels
{
    /// <summary>
    /// A data model representing a Facility
    /// </summary>
    public class FacilityDataModel: BaseDataModel
    {
        /// <summary>
        /// The System ID of the Facility
        /// </summary>
        [Required]
        [Index]
        public string FacilityId { get; set; }

        /// <summary>
        /// The Human Readable Name of the Facility
        /// </summary>
        [Required]
        public string FacilityName { get; set; }

    }
}
