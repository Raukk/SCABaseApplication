using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SCABaseApplication.DataAccess.DataModels
{
    /// <summary>
    ///  A data model representing a TeamMember
    /// </summary>
    public class TeamMemberDataModel: BaseDataModel
    {
        /// <summary>
        /// The Facility that this TeamMember currently is assigned to
        /// </summary>
        [Required]
        [Index]
        [ForeignKey("FacilityDataModel")]
        public FacilityDataModel CurrentFacility { get; set; }
        //NOTE: in real life a TeamMember can have many Facilities

        /// <summary>
        /// The name of the employee
        /// </summary>
        [Required]
        public string TeammateName { get; set; }

        /// <summary>
        /// The type/role of the employee
        /// </summary>
        [Required]
        public string TeammateType { get; set; }

    }
}
