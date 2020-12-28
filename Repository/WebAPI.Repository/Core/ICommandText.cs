namespace WebAPI.Repository.Core
{
    /// <summary>
    /// Returns the sql command texts
    /// </summary>
    public interface ICommandText
    {
        /// <summary>
        /// Returns sql query to get all products 
        /// </summary>
        string GetProducts { get; }

        /// <summary>
        /// Returns sql query to get product by id
        /// </summary>
        string GetProductById { get; }

        /// <summary>
        /// Returns sql query to add product
        /// </summary>
        string AddProduct { get; }

        /// <summary>
        /// Returns sql query to update product
        /// </summary>
        string UpdateProduct { get; }

        /// <summary>
        /// Returns sql query to remove product
        /// </summary>
        string RemoveProduct { get; }
    }
}
