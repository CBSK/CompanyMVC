using Company.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Models.Models
{
    public abstract class BaseEntityModel
    {
        public BaseEntityModel()
        {
            ObjectState = Constants.ObjectState.New;
        }

        /// <summary>
        ///     Gets or sets the create user identifier.
        /// </summary>
        /// <value>The create user identifier.</value>
        public long CreatedBy { get; set; }

        /// <summary>
        ///     Gets or sets the create date time.
        /// </summary>
        /// <value>The create date time.</value>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        ///     Gets the state of the object.
        /// </summary>
        /// <remarks>Identifies the state of the object with respect to the persistence layer (New, Modified, Deleted, Current).</remarks>
        public Constants.ObjectState ObjectState { get; set; }

        /// <summary>
        ///     Gets or sets the update user identifier.
        /// </summary>
        /// <value>The update user identifier.</value>
        public long UpdatedBy { get; set; }

        /// <summary>
        ///     Gets or sets the update date time.
        /// </summary>
        /// <value>The update date time.</value>
        public DateTime UpdatedOn { get; set; }
    }
}