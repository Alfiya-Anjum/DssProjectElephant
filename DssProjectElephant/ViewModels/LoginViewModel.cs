using System.ComponentModel.DataAnnotations;

namespace DssProjectElephant.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Email Address")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string EmailAddress { get; internal set; }
    }
}
