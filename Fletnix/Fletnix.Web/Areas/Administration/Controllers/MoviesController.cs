using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Fletnix.Domain;
using Fletnix.Domain.Services;
using Fletnix.Web.Areas.Administration.Models;

namespace Fletnix.Web.Areas.Administration.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // GET: Administration/Movies
        public async Task<ActionResult> Index()
        {
            var data = await _movieService.GetMoviesAsync();

            return View(data.Select(m => new Movie
            {
                Id = m.Id,
                Title = m.Title,
                Synopsis = m.Synopsis,
                Length = m.Length,
                ImageUri = m.ImageUri
            }));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                var ms = new MediaStream
                {
                    StreamId = Guid.NewGuid(),
                    MediaStreamTypeId = MediaStreamType.Movie,

                    Title = movie.Title,
                    Synopsis = movie.Synopsis,
                    ImageUri = movie.ImageUri,
                    Length = movie.Length
                };

                await _movieService.InsertMovieAsync(ms);
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        public async Task<ActionResult> Edit(int id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);
            if (movie == null)
            {
                return RedirectToAction("Index");
            }

            return View(new Movie
            {
                Id = movie.Id,
                Title = movie.Title,
                Synopsis = movie.Synopsis,
                Length = movie.Length,
                ImageUri = movie.ImageUri
            });
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Movie movie)
        {
            if (ModelState.IsValid)
            {
                var ms = new MediaStream
                {
                    Id = id,
                    StreamId = movie.StreamId,
                    Title = movie.Title,
                    Synopsis = movie.Synopsis,
                    ImageUri = movie.ImageUri,
                    Length = movie.Length,

                    MediaStreamTypeId = MediaStreamType.Movie
                };

                await _movieService.UpdateMovieAsync(ms);
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        public async Task<ActionResult> Details(int id)
        {
            var movie = await _movieService.GetMovieAndGenresByIdAsync(id);
            if (movie == null)
            {
                return RedirectToAction("Index");
            }
            
            var allGenres = await _movieService.GetGenresAsync();

            var movieDetails = new MovieDetails
            {
                Movie = new Movie
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Synopsis = movie.Synopsis,
                    Length = movie.Length,
                    ImageUri = movie.ImageUri
                },
                Genres = allGenres.Select(g => new GenreSelection
                {
                    Id = g.Id,
                    Name = g.Name,
                    IsSelected = movie.Genres.Any(mg => mg.Id == g.Id)
                }).ToList()
            };

            return View(movieDetails);
        }

        [HttpPost]
        public async Task<ActionResult> SaveGenres(int id, List<GenreSelection> genres)
        {
            if (ModelState.IsValid)
            {
                var movie = await _movieService.GetMovieAndGenresByIdAsync(id);
                var allGenres = await _movieService.GetGenresAsync();

                movie.Genres.Clear();
                foreach (var genre in genres.Where(g => g.IsSelected))
                {
                    movie.Genres.Add(allGenres.First(g => g.Id == genre.Id));
                }

                await _movieService.UpdateMovieAsync(movie);
                return Json(new { saved = true });
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}