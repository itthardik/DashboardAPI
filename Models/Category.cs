using System;
using System.Collections.Generic;

namespace Dashboard.Models
{
    /// <summary>
    /// Represents a category for organizing products.
    /// </summary>
    public partial class Category
    {
        /// <summary>
        /// Gets or sets the unique identifier for the category.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        public string CategoryName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the collection of products associated with the category.
        /// </summary>
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
