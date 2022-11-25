using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MocaMovies.Data.Services;
using MocaMovies.Data.Static;
using MocaMovies.Data.ViewModels;

namespace MocaMovies.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;

        public MoviesController(IMoviesService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allMovies = await _service.GetAllMoviesWithRate();
            return View(allMovies);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allMovies = await _service.GetAllMoviesWithRate();

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allMovies.Where(n => n.Title.Contains(searchString) ||
                n.Describtion.Contains(searchString)).ToList();
                return View("Index", filteredResult);
            }
            return View("Index", allMovies);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Reviews(int id)
        {
            var reviewsById = await _service.GetAllReviewsByMovieId(id);

            return View("Reviews", reviewsById);

        }


        //GET: Movies/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {

            var movieDetails = await _service.GetMovieByIdAsync(id);
            return View(movieDetails);
        }


        //GET: Movies/Create
        public async Task<IActionResult> Create()
        {
            var movieDropdownData = await _service.GetNewMovieDropdownValues();

            ViewBag.Producers = new SelectList(movieDropdownData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownData.Actors, "Id", "FullName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM movie)
        {
            if (!ModelState.IsValid)
            {
                var movieDropdownData = await _service.GetNewMovieDropdownValues();

                ViewBag.Producers = new SelectList(movieDropdownData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropdownData.Actors, "Id", "FullName");
                return View(movie);
            }
            await _service.AddNewMovieAsync(movie);
            return RedirectToAction("Index");
        }
        //public async Task<IActionResult> AddReview()
        //{
        //    return View("AddReview");
        //}
        //[HttpPost]
        //public async Task<IActionResult> AddReview(RatingByUser ratingByUser, int id)
        //{
        //    await _service.AddNewReviewAsync(ratingByUser, id);
        //    return RedirectToAction("Reviews");
        //}


        //GET: Movies/Update/1
        public async Task<IActionResult> Edit(int id)
        {
            var movieDetails = await _service.GetMovieByIdAsync(id);
            if (movieDetails == null)
                return View("NotFound");

            var response = new NewMovieVM()
            {
                Id = movieDetails.Id,
                Title = movieDetails.Title,
                Describtion = movieDetails.Describtion,
                StartDate = movieDetails.StartDate,
                EndDate = movieDetails.EndDate,
                ImgURL = movieDetails.ImgURL,
                MovieCategory = movieDetails.MovieCategory,
                ProducerId = movieDetails.ProducerId,
                ActorIds = movieDetails.Actors_Movies.Select(n => n.ActorId).ToList()
            };

            var movieDropdownData = await _service.GetNewMovieDropdownValues();

            ViewBag.Producers = new SelectList(movieDropdownData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropdownData.Actors, "Id", "FullName");
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewMovieVM movie)
        {
            if (id != movie.Id)
                return View("NotFound");

            if (!ModelState.IsValid)
            {
                var movieDropdownData = await _service.GetNewMovieDropdownValues();

                ViewBag.Producers = new SelectList(movieDropdownData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropdownData.Actors, "Id", "FullName");
                return View(movie);
            }
            await _service.UpdateMovieAsync(movie);
            return RedirectToAction("Index");
        }


    }
}
