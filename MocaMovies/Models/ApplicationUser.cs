#pragma warning disable CS8602
using Microsoft.AspNetCore.Identity;

namespace MocaMovies.Models
{
    public class ApplicationUser : IdentityUser
    {
        //[Key]
        //public int Id { get; set; }
        public string? FullName { get; set; }
        //  public List<RatingByUser> RatingMovies { get; set; }
    }
}
