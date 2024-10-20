using Dashboard.Models;

namespace Dashboard.Repository.Interfaces
{
    /// <summary>
    /// Defines methods for managing products in the repository.
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Retrieves a product by its ID.
        /// </summary>
        /// <param name="productId">The ID of the product to retrieve.</param>
        List<Product> GetProductById(int productId);

        /// <summary>
        /// Retrieves the first product that contains the specified name.
        /// </summary>
        /// <param name="name">The name to search for in product names.</param>
        List<Product> GetProductsThatContainsName(string name);

        /// <summary>
        /// Retrieves sorted products based on the specified filter key.
        /// </summary>
        /// <param name="filterKey">The key to filter and sort products.</param>
        IQueryable<Product> GetSortedProductsByFilterKey(string filterKey);

        /// <summary>
        /// Retrieves a product including its supplier by the product ID.
        /// </summary>
        /// <param name="productId">The ID of the product to retrieve.</param>
        Product GetProductIncludingSupplierById(int productId);

        /// <summary>
        /// Saves changes to the database.
        /// </summary>
        void Save();
    }

}
