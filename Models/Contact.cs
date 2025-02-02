using System.ComponentModel.DataAnnotations;

namespace ContactTrackingSystem.Models
{
    public class Contact
    {
        [Key]
        public Guid ContactId { get; set; } //primary key

        //[Display(Name = "First Name")]
        [StringLength(50)] //nvarchar(100)
        public string? FirstName { get; set; }

        //[Display(Name = "Last Name")]
        [StringLength(50)]
        public string? LastName { get; set; }

        //[Display(Name = "Email")]
        [StringLength(100)]
        public string? EmailAddress { get; set; }

        //[Display(Name = "Phone Number")]
        [StringLength(50)]
        public string? PhoneNumber { get; set; }

        //[Display(Name = "Zipcode")]
        [StringLength(50)]
        public string? ZipCode { get; set; }
    }
}
