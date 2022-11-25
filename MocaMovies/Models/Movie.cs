
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using MocaMovies.Data.Base;
using MocaMovies.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MocaMovies.Models
{
    public class Movie : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public string? Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Describtion { get; set; }
        public string? ImgURL { get; set; }

        public double? MovieRate { get; set; }

        public MovieCategory MovieCategory { get; set; }

        //Relationships
        [ValidateNever]
        public List<Actor_Movie> Actors_Movies { get; set; }

        // Producer
        public int? ProducerId { get; set; }
        [ForeignKey("ProducerId")]
        public Producer? Producer { get; set; }

        public MovieVideo movieVideo { get; set; }
        public List<Movie_Rate> Movies_Rates { get; set; }
    }
}
