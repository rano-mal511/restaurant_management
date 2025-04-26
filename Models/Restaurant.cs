using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace restaurant_management.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Restaurant name is required")]
        [StringLength(100)]
        [Display(Name = "Restaurant Name")]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(200)]
        [Display(Name = "Address")]
        public string Address { get; set; } = string.Empty;
        
        [StringLength(20)]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; } = string.Empty;
        
        [EmailAddress]
        [StringLength(100)]
        [Display(Name = "Email Address")]
        public string Email { get; set; } = string.Empty;
        
        public ICollection<Table> Tables { get; set; } = new List<Table>();
        public ICollection<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
    }
}