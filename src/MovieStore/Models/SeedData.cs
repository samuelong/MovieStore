﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MovieStore.Models
{
    // This file is to Fill the Database up with premade Values.
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            AppIdentityDbContext appContext = app.ApplicationServices
               .GetRequiredService<AppIdentityDbContext>();
            if (!appContext.Movies.Any())
            {
                appContext.Movies.AddRange(
                    new Movie("Superman", new DateTime(2017, 1, 1), 60, "Brandon", "Brandon, Samuel, Jourdan", "", 100)
                );
            }
            appContext.SaveChanges();
        }
    }
}
