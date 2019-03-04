using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
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
        //
        // GET: /Movies/
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovie))
                return View("List");
            else
            {
                return View("ReadOnlyList");
            }
        }
        public ActionResult Detail(int Id)
        {
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(x=>x.Id==Id);
            return View(movie);
        }
        [Route("movies/released/{year}/{moth:regex(\\d{2})}")]
        public ActionResult ByReleaseDate(int year,int  moth)
        {
            return Content(year + "/" + moth);
        }
        [Authorize(Roles = RoleName.CanManageMovie)]
        public ActionResult New()
        {
            var genre = _context.Genres.ToList();
            var viewModel = new MovieGenreViewModel()
            {
                Movie = new Movie(),
                Genres = genre
            };
            return View("MovieForm", viewModel);
        }
        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            movie.DateAdded=DateTime.Now;
            if (movie.Id == 0)
                _context.Movies.Add(movie);
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index","Movies");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Single(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();
            var viewModel = new MovieGenreViewModel()
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }
    }
}