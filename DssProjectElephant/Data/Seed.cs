﻿using DssProjectElephant.Data.Enum;
using DssProjectElephant.Models;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics.Metrics;

namespace DssProjectElephant.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContent>();

                context.Database.EnsureCreated();

                List<Address> addresses = new List<Address>()
                {
                    new Address()
                    {

                        Name = "Charlotte",
                        Country = "USA"
                    },
                    new Address()
                    {
                        Name = "Charlotte",
                        Country = "Cannada"
                    },
                    new Address()
                    {
                        Name = "Michigan",
                        Country = "USA"
                    }
                            


                };

                if (!context.Clubs.Any())
                {
                    context.Clubs.AddRange(new List<Club>()
                    {
                        new Club()
                        {
                            Name = "News Club 1",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "This is the description of the first cinema",
                            ClubCategory = ClubCategory.Academiclub,
                            Address = addresses[0]
                            
                            
                         },
                        new Club()
                        {
                            Name = "News Club 2",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "This is the description of the first cinema",
                            ClubCategory = ClubCategory.Journalism,
                            Address = addresses[1]
                            
                            
                        },
                        new Club()
                        {
                            Name = "News Club 3",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "This is the description of the first club",
                            ClubCategory = ClubCategory.Publication,
                            Address = addresses[1]
                            
                            
                        },
                        new Club()
                        {
                            Name = "News Club 3",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "This is the description of the first club",
                            ClubCategory = ClubCategory.Academiclub,
                            Address = addresses[2]
                            
                            
                            
                        }
                    });
                    context.SaveChanges();
                }
                //News
                if (!context.TheNews.Any())
                {
                    context.TheNews.AddRange(new List<TheNews>()
                    {
                        new TheNews()
                        {
                            Name = " The News 1",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "This is the description of the first race",
                            NewsCategory = NewsCategory.Articles,
                            Address = addresses[0]
                        },
                        new TheNews()
                        {
                            Name = "The News 2",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "This is the description of the first race",
                            NewsCategory = NewsCategory.LocalNews,
                           
                            Address = addresses[1]
                            
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}

//        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
//        {
//            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
//            {
//                //Roles
//                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

//                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
//                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
//                if (!await roleManager.RoleExistsAsync(UserRoles.User))
//                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

//                //Users
//                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
//                string adminUserEmail = "teddysmithdeveloper@gmail.com";

//                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
//                if (adminUser == null)
//                {
//                    var newAdminUser = new AppUser()
//                    {
//                        UserName = "teddysmithdev",
//                        Email = adminUserEmail,
//                        EmailConfirmed = true,
//                        Address = new Address()
//                        {
//                            ID = 1234,
//                            Name = "Charlotte",
//                            Country = "Usa",
//                              Address = new Address()
//                              {
//                                  ID = 5678,
//                                  Name = "Charlotte",
//                                  Country = "Cannada"
//                              }
//                        }
//                    };
//                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
//                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
//                }

//                string appUserEmail = "user@etickets.com";

//                var appUser = await userManager.FindByEmailAsync(appUserEmail);
//                if (appUser == null)
//                {
//                    var newAppUser = new AppUser()
//                    {
//                        Id = "app-user",
//                        Email = appUserEmail,
//                        EmailConfirmed = true,
//                        Address = new Address()
//                        {
//                            ID = 5678,
//                            Name = "Charlotte",
//                            Country = "Cannada",
//                            Address = new Address()
//                              {
//                                  ID = 5678,
//                                  Name = "Charlotte",
//                                  Country = "Cannada"
//                              }
//                        }
//                    };
//                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
//                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
//                }
//            }
//        }
//    }
//}

