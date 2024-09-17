using System;
using System.Collections.Generic;

namespace Dashboard.Models
{
    /// <summary>
    /// Represents a supplier in the system.
    /// </summary>
    public partial class Supplier
    {
        /// <summary>
        /// Gets or sets the unique identifier for the supplier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the supplier.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Gets or sets the contact information for the supplier.
        /// </summary>
        public string ContactInfo { get; set; } = null!;

        /// <summary>
        /// Gets or sets the address of the supplier.
        /// </summary>
        public string Address { get; set; } = null!;

        /// <summary>
        /// Gets or sets the collection of products provided by the supplier.
        /// </summary>
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
