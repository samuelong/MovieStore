using System;
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
            if (!appContext.Payments.Any())
            {
                appContext.Payments.AddRange(
                    new Payment("", Convert.ToDateTime("02/05/2016"), 2.03m)
                );
                appContext.SaveChanges();
            }
        }
    }
}
