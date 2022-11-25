#pragma warning disable CS8602
using System.ComponentModel.DataAnnotations;

namespace MocaMovies.Models
{
    public class Movie_Rate
    {
        [Key]
        public int Id { get; set; }
        public int? MovieId { get; set; }
        public Movie? Movie { get; set; }
        public double? TotalRate { get; set; }
    }
}
