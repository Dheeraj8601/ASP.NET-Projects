using System;
using System.ComponentModel.DataAnnotations;

namespace ASP.Models
{
    public class CustomerInfo
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "First Name is required")]
        public string Firstname { get; set; }
        
        [Required(ErrorMessage = "Last Name is required")]
        public string Lastname { get; set; }
        
        [Required(ErrorMessage = "Email is required"), EmailAddress]
        public string Email { get; set; }
        
        [Phone]
        public string? Phone { get; set; }
        
        public string? Address { get; set; }
        
        [Required(ErrorMessage = "Company is required")]
        public string Company { get; set; }
        
        public string? Notes { get; set; }
        
        public DateTime CreatedAt { get; set; }
    }
}
