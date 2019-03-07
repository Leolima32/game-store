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
            // Look for any games.
            // if (context.Games.Any())
            // {
            //     return;   // DB has been seeded
            // }

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var role1 = new IdentityRole() { Name = "Admin" };
            var role2 = new IdentityRole() { Name = "Customer" };

            await _roleManager.CreateAsync(role1);
            await _roleManager.CreateAsync(role2);

            var user1 = new IdentityUser() { UserName = "Admin", Email = "admin@admin.com" };
            var user2 = new IdentityUser() { UserName = "RandomCustomer", Email = "satisfiedcustomer@email.com" };
            var user3 = new IdentityUser() { UserName = "Vaan", Email = "vaanrabanestre@email.com" };
            var user4 = new IdentityUser() { UserName = "BashRosenberg", Email = "bashdamalsca@email.com" };

            await _userManager.CreateAsync(user1, "Admin123*");
            await _userManager.CreateAsync(user2, "Customer123*");
            await _userManager.CreateAsync(user3, "Vaan123*");
            await _userManager.CreateAsync(user4, "Bash123*");
            await _userManager.AddToRoleAsync(user1, "Admin");
            await _userManager.AddToRoleAsync(user2, "Customer");
            await _userManager.AddToRoleAsync(user3, "Customer");
            await _userManager.AddToRoleAsync(user4, "Customer");

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
                9.8, EDepartment.Game, 89.99, new DateTime(2016,11,9), 10),

                new Game("Grand Theft Auto V",
                "The game is played from either a third-person or first-person"
                +"perspective and its world is navigated on foot or by vehicle. Players control the "
                +"three lead protagonists throughout single-player and switch between them both during "
                +"and outside missions.",
                "the single-player story follows three criminals and their efforts to commit "
                +"heists while under pressure from a government agency.", 10, EDepartment.Game, 59.99, new DateTime(2013,9,17), 2),

                new Game("Child of light",
                "The game's story takes place in the fictional land of Lemuria. "
                +"Aurora, a child who wakes up in Lemuria after freezing to death, "
                +"must bring back the sun, the moon and the stars held captive "
                +"by the Queen of the Night in order to return.",
                " Aurora, a young girl from 1895 Austria, awakens on the lost fairytale", 
                8.5, EDepartment.Game, 69.99, new DateTime(2014,4,29), 3),

                new Game("The Legend of Zelda: Breath of the Wild",
                "The Legend of Zelda: Breath of the Wild is the nineteenth "
                +"main installment of The Legend of Zelda series. It was "
                +"released simultaneously worldwide for the Wii U and "
                +"Nintendo Switch on March 3, 2017.",
                "The Legend of Zelda: Breath of the Wild was very highly received. "
                +"It currently has a 98/100 on Metacritic, making it the highest scoring game this decade",
                8.5, EDepartment.Game, 129.99, new DateTime(2014,4,29), 3),
            };

            games[0].ChangeImagePath("/images/ffxv.jpg");
            games[0].ChangeCoverImagePath("/images/coverffxv.jpg");
            games[1].ChangeImagePath("/images/gtav.jpg");
            games[1].ChangeCoverImagePath("/images/covergtav.png");
            games[2].ChangeImagePath("/images/childoflight.jpg");
            games[2].ChangeCoverImagePath("/images/coverchildoflight.jpg");
            games[3].ChangeImagePath("/images/zelda.jpg");
            games[3].ChangeCoverImagePath("/images/coverzelda.jpg");

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

            var userId1 = await _userManager.FindByNameAsync("Vaan");
            var userId2 = await _userManager.FindByNameAsync("BashRosenberg");

            var shoppingCarts = new ShoppingCart[] {
                new ShoppingCart(new Guid(userId1.Id)),
                new ShoppingCart(new Guid(userId2.Id))
            };

            shoppingCarts[0].AddItem(new CartItem(games[0], 1));
            shoppingCarts[0].AddItem(new CartItem(games[1], 1));
            shoppingCarts[0].AddItem(new CartItem(games[3], 1));

            shoppingCarts[1].AddItem(new CartItem(games[0], 1));
            shoppingCarts[1].AddItem(new CartItem(games[2], 1));
            shoppingCarts[1].AddItem(new CartItem(games[3], 1));

            foreach (ShoppingCart c in shoppingCarts)
            {
                context.ShoppingCarts.Add(c);
            }

            var paymentMethod1 = new PayPalPayment("ACD", DateTime.Now, DateTime.Now.AddDays(1),2000,2000,"Vaan", new Email(userId1.Email));
            var paymentMethod2 = new PayPalPayment("ABC", DateTime.Now, DateTime.Now.AddDays(1),2000,2000,"Bash", new Email(userId2.Email));

            var order1 = new Order(new Guid(userId1.Id), shoppingCarts[0], paymentMethod1);
            var order2 = new Order(new Guid(userId2.Id), shoppingCarts[1], paymentMethod2);

            order1.Deactivate();
            order2.Deactivate();

            context.Orders.Add(order1);
            context.Orders.Add(order2);

            var reviews = new Review[] {
                new Review(new Guid(userId1.Id), games[0].Id,5, "Nice and easy to play!"),
                new Review(new Guid(userId1.Id), games[1].Id,2, "Boring and boring..."),
                new Review(new Guid(userId1.Id), games[2].Id, 4 , "Really nice visuals"),
                new Review(new Guid(userId1.Id), games[3].Id,5, "Good history"),
                new Review(new Guid(userId2.Id), games[0].Id,4, "Soundtrack is awesome!"),
                new Review(new Guid(userId2.Id), games[1].Id,2, "Bad gameplay and worse graphics"),
                new Review(new Guid(userId2.Id), games[2].Id,2, "Don't recommend this"),
                new Review(new Guid(user2.Id), games[0].Id,5, "Really enjoyed"),
                new Review(new Guid(user2.Id), games[1].Id,1, "Can't play this any longer"),
                new Review(new Guid(user2.Id), games[2].Id,5, "Great and atmospheric"),
                new Review(new Guid(user2.Id), games[3].Id,3, "It's Ok!")
            };

            context.Reviews.AddRange(reviews);
            
            context.SaveChanges();
        }
    }
}