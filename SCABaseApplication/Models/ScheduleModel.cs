using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCABaseApplication.Models
{
    /// <summary>
    /// A model representing a single employees schedule for a week
    /// </summary>
    public class ScheduleModel
    {
        /// <summary>
        /// The name of the employee
        /// </summary>
        public string TeammateName { get; set; }

        /// <summary>
        /// The type/role of the employee
        /// </summary>
        public string TeammateType { get; set; }

        /// <summary>
        /// The team members schedule on Monday
        /// </summary>
        public string Monday { get; set; }

        /// <summary>
        /// The team members schedule on Tuesday
        /// </summary>
        public string Tuesday { get; set; }

        /// <summary>
        /// The team members schedule on Wednesday
        /// </summary>
        public string Wednesday { get; set; }

        /// <summary>
        /// The team members schedule on Thursday
        /// </summary>
        public string Thursday { get; set; }

        /// <summary>
        /// The team members schedule on Friday
        /// </summary>
        public string Friday { get; set; }

        /// <summary>
        /// The team members schedule on Saturday
        /// </summary>
        public string Saturday { get; set; }

        /// <summary>
        /// The team members schedule on Sunday
        /// </summary>
        public string Sunday { get; set; }

    }
}
