using System.ComponentModel.DataAnnotations;

namespace WebAPI.Business.Dto
{
    public class ProductDto
    {
        [Required(ErrorMessage = "Please provide product name")]
        [StringLength(50)]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Please provide product cost")]
        public double Cost { get; set; }
    }
}
