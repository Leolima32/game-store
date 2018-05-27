using System;
using System.Collections.Generic;
using System.Linq;
using GameStore.Domain.Entities;
using GameStore.Domain.Entities.ReleationshipEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace GameStore.Infra.Data.Context
{
    public static class DbInitializer
    {
        public static void Initialize(GameStoreContext context, IConfiguration Configuration,
        UserManager<IdentityUser> _userManager, RoleManager<IdentityRole> _roleManager)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            // Look for any games.
            if (context.Games.Any())
            {
                return;   // DB has been seeded
            }

            var role1 = new IdentityRole() { Name = "Admin" };
            var role2 = new IdentityRole() { Name = "Customer" };

            _roleManager.CreateAsync(role1);
            _roleManager.CreateAsync(role2);


            var user1 = new IdentityUser() { UserName = "Admin", Email = "admin@admin.com" };
            var user2 = new IdentityUser() { UserName = "RandomCustomer", Email = "satisfiedcustomer@email.com" };

            _userManager.CreateAsync(user1, "Admin123*");
            _userManager.CreateAsync(user2, "R@mdonUs3r");
            _userManager.AddToRoleAsync(user1, "Admin");

            var companies = new Company[]
            {
                new Company() { Id = new Guid("{3a332845-6a75-48f9-b7bf-5427570f8d9a}"),
                Name = "Square Enix", Country = "Japan", Founded = new DateTime(1975,9,22) },
                new Company() { Id = new Guid("{0a2a7f09-6ddd-4bfe-8e90-77078722336e}"),
                Name = "Rockstar Games", Country = "EUA", Founded = new DateTime(1998,12,1) },
                new Company() { Id = new Guid("{4cb6f093-ad07-461c-a06e-2397c085da24}"),
                Name = "Ubisoft", Country = "France", Founded = new DateTime(1986,3,1) },
                new Company() { Id = new Guid("{6175caa0-b1b6-43bc-be04-3b9331a97ae1}"),
                Name = "Rockstar North", Country = "EUA", Founded = new DateTime(1986,3,1) },
                new Company() { Id = new Guid("{8c8d7567-093b-4189-a356-be16c87dbbbf}"),
                Name = "Ubisoft Montreal", Country = "France", Founded = new DateTime(1986,3,1) },
                new Company() { Id = new Guid("{eaa46a23-84b1-49cc-be5e-d47eb2b9c53b}"),
                Name = "Eletronic Arts", Country = "Eua", Founded = new DateTime(1982,5,28) },
                new Company() { Id = new Guid("{30c7ee53-48e5-4ff3-929e-21128db40ed8}"),
                Name = "Nintendo", Country = "Japan", Founded = new DateTime(1889,9,23) },
                new Company() { Id = new Guid("{ca431f3c-3c5d-498f-8f0f-c4c9ed42eef7}"),
                Name = "Bethesda", Country = "EUA", Founded = new DateTime(1986,6,28) },
                new Company() { Id = new Guid("{fe83a56a-b736-4f9e-b09a-c8b7d7c0e6a8}"),
                Name = "Capcom", Country = "Japan", Founded = new DateTime(1983,6,11) },
                new Company() { Id = new Guid("{11e0617a-93e9-4a71-8786-229d8ce74257}"),
                Name = "Bandai Namco", Country = "Japan", Founded = new DateTime(2006,3,31) }
            };
            foreach (Company s in companies)
            {
                context.Companies.Add(s);
            }

            var plataforms = new Plataform[]
            {
                new Plataform() { Id = new Guid("{d64c2f9d-7a4e-423d-bc1c-28f50387b3ad}"),
                Name = "Playstation 4"},
                new Plataform() { Id = new Guid("{173f056c-0ddf-4581-a32d-f84109fd8145}"),
                Name = "Xbox One"},
                new Plataform() { Id = new Guid("{16df4c17-7f30-4fff-a90e-b379eb720f3f}"),
                Name = "PC"},
                new Plataform() { Id = new Guid("{2f2e3bfc-ac34-4248-a2ed-6da69648ef97}"),
                Name = "Nintendo Switch"}
            };
            foreach (Plataform s in plataforms)
            {
                context.Plataforms.Add(s);
            }

            var genres = new Genre[]
            {
                new Genre() { Id = new Guid("{93e7acd0-747c-4468-8ff8-f3172f5ace06}"),
                Name = "RPG"},
                new Genre() { Id = new Guid("{8a2593d7-7ae1-4a0a-89e4-a9aaeaba8074}"),
                Name = "Action"},
                new Genre() { Id = new Guid("{089345b7-8ee8-4290-b840-5d0e20aba317}"),
                Name = "Shooter"},
                new Genre() { Id = new Guid("{2e58aa56-b10a-4452-9058-b90aa1fba50f}"),
                Name = "Strategy"},
                new Genre() { Id = new Guid("{751c63a8-32f0-43ee-a4fa-e8dad4e16625}"),
                Name = "Sports"},
                new Genre() { Id = new Guid("{28ff626a-6712-4a6e-9879-63085c41c040}"),
                Name = "MOBA"},
                new Genre() { Id = new Guid("{cce2cfa8-f395-4e72-8b1c-313eafb62983}"),
                Name = "MMO"},
                new Genre() { Id = new Guid("{f437ee6e-e7d1-46dc-888c-a1d68be6a567}"),
                Name = "Fighter"},
                new Genre() { Id = new Guid("{22f7f4e1-c431-4de6-8469-028c2fdc0e0a}"),
                Name = "Simulator"}
            };
            foreach (Genre s in genres)
            {
                context.Genres.Add(s);
            }

            var games = new Game[]
            {
                new Game() { Id = new Guid(), Name = "Final Fantasy XV",
                ShortDescription = "an open world action role-playing video game developed "
                +"and published by Square Enix", Score = 9.8, Price = 89.99,
                Description = "Final Fantasy XV takes place on the fictional world of Eos. "
                +"All the world's countries,bar the kingdom of Lucis, are under the dominion of"
                +"the empire of Niflheim. Noctis Lucis Caelum, heir to the Lucian throne, goes on"
                +"a quest to retake his homeland and its magical Crystal ",
                ReleaseDate = new DateTime(2016,11,9), ImageUrl = $"http://{Configuration["BaseUrl"]}images/ffxv.jpg"
                },
                new Game() { Id = new Guid(), Name = "Grand Theft Auto V",
                ShortDescription = "the single-player story follows three criminals and their efforts to commit "
                +"heists while under pressure from a government agency.", Score = 10, Price = 59.99,
                Description = "The game is played from either a third-person or first-person"
                +"perspective and its world is navigated on foot or by vehicle. Players control the "
                +"three lead protagonists throughout single-player and switch between them both during "
                +"and outside missions.",
                ReleaseDate = new DateTime(2013,9,17), ImageUrl =  $"http://{Configuration["BaseUrl"]}images/gtav.jpg"
                },
                new Game() { Id = new Guid(), Name = "Child of light",
                ShortDescription = "Aurora, a young girl from 1895 Austria, "
                +"awakens on the lost fairytale", Score = 8.5, Price = 69.99,
                Description = "The game's story takes place in the fictional land of Lemuria. "
                +"Aurora, a child who wakes up in Lemuria after freezing to death, "
                +"must bring back the sun, the moon and the stars held captive "
                +"by the Queen of the Night in order to return.",
                ReleaseDate = new DateTime(2014,4,29), ImageUrl =  $"http://{Configuration["BaseUrl"]}images/childoflight.jpg"
                },
                new Game() { Id = new Guid(), Name = "The Legend of Zelda: Breath of the Wild",
                ShortDescription = "The Legend of Zelda: Breath of the Wild was very highly received. "
                +"It currently has a 98/100 on Metacritic, making it the highest scoring game this decade", Score = 8.5, Price = 129.99,
                Description = "The Legend of Zelda: Breath of the Wild is the nineteenth "
                +"main installment of The Legend of Zelda series. It was "
                +"released simultaneously worldwide for the Wii U and "
                +"Nintendo Switch on March 3, 2017.",
                ReleaseDate = new DateTime(2014,4,29), ImageUrl =  $"http://{Configuration["BaseUrl"]}images/childoflight.jpg"
                }
            };
            foreach (Game s in games)
            {
                context.Games.Add(s);
            }

            context.AddRange(
                new GameDeveloper { Game = games[0], Developer = companies[0] },
                new GameDeveloper { Game = games[1], Developer = companies[1] },
                new GameDeveloper { Game = games[2], Developer = companies[2] },
                new GameDeveloper { Game = games[3], Developer = companies[6] },
                new GameGenre { Game = games[0], Genre = genres[0] },
                new GameGenre { Game = games[1], Genre = genres[1] },
                new GameGenre { Game = games[2], Genre = genres[0] },
                new GameGenre { Game = games[3], Genre = genres[0] },
                new GameGenre { Game = games[3], Genre = genres[1] },
                new GamePlataform { Game = games[0], Plataform = plataforms[0] },
                new GamePlataform { Game = games[1], Plataform = plataforms[1] },
                new GamePlataform { Game = games[1], Plataform = plataforms[2] },
                new GamePlataform { Game = games[2], Plataform = plataforms[2] },
                new GamePlataform { Game = games[3], Plataform = plataforms[3] },
                new GamePublisher { Game = games[0], Publisher = companies[0] },
                new GamePublisher { Game = games[1], Publisher = companies[3] },
                new GamePublisher { Game = games[2], Publisher = companies[4] },
                new GamePublisher { Game = games[3], Publisher = companies[6] });

            context.SaveChanges();
        }
    }
}