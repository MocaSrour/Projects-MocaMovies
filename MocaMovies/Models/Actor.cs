#pragma warning disable CS8602
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using MocaMovies.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace MocaMovies.Models
{
    public class Actor : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "Profile Picture is Required")]
        public string? ProfilePicURL { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is Required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name must be 3 to 50 characters")]
        public string? FullName { get; set; }

        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography is Required")]
        public string? Bio { get; set; }


        //Relationships
        [ValidateNever]
        public List<Actor_Movie> Actors_Movies { get; set; }
    }
}
