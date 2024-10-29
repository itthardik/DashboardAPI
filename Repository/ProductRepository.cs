using Dashboard.DataContext;
using Dashboard.Models;
using Dashboard.Repository.Interfaces;
using Dashboard.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Dashboard.Repository
{
    /// <summary>
    /// Repository class for managing products in the database.
    /// </summary>
    public class ProductRepository(ApiContext apiContext) : IProductRepository
    {
        private readonly ApiContext _context = apiContext;

        /// <summary>
        /// Retrieves a product by its ID.
        /// </summary>
        /// <param name="productId">The ID of the product to retrieve.</param>
        /// <returns>The product with the specified ID.</returns>
        /// <exception cref="CustomException">Thrown when no product with the specified ID is found.</exception>
        public List<Product> GetProductById(int productId)
        {
            var product = _context.Products.Where(p => p.Id == productId);
            if (product.IsNullOrEmpty())
                throw new CustomException($"No product ( ID:{productId} ) found", 404);
            return [.. product];
        }

        /// <summary>
        /// Retrieves the first product that contains the specified name.
        /// </summary>
        /// <param name="name">The name to search for in product names.</param>
        /// <returns>The first product that contains the specified name.</returns>
        /// <exception cref="CustomException">Thrown when no product with the specified name is found.</exception>
        public List<Product> GetProductsThatContainsName(string name)
        {
            var product = _context.Products.Where(p => p.Name.Contains(name));
            if (product.IsNullOrEmpty())
                throw new CustomException("No Product with this name", 404);

            return [..product];
        }

        /// <summary>
        /// Retrieves sorted products based on the specified filter key.
        /// </summary>
        /// <param name="filterKey">The key to filter and sort products.</param>
        /// <returns>An <see cref="IQueryable{Product}"/> of sorted products.</returns>
        /// <exception cref="CustomException">Thrown when no products are found in the inventory.</exception>
        public IQueryable<Product> GetSortedProductsByFilterKey(string filterKey)
        {
            var allProducts = _context.Products;

            if (allProducts.IsNullOrEmpty())
                throw new CustomException("No Inventory found", 404);

            IQueryable<Product> sortedProducts;

            if (filterKey == "lowToHighStock")
                sortedProducts = allProducts.OrderBy(p => (p.CurrentStock - p.ReorderPoint));
            else if (filterKey == "highToLowStock")
                sortedProducts = allProducts.OrderBy(p => (p.ReorderPoint - p.CurrentStock));
            else
                sortedProducts = allProducts.OrderBy(p => p.Id);

            return sortedProducts;
        }

        /// <summary>
        /// Retrieves a product including its supplier by the product ID.
        /// </summary>
        /// <param name="productId">The ID of the product to retrieve.</param>
        /// <returns>The product including its supplier.</returns>
        /// <exception cref="CustomException">Thrown when no product with the specified ID is found.</exception>
        public Product GetProductIncludingSupplierById(int productId)
        {
            var allProduct = _context.Products.Where(p => p.Id == productId).Include(p => p.Supplier);
            if (allProduct.IsNullOrEmpty())
                throw new CustomException("No Product with this ID", 404);

            return allProduct.First();
        }

        /// <summary>
        /// Saves changes to the database.
        /// </summary>
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}