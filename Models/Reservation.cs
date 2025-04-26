using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace restaurant_management.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Please enter customer name")]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; } = string.Empty;
        
        [Display(Name = "Phone Number")]
        public string CustomerPhone { get; set; } = string.Empty;
        
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [Display(Name = "Email")]
        public string CustomerEmail { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Please select reservation date")]
        [Display(Name = "Reservation Date")]
        public DateTime ReservationDate { get; set; } = DateTime.UtcNow;
        
        [Required(ErrorMessage = "Please enter party size")]
        [Range(1, 20, ErrorMessage = "Party size must be 1-20")]
        [Display(Name = "Party Size")]
        public int PartySize { get; set; }
        
        [Display(Name = "Special Requests")]
        public string SpecialRequests { get; set; } = string.Empty;
        
        [Required]
        [Display(Name = "Table")]
        public int TableId { get; set; }
        
        [ForeignKey("TableId")]
        [ValidateNever]  // Prevent validation on navigation property
        public Table Table { get; set; } = null!;
    }
}