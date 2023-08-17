using System.ComponentModel.DataAnnotations;

namespace SimpleStudyAPI.ViewModels
{
    public class RegisterModel
    {
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Password Confirm")]
        [Compare("Password", ErrorMessage = "Senhas não conferem")]
        public string ConfirmedPassword { get; set; }
    }
}
