using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RiyasMold.Data;
using System;
using System.Linq;

namespace RiyasMold.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RiyasMoldContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RiyasMoldContext>>()))
            {
                // Look for any movies.
                if (context.Ice.Any())
                {
                    return;   // DB has been seeded
                }

                context.Ice.AddRange(
                    new Ice
                    {
                        Type = "single",
                        Size = "small",
                        Grids = 4,
                        Color = "blue",
                        Shape = "star",
                        Price = 12.03M,
                        Material = "silicon",
                        Ratings = 4
                    },

                    new Ice
                    {
                        Type = "double",
                        Size = "medium",
                        Grids = 8,
                        Color = "red",
                        Shape = "square",
                        Price = 10.9M,
                        Material = "plastic",
                        Ratings = 3
                    },

                     new Ice
                     {
                         Type = "single",
                         Size = "large",
                         Grids = 12,
                         Color = "purple",
                         Price = 9.33M,
                         Shape = "circle",
                         Material = "metal",
                         Ratings = 1
                     },

                     new Ice
                     {
                         Type = "double",
                         Size = "medium",
                         Grids = 6,
                         Color = "red",
                         Shape = "heart",
                         Price = 20.11M,
                         Material = "silicon",
                         Ratings = 4
                     },

                      new Ice
                      {
                          Type = "single",
                          Size = "small",
                          Grids = 4,
                          Color = "silver",
                          Shape = "dolphin",
                          Price = 23.78M,
                          Material = "silicon",
                          Ratings = 5
                      },

                      new Ice
                      {
                          Type = "double",
                          Size = "medium",
                          Grids = 8,
                          Color = "aqua",
                          Shape = "rectangle",
                          Price = 17.09M,
                          Material = "plastic",
                          Ratings = 3
                      },

                      new Ice
                      {
                          Type = "single",
                          Size = "large",
                          Grids = 10,
                          Color = "aqua",
                          Shape = "strawberry",
                          Price = 30.05M,
                          Material = "silicon",
                          Ratings = 5
                      },

                      new Ice
                      {
                          Type = "double",
                          Size = "large",
                          Grids = 6,
                          Color = "green",
                          Shape = "hexagon",
                          Price = 33.98M,
                          Material = "plastic",
                          Ratings = 3
                      },

                      new Ice
                      {
                          Type = "single",
                          Size = "small",
                          Grids = 4,
                          Color = "mistyrose",
                          Shape = "bear",
                          Price = 12.02M,
                          Material = "silicon",
                          Ratings = 4
                      },

                      new Ice
                      {
                          Type = "double",
                          Size = "large",
                          Grids = 8,
                          Color = "white",
                          Shape = "traingle",
                          Price = 18.7M,
                          Material = "metal",
                          Ratings = 3
                      }
                );
                context.SaveChanges();
            }
        }
    }
}