using System;
using System.Collections.Generic;

namespace Dashboard.Models
{
    /// <summary>
    /// Represents a record of a customer's search activity.
    /// </summary>
    public partial class CustomerSearch
    {
        /// <summary>
        /// Gets or sets the unique identifier for the customer search.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the search term entered by the customer.
        /// </summary>
        public string SearchTerm { get; set; } = null!;

        /// <summary>
        /// Gets or sets the number of times the customer has searched this term, if available.
        /// </summary>
        public int? Count { get; set; }

        /// <summary>
        /// Gets or sets the foreign key for the user who performed the search.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the search was performed.
        /// </summary>
        public DateTime? SearchedAt { get; set; }

        /// <summary>
        /// Gets or sets the user who performed the search.
        /// </summary>
        public virtual User User { get; set; } = null!;
    }
}
