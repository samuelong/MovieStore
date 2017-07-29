﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using MovieStore.Models;
using MovieStore.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

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

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
    }
}