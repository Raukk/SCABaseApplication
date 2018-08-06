using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCABaseApplication.DataAccess.DataModels
{
    /// <summary>
    /// A list of valid state for the data to be in 
    /// </summary>
    public enum DataStatus 
    {
        /// <summary>
        /// Standard state for the data
        /// </summary>
        Active,

        /// <summary>
        /// Archived or inactive data
        /// </summary>
        Inactive,

        /// <summary>
        /// Data pending cleanup at next chance
        /// </summary>
        ToDelete,

        /// <summary>
        /// Unknown or Other
        /// </summary>
        Other,
    }
}
