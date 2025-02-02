using ContactTrackingSystem.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ContactTrackingSystem.ViewModels
{
    public class ContactViewModel
    {

        public ContactViewModel()
        {
            
        }

        [Key]
        public Guid ContactId { get; set; } //primary key

        [Display(Name = "First Name")]
        [Required(ErrorMessage ="First name is required")]
        [StringLength(50, ErrorMessage = "First Name cannot exceed 50 characters.")] //nvarchar(100)
        public string? FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, ErrorMessage = "Last Name cannot exceed 50 characters.")]
        public string? LastName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email address is required")]
        //[EmailAddress(ErrorMessage = "Invalid email address.")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Invalid email address.")]
        public string? EmailAddress { get; set; }

        [Display(Name = "Phone Number")]
        //[Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^\(?\d{3}\)?[-.\s]?\d{3}[-.\s]?\d{4}$", ErrorMessage = "Invalid phone number format")]
        public string? PhoneNumber { get; set; }

        [Display(Name = "Zipcode")]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid ZIP code format.")]
        public string? ZipCode { get; set; }
    }
}
