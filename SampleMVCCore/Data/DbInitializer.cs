using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleMVCCore.Models;
using SampleMVCCore.Data;


namespace SampleMVCCore.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (context.Movies.Any())
            {
                return;
            }

            var movies = new Movie[]
            {
                new Movie {ID=1,Title="Star Wars 1",Genre="Action",Price=12},
                new Movie {ID=2,Title="Star Wars 2",Genre="Action",Price=14}
            };

            foreach(var mov in movies)
            {
                context.Movies.Add(mov);
            }
            context.SaveChanges();
        }
    }
}
