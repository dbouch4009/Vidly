using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()  //GET: Movies/Random
        {
            var movie = new Movie();
            movie.Name = "Shrek";
            movie.Id = 55;

            var customers = new List<Customer>
            {
                new Customer {Name = "John Brown"},
                new Customer {Name = "Mary Grace"},
                new Customer {Name = "Sally Sueson"},
                new Customer {Name = "Constantine Carl"},
                new Customer {Name = "Henry Etta"},
                new Customer {Name = "Mary Smith"}
            };

            var viewModel = new RandomMovieViewModel
            {
                movie = movie,
                customers = customers
            };

            return View(viewModel);

            //alternate method
            //ViewData["Movie"] = movie;
            //return View();

            //ViewBag.Movie = movie;  //Movie property added at runtime, also garbage approach

            //return Content("Hello World");  //straight string content
            // return HttpNotFound();  //http codes
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });  //forward to different page with anonymous arguments
            //Returning ViewResult is a subtype of ActionResult, evoked by View()
        }

        public ActionResult Edit(int id)  //id will get automatically mapped per routeconfig.cs content
        {
            //http://localhost:51897/movies/edit/1
            return Content("id = " + id);
        }

        public ActionResult EditTest(int movieId) 
        {
            //http://localhost:51897/movies/edit/1
            return Content("id = " + movieId);
        }

        public ActionResult ByReleaseDate(int? year, int? month)  //mapped to second route
        {
            //"movies/released/{year}/{month}"
            if (year == null || month == null)
            {
                return Content("Invalid arguments");
            }
            return Content(year + "/" + month);
        }

        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if(!pageIndex.HasValue)
            {
                pageIndex = 1;
            }

            if(String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }

        //With attribute routing, does not require amendment to routeconfig.cs
        [Route("movies/rated/{rating:range(0,10):regex(\\d)}")]  //constraint is regular expression, 2 digits
        public ActionResult ByRating(int rating)
        {
            //{rating:regex(\\d{2}):range(0,10)}
            return Content("Rating is: " + rating);
        }

        [Route("MoviesList")]
        public ActionResult MoviesList()
        {
            MoviesListViewModel movieListVM = new MoviesListViewModel();
            var movieList = new List<Movie>();
            movieList.Add(new Movie { Id = 1, Name = "Logan" });
            movieList.Add(new Movie { Id = 2, Name = "Return of the King" });
            movieList.Add(new Movie { Id = 3, Name = "Jingle All The Way" });

            movieListVM.MovieList = movieList;

            return View(movieListVM);
            //return 
        }

    }
}