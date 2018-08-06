using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SCABaseApplication.DataAccess.DataModels
{
    /// <summary>
    /// A base Data Model Class with any shared DB model info
    /// </summary>
    public abstract class BaseDataModel
    {
        /// <summary>
        /// The Database Key
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// A unique Guid that can be used to uery for individual items 
        /// </summary>
        [Required]
        [Index]
        public Guid ResourceId { get; set; }

        /// <summary>
        /// What username created this Data
        /// </summary>
        [Required]
        public string CreatedBy { get; set; }

        /// <summary>
        /// When this data was created
        /// </summary>
        [Required]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// What User last modified this data
        /// </summary>
        [Required]
        public string ModifiedBy { get; set; }

        /// <summary>
        /// When this data was last modified
        /// </summary>
        [Required]
        public DateTime ModifiedOn { get; set; }

        /// <summary>
        /// The current status of this data
        /// </summary>
        [Required]
        [Index]
        public DataStatus Status { get; set; }

    }
}
