using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using MocaMovies.Data.Base;
using MocaMovies.Data.ViewModels;
using MocaMovies.Models;

namespace MocaMovies.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {
        private readonly AppDbContext _context;
        public MoviesService(AppDbContext context) : base(context)
        {
            _context = context;
        }
        [AllowAnonymous]
        public async Task<List<Movie>> GetAllMoviesWithRate()
        {
            var allMovies = await _context.Movies
                .Include(am => am.Movies_Rates).ToListAsync();

            return allMovies;
        }
        public async Task<List<RatingByUser>> GetAllReviewsByMovieId(int id)
        {
            var reviewsById = await _context.RatingMoviesByUsers.Where(n => n.MovieId == id).ToListAsync();

            return reviewsById;
        }
        public async Task AddNewMovieAsync(NewMovieVM data)
        {
            var newMovie = new Movie()
            {
                Title = data.Title,
                Describtion = data.Describtion,
                ImgURL = data.ImgURL,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                MovieCategory = data.MovieCategory,
                ProducerId = data.ProducerId
            };
            await _context.Movies.AddAsync(newMovie);
            await _context.SaveChangesAsync();

            // Add Movie Actors
            foreach (var actorId in data.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = newMovie.Id,
                    ActorId = actorId
                };
                await _context.Actors_Movies.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movieDetails = await _context.Movies.Include(r => r.Movies_Rates)
                .Include(w => w.movieVideo)
                .Include(p => p.Producer)
                .Include(am => am.Actors_Movies).ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(n => n.Id == id);
            return movieDetails;
        }

        public async Task<NewMovieDropdownsVM> GetNewMovieDropdownValues()
        {
            var response = new NewMovieDropdownsVM()
            {
                Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync(),
                Producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync()
            };
            return response;
        }

        public async Task UpdateMovieAsync(NewMovieVM data)
        {
            var dbMovie = await _context.Movies.FirstOrDefaultAsync(n => n.Id == data.Id);
            if (dbMovie != null)
            {
                dbMovie.Title = data.Title;
                dbMovie.Describtion = data.Describtion;
                dbMovie.ImgURL = data.ImgURL;
                dbMovie.StartDate = data.StartDate;
                dbMovie.EndDate = data.EndDate;
                dbMovie.MovieCategory = data.MovieCategory;
                dbMovie.ProducerId = data.ProducerId;

                // await _context.Movies.AddAsync(newMovie);
                await _context.SaveChangesAsync();
            }

            // Remove existing actors
            var existingActorDb = _context.Actors_Movies.Where(n => n.MovieId == data.Id).ToList();
            _context.Actors_Movies.RemoveRange(existingActorDb);
            await _context.SaveChangesAsync();

            // Add Movie Actors
            foreach (var actorId in data.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = data.Id,
                    ActorId = actorId
                };
                await _context.Actors_Movies.AddAsync(newActorMovie);

            }
            await _context.SaveChangesAsync();
        }

        //public async Task AddNewReviewAsync(RatingByUser ratingByUser, int id)
        //{
        //    //var newRate = new RatingByUser()
        //    //{

        //    //    Email = ratingByUser.Email,
        //    //    UserId = ratingByUser.UserId,
        //    //    MovieId = id,
        //    //    Rate = ratingByUser.Rate,
        //    //    Review = ratingByUser.Review
        //    //};
        //    //await _context.RatingMoviesByUsers.AddAsync(ratingByUser);
        //    //await _context.SaveChangesAsync();
        //}



        //public double GetMovieRate(int MovieId)
        //{
        //    double rate = 0;
        //    var dbRating = _context.RatingMovies.Include(p => p.Rate).Where(n => n.MovieId == MovieId).ToList();

        //    foreach (var i in dbRating)
        //    {
        //        rate += i.Rate;
        //    }
        //    return rate / 2;

        //}
    }
}
