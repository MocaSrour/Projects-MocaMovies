#pragma warning disable CS8602
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using MocaMovies.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace MocaMovies.Models
{
    public class Producer : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? ProfilePicURL { get; set; }
        public string? Bio { get; set; }

        //Relationships
        [ValidateNever]
        public List<Movie> Movies { get; set; } = default!;

    }
}
