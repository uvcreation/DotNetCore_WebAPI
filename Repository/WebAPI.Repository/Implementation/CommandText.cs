using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Repository.Core;

namespace WebAPI.Repository.Implementation
{
    /// <summary>
    /// Returns the sql command text
    /// </summary>
    public class CommandText : ICommandText
    {
        /// <summary>
        /// Returns sql query to get all products 
        /// </summary>
        public string GetProducts => "Select Id, Name, Cost From Product";

        /// <summary>
        /// Returns sql query to get product by id
        /// </summary>
        public string GetProductById => "Select Id, Name, Cost From Product Where Id= @Id";

        /// <summary>
        /// Returns sql query to add product
        /// </summary>
        public string AddProduct => "Insert IGNORE Into Product (Name, Cost, CreatedDate) Values ;('{0}',{1}, NOW())";

        /// <summary>
        /// Returns sql query to update product
        /// </summary>
        public string UpdateProduct => "Insert IGNORE Into  Product (Id, Name, Cost, CreatedDate) Values ;({0}, '{1}',{2}, NOW()) ;ON DUPLICATE KEY UPDATE Name = VALUES(Name), Cost = VALUES(Cost)";

        /// <summary>
        /// Returns sql query to remove product
        /// </summary>
        public string RemoveProduct => "Delete From Product Where Id= @Id";
    }
}
