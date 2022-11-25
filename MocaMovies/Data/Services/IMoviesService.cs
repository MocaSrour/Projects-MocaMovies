using MocaMovies.Data.Base;
using MocaMovies.Data.ViewModels;
using MocaMovies.Models;

namespace MocaMovies.Data.Services
{
    public interface IMoviesService : IEntityBaseRepository<Movie>
    {

        Task<Movie> GetMovieByIdAsync(int id);
        Task<NewMovieDropdownsVM> GetNewMovieDropdownValues();
        Task AddNewMovieAsync(NewMovieVM data);
        //  Task AddNewReviewAsync(RatingByUser ratingByUser, int id);
        Task UpdateMovieAsync(NewMovieVM data);
        Task<List<Movie>> GetAllMoviesWithRate();
        Task<List<RatingByUser>> GetAllReviewsByMovieId(int id);

        // double GetMovieCountAsync(int id);
    }
}
