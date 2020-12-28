using System;

namespace WebAPI.Repository.Entities
{
    /// <summary>
    /// Product Entity
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Product Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Product Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Product Cost
        /// </summary>
        public double Cost { get; set; }
    }
}
