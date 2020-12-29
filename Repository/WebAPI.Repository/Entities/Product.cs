using System;
using System.ComponentModel.DataAnnotations;

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
        [Required(ErrorMessage = "Please provide product id")]
        [Range(1, int.MaxValue, ErrorMessage = "Product id can not be zero")]
        public int Id { get; set; }

        /// <summary>
        /// Product Name
        /// </summary>
        [Required(ErrorMessage = "Please provide product name")]
        [StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// Product Cost
        /// </summary>
        [Required(ErrorMessage = "Please provide product cost")]
        [Range(1, int.MaxValue, ErrorMessage = "Product cost can not be zero")]
        public double Cost { get; set; }
    }
}
