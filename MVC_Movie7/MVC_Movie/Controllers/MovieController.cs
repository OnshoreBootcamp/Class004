using BLL;
using MVCMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMovie.Controllers
{
    public class MovieController : Controller
    {
        static List<Movie> movies = new List<Movie>();
        static List<Movie> finalMovies = new List<Movie>();
        //
        // GET: /Movie/
        public ActionResult Index()
        {
            List<Movie> movieIndexList = GetAllMovies();
            return View(movieIndexList);
        }

        public List<Movie> GetAllMovies()
        {
            List<Movie> movieList = new List<Movie>();
            List<MovieVM> newMovie = new List<MovieVM>();
            Logic logic = new Logic();
            Movie movie = new Movie();
            newMovie = logic.GetAllMovies();
            foreach (MovieVM movieVm in newMovie)
            {
                movie = ConvertMovieVmToMovie(movieVm);
                bool x = movieList.Contains(movie);
                if (x == false)
                {
                    movieList.Add(movie);
                }
            }
            return movieList;
        }

        //
        // GET: /Movie/Details/5
        public ActionResult Details(Movie movie)
        {
            return View(movie);
        }

        //
        // GET: /Movie/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Movie/Create
        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            Logic logic = new Logic();
            if (!ModelState.IsValid)
            {
                return View("Create", movie);
            }
            logic.CreateMovie(movie.title, movie.releaseDate, movie.genre);
            movies.Add(movie);
            return RedirectToAction("Index");
        }

        //
        // GET: /Movie/Edit/5
        public ActionResult Edit(Movie movie)
        {
            return View(movie);
        }

        //
        // POST: /Movie/Edit/5
        [HttpPost]
        public ActionResult Edit(Movie movie, FormCollection collection)
        {
            List<Movie> movieList = GetAllMovies();
            Logic logic = new Logic();
            if (!ModelState.IsValid)
            {
                return View("Edit", movie);
            }
            foreach (Movie mo in movieList)
            {
                if (mo.id == movie.id)
                {
                    mo.id = movie.id;
                    mo.title = movie.title ?? "";
                    mo.releaseDate = movie.releaseDate;
                    mo.genre = movie.genre ?? ""; 
                    logic.UpdateMovie(mo.id, mo.title, mo.releaseDate, mo.genre);
                }
            }
            return RedirectToAction("Index");
        }

        //
        // GET: /Movie/Delete/5
        public ActionResult Delete(Movie movie)
        {
            return View(movie);
        }

        //
        // POST: /Movie/Delete/5
        [HttpPost]
        public ActionResult Delete(Movie movie, FormCollection collection)
        {
            List<MovieVM> newMovie = new List<MovieVM>();
            Logic logic = new Logic();
            newMovie = logic.GetAllMovies();
            foreach (MovieVM mo in newMovie)
            {
                if (mo.id == movie.id)
                {
                    logic.DeleteMovie(mo.id);
                }
            }
            return RedirectToAction("Index");
        }
        public Movie ConvertMovieVmToMovie(MovieVM movieVm)
        {
            Movie movie = new Movie();
            if (movieVm != null)
            {
                movie.id = movieVm.id;
                movie.genre = movieVm.genre;
                movie.title = movieVm.title;
                movie.releaseDate = movieVm.releaseDate;
            }
            return movie;
        }
    }
}
