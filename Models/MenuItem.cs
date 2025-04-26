using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace restaurant_management.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Menu item name is required")]
        [StringLength(100, MinimumLength = 3, 
            ErrorMessage = "Name must be between 3 and 100 characters")]
        [Display(Name = "Menu Item")]
        [RegularExpression(@"^[a-zA-Z0-9\s\-']+$", 
            ErrorMessage = "Only letters, numbers, spaces, hyphens, and apostrophes are allowed")]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string Description { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 1000.00, ErrorMessage = "Price must be between $0.01 and $1000.00")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Price")]
        public decimal Price { get; set; }
        
        [Required(ErrorMessage = "Category is required")]
        [StringLength(50, ErrorMessage = "Category cannot exceed 50 characters")]
        [Display(Name = "Menu Category")]
        public string Category { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Restaurant is required")]
        [Display(Name = "Restaurant")]
        public int RestaurantId { get; set; }
        
        [ForeignKey("RestaurantId")]
        [Display(Name = "Restaurant")]
        public virtual Restaurant? Restaurant { get; set; }
    }
}