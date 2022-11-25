using MocaMovies.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace MocaMovies.Data.ViewModels
{
    public class NewMovieVM
    {
        public int Id { get; set; } = 0;
        [Required]
        public string? Title { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Describtion { get; set; }
        public string? ImgURL { get; set; }
        //Relationships
        public List<int?>? ActorIds { get; set; }
        public MovieCategory MovieCategory { get; set; }
        // Producer
        public int? ProducerId { get; set; }
    }
}
