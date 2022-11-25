#pragma warning disable CS8602
using System.ComponentModel.DataAnnotations.Schema;

namespace MocaMovies.Models
{
    public class MovieVideo
    {
        public int id { get; set; }
        [ForeignKey("MovieId")]
        public int? MovieId { get; set; }
        public string? URL { get; set; }
    }
}
