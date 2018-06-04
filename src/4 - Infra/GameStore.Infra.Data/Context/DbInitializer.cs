using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameStore.Domain.Entities;
using GameStore.Domain.Entities.Enums;
using GameStore.Domain.Entities.ReleationshipEntities;
using GameStore.Domain.ValueObjects;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace GameStore.Infra.Data.Context
{
    public static class DbInitializer
    {
        public static async Task Initialize(GameStoreContext context, IConfiguration Configuration,
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

            await _roleManager.CreateAsync(role1);
            await _roleManager.CreateAsync(role2);


            var user1 = new IdentityUser() { UserName = "Admin", Email = "admin@admin.com" };
            var user2 = new IdentityUser() { UserName = "RandomCustomer", Email = "satisfiedcustomer@email.com" };

            await _userManager.CreateAsync(user1, "Admin123*");
            await _userManager.CreateAsync(user2, "R@mdonUs3r");
            await _userManager.AddToRoleAsync(user1, "Admin");
            await _userManager.AddToRoleAsync(user2, "Customer");

            var companies = new Company[]
            {
                new Company(new CompanyName("Square Enix"),new DateTime(1975,9,22)),
                new Company(new CompanyName("Rockstar Games"),new DateTime(1998,12,1)),
                new Company(new CompanyName("Ubisoft"), new DateTime(1986,3,1) ),
                new Company(new CompanyName("Rockstar North"), new DateTime(1986,3,1)),
                new Company(new CompanyName("Ubisoft Montreal"), new DateTime(1986,3,1)),
                new Company(new CompanyName("Eletronic Arts"),new DateTime(1982,5,28)),
                new Company(new CompanyName("Nintendo"), new DateTime(1889,9,23)),
                new Company(new CompanyName("Bethesda"), new DateTime(1986,6,28)),
                new Company(new CompanyName("Capcom"), new DateTime(1983,6,11)),
                new Company(new CompanyName("Bandai Namco"),new DateTime(2006,3,31))
            };
            foreach (Company s in companies)
            {
                context.Companies.Add(s);
            }

            var plataforms = new Plataform[]
            {
                new Plataform("Playstation 4"),
                new Plataform("Xbox One"),
                new Plataform("PC"),
                new Plataform("Nintendo Switch")
            };
            foreach (Plataform s in plataforms)
            {
                context.Plataforms.Add(s);
            }

            var genres = new Genre[]
            {
                new Genre("RPG"),
                new Genre("Action"),
                new Genre("Shooter"),
                new Genre("Strategy"),
                new Genre("Sports"),
                new Genre("MOBA"),
                new Genre("MMO"),
                new Genre("Fighter"),
                new Genre("Simulator")
            };
            foreach (Genre s in genres)
            {
                context.Genres.Add(s);
            }

            var games = new Game[]
            {
                new Game("Final Fantasy XV",
                "Final Fantasy XV takes place on the fictional world of Eos. "
                +"All the world's countries,bar the kingdom of Lucis, are under the dominion of"
                +"the empire of Niflheim. Noctis Lucis Caelum, heir to the Lucian throne, goes on"
                +"a quest to retake his homeland and its magical Crystal ",
                "an open world action role-playing video game developed and published by Square Enix",
                9.8, EDepartment.Game, 89.99, new DateTime(2016,11,9)),

                new Game("Grand Theft Auto V",
                "The game is played from either a third-person or first-person"
                +"perspective and its world is navigated on foot or by vehicle. Players control the "
                +"three lead protagonists throughout single-player and switch between them both during "
                +"and outside missions.",
                "the single-player story follows three criminals and their efforts to commit "
                +"heists while under pressure from a government agency.", 10, EDepartment.Game, 59.99, new DateTime(2013,9,17)),

                new Game("Child of light",
                "The game's story takes place in the fictional land of Lemuria. "
                +"Aurora, a child who wakes up in Lemuria after freezing to death, "
                +"must bring back the sun, the moon and the stars held captive "
                +"by the Queen of the Night in order to return.",
                " Aurora, a young girl from 1895 Austria, awakens on the lost fairytale", 
                8.5, EDepartment.Game, 69.99, new DateTime(2014,4,29)),

                new Game("The Legend of Zelda: Breath of the Wild",
                "The Legend of Zelda: Breath of the Wild is the nineteenth "
                +"main installment of The Legend of Zelda series. It was "
                +"released simultaneously worldwide for the Wii U and "
                +"Nintendo Switch on March 3, 2017.",
                "The Legend of Zelda: Breath of the Wild was very highly received. "
                +"It currently has a 98/100 on Metacritic, making it the highest scoring game this decade",
                8.5, EDepartment.Game, 129.99, new DateTime(2014,4,29))
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