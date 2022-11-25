using Microsoft.AspNetCore.Identity;
using MocaMovies.Data.Static;
using MocaMovies.Models;

namespace MocaMovies.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                //Actors
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            FullName = "Will Smith",
                            Bio = "Bio Will Smith",
                            ProfilePicURL = "https://webcolours.ca/wp-content/uploads/2020/10/webcolours-unknown.png"
                        },

                        new Actor()
                        {
                            FullName = "Liam Neeson",
                            Bio = "Bio Liam Neeson",
                            ProfilePicURL = "https://webcolours.ca/wp-content/uploads/2020/10/webcolours-unknown.png"
                        }
                    });
                    context.SaveChanges();

                }

                //Producers
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                    {
                        FullName = "Producer 1",
                        Bio = " Producer Bio",
                        ProfilePicURL = "https://webcolours.ca/wp-content/uploads/2020/10/webcolours-unknown.png"
                    },


                        new Producer()
                    {
                        FullName = "Producer 2",
                        Bio = " Producer 2 Bio",
                        ProfilePicURL = "https://webcolours.ca/wp-content/uploads/2020/10/webcolours-unknown.png"
                        }
                    });
                    context.SaveChanges();
                }

                //Movies
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                    {
                        Title = "After Earth",
                        Describtion = "After Earth Description",
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(7),
                        ProducerId = 8,
                        ImgURL = "https://webcolours.ca/wp-content/uploads/2020/10/webcolours-unknown.png",
                        //Rating = 0,
                        MovieCategory = Enum.MovieCategory.Documentary

                    },
                        new Movie()
                    {
                        Title = "Taken",
                        Describtion = "Taken Description",
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(7),
                        ProducerId = 8,
                        ImgURL = "https://webcolours.ca/wp-content/uploads/2020/10/webcolours-unknown.png",
                       // Rating= 0,
                        MovieCategory = Enum.MovieCategory.Action

                    }
                    });
                    context.SaveChanges();

                }
                //Actors Movies
                if (!context.Actors_Movies.Any())
                {
                    context.Actors_Movies.AddRange(new List<Actor_Movie>()
                    {
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieId = 24

                        }
                    });
                    context.SaveChanges();

                }


                // Rating
                //if (!context.Ratings.Any())
                //{

                //    context.Ratings.AddRange(new List<Rating>()
                //    {
                //        new Rating()
                //        {
                //            Email = "Moca@Moca.com",
                //            UserId = "1ee26d88-57fa-42a2-8ecb-d4ff0c012daf",
                //            MovieId = 4,
                //            Rate = 8.9,
                //            Review = "A Really good Movie"
                //        }
                //    });
                //    context.SaveChanges();

                //}

            }
        }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                // Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));


                // Users

                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                string adminUserEmail = "admin@MocaMovies.com";
                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");

                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }



                string appUserEmail = "user@MocaMovies.com";
                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");

                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }



            }
        }
    }
}
