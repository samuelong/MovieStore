using Microsoft.AspNetCore.Mvc;
using MovieStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Controllers
{
    public class MovieController : Controller
    {
        private IMovieRepository repository;

        public MovieController(IMovieRepository repo)
        {
            repository = repo;
        }

        public ViewResult List() => View(repository.Movies);
    }
}
