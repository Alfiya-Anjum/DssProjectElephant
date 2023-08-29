using DssProjectElephant.Models;
using System.ComponentModel.DataAnnotations;

public class RegistrationViewModel
{
    

    [Display(Name = "Email")]
    [Required(ErrorMessage = "Email is required!")]
    public string? Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    [Display(Name = "Confirm Password")]
    [Required(ErrorMessage = "Confirm Your Password Please!")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "-> Passwords do not match!! <-")]
    public string? ConfirmPassword { get; set; }

    


}