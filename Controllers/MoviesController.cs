using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidley.Models;
using Vidley.ViewModels;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System;
using Microsoft.Owin.Security.Provider;

namespace Vidley.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ViewResult ViewMovies()
        {
            var movies = _context.Movie.Include(g => g.Genre).ToList();
            return View(movies);
        }

        public ActionResult EditMovie(int id)
        {
            var movie = _context.Movie.SingleOrDefault(m =>m.Id==id);
            var newMovieView = new NewMovieViewModel(movie)
            {
                
                Genre = _context.Genres.ToList()
            };
            return View(newMovieView);
        }

        public ActionResult NewMovie()
        {
            var genre = _context.Genres.ToList();
            var newMovieView = new NewMovieViewModel
            {
                Genre = genre
            };
            return View("EditMovie",newMovieView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie Movie)
        {
            if (!ModelState.IsValid)
            {
                var movie = new NewMovieViewModel(Movie)
                {
                   
                    Genre = _context.Genres.ToList()
                };
                return View("EditMovie",movie);
            }
            if (Movie.Id == 0)
            {
                Movie.DateAdded = DateTime.Now;
                _context.Movie.Add(Movie);
            }
            else 
            {
                var MovieInDb = _context.Movie.Single(m => m.Id == Movie.Id);
                TryUpdateModel(MovieInDb);
                MovieInDb.Name = Movie.Name;
                MovieInDb.ReleaseDate = Movie.ReleaseDate;
                MovieInDb.Genre = Movie.Genre;
                MovieInDb.NumberInstock = Movie.NumberInstock;
            }
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }
            return RedirectToAction("ViewMovies", "Movies");
        }

        // GET: Movies/Random
        public ActionResult MovieDetails(int id)
        {
            var movie = _context.Movie.Include(g => g.Genre).SingleOrDefault(m => m.Id==id);
            var viewmodel = new RandomMovieViewModel
            {
                Movie = movie
            };
            return View(viewmodel);
        }
    }
}