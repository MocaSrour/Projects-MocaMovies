using System.ComponentModel.DataAnnotations;

namespace MocaMovies.Data.ViewModels
{
    public class RegisterVM
    {
        public string? FullName { get; set; }
        public string? Email { get; set; }
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        public string? ConfirmPass { get; set; }
    }
}
