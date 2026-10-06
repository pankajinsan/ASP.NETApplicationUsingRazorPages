using System.ComponentModel.DataAnnotations;

namespace CRUDApplicationUsingRazorPages.Entity
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "User Name is required.")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
