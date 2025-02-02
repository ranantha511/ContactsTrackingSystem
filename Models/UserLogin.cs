
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Security.Policy;

namespace ContactTrackingSystem.Models;

public class UserLogin
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [Display(Name = "Email")]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string? Username { get; set; }

    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Password is required")]
    [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$", ErrorMessage = "Invalid password format. \r\n Minimum characters is 8 in length.\r\n At least one uppercase letter.\r\n At least one lowercase letter.\r\nAt least one digit.")]
    public string? Password { get; set; }
}
