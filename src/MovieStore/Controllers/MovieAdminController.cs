using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using MovieStore.Models;
using MovieStore.Models.ViewModels;

namespace MovieStore.Controllers
{
    [Authorize(Roles = "Admins")]
    public class MovieAdminController : Controller
    {
        private IMovieRepository repository;
        public int PageSize = 5;

        public MovieAdminController(IMovieRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index() => View(repository.Movies);

        public ViewResult List(int page = 1)
             => View(new MoviesListViewModel
             {

                 Movies = repository.Movies

                     .OrderBy(p => p.Title)

                     .Skip((page - 1) * PageSize)

                     .Take(PageSize),

                 PagingInfo = new PagingInfo
                 {

                     CurrentPage = page,

                     ItemsPerPage = PageSize,

                     TotalItems = repository.Movies.Count()

                 }

             });

        public ViewResult Edit(string title) =>
            View(repository.Movies
                .FirstOrDefault(m => m.Title == title));

        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            // SET THE MOVIE USING THE MOVIEMODEL!
            if (ModelState.IsValid)
            {
                repository.SaveMovie(movie);
                TempData["message"] = $"{movie.Title} has been saved";
                return RedirectToAction("Index");
            }
            else
            {
                return View(movie);
            }
        }

        public ViewResult Create() => View("Edit", new Movie());

        [HttpPost]
        public IActionResult Delete(int movieID)
        {
            Movie deletedMovie = repository.DeleteMovie(movieID);
            if (deletedMovie != null)
            {
                TempData["message"] = $"{deletedMovie.Title} was deleted";
            }
            return RedirectToAction("Index");
        }

        public ViewResult HomePage() => View("HomePage");
    }
}
