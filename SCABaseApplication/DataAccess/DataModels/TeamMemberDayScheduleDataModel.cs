using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SCABaseApplication.DataAccess.DataModels
{
    /// <summary>
    /// Represents a team members schedule for a specific day
    /// </summary>
    public class TeamMemberDayScheduleDataModel : BaseDataModel
    {
        /// <summary>
        /// Which team member is this schedule for
        /// </summary>
        [Required]
        [Index]
        [ForeignKey("TeamMemberDataModel")]
        public TeamMemberDataModel TeamMember { get; set; }

        /// <summary>
        /// What day is this schedule for
        /// </summary>
        [Required]
        [Index]
        public DateTime Date { get; set; }

        /// <summary>
        /// What is their schedule for that day
        /// </summary>
        [Required]
        public string Schedule { get; set; }
        //NOTE: this should be broken out into many parameters like, start, end, break, closed, timeoff
        // That way more advanced features could be implemented.

    }
}
