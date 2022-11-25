#pragma warning disable CS8602
using System.ComponentModel.DataAnnotations;

namespace MocaMovies.Models
{
    public class RatingByUser
    {
        [Key]
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
        public int? MovieId { get; set; }
        public Movie? Movie { get; set; }
        public double? Rate { get; set; }
        public string? Review { get; set; }

    }
}
