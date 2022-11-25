using System.ComponentModel.DataAnnotations;

namespace MocaMovies.Data.ViewModels
{
    public class LoginVM
    {
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
