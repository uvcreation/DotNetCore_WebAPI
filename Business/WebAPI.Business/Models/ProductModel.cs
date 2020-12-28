using System.ComponentModel.DataAnnotations;

namespace WebAPI.Business.Models
{
    /// <summary>
    /// Product Model
    /// </summary>
    public class ProductModel
    {
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
        public double Cost { get; set; }
    }
}
