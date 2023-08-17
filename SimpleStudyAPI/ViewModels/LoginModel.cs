using System.ComponentModel.DataAnnotations;

namespace SimpleStudyAPI.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email is required!")]
        [EmailAddress(ErrorMessage = "Format invalid!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required!")]
        [StringLength(20, ErrorMessage = "The {0} must have in mínimum {2} and máximum {1} caracteres")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


    }
}
