using System.ComponentModel.DataAnnotations;

namespace SimpleStudyAPI.Models
{
    public partial class Student
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(50, ErrorMessage = "Name must has maximum 50 caracteres")]
        public string Name { get; set; }
        [Required, EmailAddress, StringLength(100, ErrorMessage = "Email must has maximum 100 caracteres")]
        public string Email { get; set; }
        [Required]
        public int Age { get; set; }
    }
}
