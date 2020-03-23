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
            if (context.Games.Any())
            {
                return;   // DB has been seeded
            }

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
                new Company("Square Enix",new DateTime(1975,9,22)),
                new Company("Rockstar Games",new DateTime(1998,12,1)),
                new Company("Ubisoft", new DateTime(1986,3,1) ),
                new Company("Rockstar North", new DateTime(1986,3,1)),
                new Company("Ubisoft Montreal", new DateTime(1986,3,1)),
                new Company("Eletronic Arts",new DateTime(1982,5,28)),
                new Company("Nintendo", new DateTime(1889,9,23)),
                new Company("Bethesda", new DateTime(1986,6,28)),
                new Company("Capcom", new DateTime(1983,6,11)),
                new Company("Bandai Namco",new DateTime(2006,3,31))
            };
            foreach (Company s in companies)
            {
                context.Companies.Add(s);
            }

            var platforms = new Platform[]
            {
                new Platform("Playstation 4"),
                new Platform("Xbox One"),
                new Platform("PC"),
                new Platform("Nintendo Switch")
            };
            foreach (Platform s in platforms)
            {
                context.Platforms.Add(s);
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
                EDepartment.Game, 89.99, new DateTime(2016,11,9), 10),

                new Game("Grand Theft Auto V",
                "The game is played from either a third-person or first-person"
                +"perspective and its world is navigated on foot or by vehicle. Players control the "
                +"three lead protagonists throughout single-player and switch between them both during "
                +"and outside missions.",
                "the single-player story follows three criminals and their efforts to commit "
                +"heists while under pressure from a government agency.", EDepartment.Game, 59.99, new DateTime(2013,9,17), 2),

                new Game("Child of light",
                "The game's story takes place in the fictional land of Lemuria. "
                +"Aurora, a child who wakes up in Lemuria after freezing to death, "
                +"must bring back the sun, the moon and the stars held captive "
                +"by the Queen of the Night in order to return.",
                " Aurora, a young girl from 1895 Austria, awakens on the lost fairytale", 
                EDepartment.Game, 69.99, new DateTime(2014,4,29), 3),

                new Game("The Legend of Zelda: Breath of the Wild",
                "The Legend of Zelda: Breath of the Wild is the nineteenth "
                +"main installment of The Legend of Zelda series. It was "
                +"released simultaneously worldwide for the Wii U and "
                +"Nintendo Switch on March 3, 2017.",
                "The Legend of Zelda: Breath of the Wild was very highly received. "
                +"It currently has a 98/100 on Metacritic, making it the highest scoring game this decade",
                EDepartment.Game, 129.99, new DateTime(2014,4,29), 3),
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
                new GamePlatform { Game = games[0], Platform = platforms[0] },
                new GamePlatform { Game = games[1], Platform = platforms[1] },
                new GamePlatform { Game = games[1], Platform = platforms[2] },
                new GamePlatform { Game = games[2], Platform = platforms[2] },
                new GamePlatform { Game = games[3], Platform = platforms[3] },
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

            List<Guid> gamesIds = context.Games.Select(x => x.Id).ToList();
            var go1 = new GameOverview(gamesIds[0], "<h1>Get ready to be at the centre of " +
                "the ultimate fantasy adventure, now for Windows PC.<br><br>Joined by your closest friends on the roadtrip of a " +
                "lifetime through a breathtaking open world, witness stunning landscapes and encounter larger-than-life beasts " +
                "on your journey to reclaim your homeland from an unimaginable foe.<br><br>In an action-packed battle system, channel " +
                "the power of your ancestors to warp effortlessly through the air in thrilling combat, and together with your comrades, " +
                "master the skills of weaponry, magic and team-based attacks.<br><br>Now realised with the power of cutting-edge technology " +
                "for Windows PCs, including support for high-resolution displays and HDR10, the beautiful and carefully-crafted experience of " +
                "FINAL FANTASY XV can be explored like never before.</h1>");

            var go2 = new GameOverview(gamesIds[1], "<span>The game is set in the fictional town of San Andreas which is based loosely " +
                "on generic southern California life. While much of the game&#8217;s scripted action takes place in the city, the world is " +
                "much larger than previous GTA offerings, and players can explore freely. The city lies in Blaine County, near another city, " +
                "Los Santos (both also fictional) and all areas can be accessed from the beginning of the game.</span><br><br><h3>Fully Operational" +
                " Towns!</h3><br><span>However, some gameplay needs to be unlocked in the open map area, before you can get the full flavour" +
                " of what the game has to offer. But it is well worth exploring as you play, or in between the linear missions: Los Santos " +
                "boasts a fully operational golf course, tennis courts, you can go to the races &#8211; there is even a stock market that you" +
                " can watch for fluctuations. Movie theatres allow you to watch a movie if you want some downtime, or you help to mug (or save" +
                " from being mugged) an unsuspecting passer-by, you can collect vehicles, or even rob an armoured van &#8211; whatever you fancy" +
                " when the situation arises in the game!</span><br><br><span>The story is centred around the heist action and there are plenty of" +
                " shooting and driving scenarios to keep players engaged and interested. Players use melee attacks, explosions and firearms to" +
                " defeat their enemies, and can drive, swim, run and jump to move around the world. Exploring the wider world, you can even steal" +
                " planes and fly over the terrain to cut down travel times.</span><br><br><span>The game is very immersive, almost like an " +
                "interactive movie rather than a game, with the actions interspersed with plenty of driving conversations and connecting scenes" +
                " to watch while you wait for your next opportunity to shoot up a bank or commit a heist.</span><br><br>");

            var go3 = new GameOverview(gamesIds[2], "   <div>&#10;      <h1><font size=\"5\"><b>The Kingdom of Lemuria is in Despair!</b></font>" +
                "</h1><div><font size=\"5\"><b><br></b></font></div>&#10;      <p>The Black Queen has stolen the Sun, the Moon and the Stars. You " +
                "play as Aurora, a young princess with a pure heart whose soul is brought to the kingdom of Lemuria. Embark on a quest to recapture " +
                "the three sources of light, defeat the Black Queen and restore the kingdom of Lemuria.</p><p><br></p>&#10;      <h2><font size=\"5\">" +
                "<b>An Adventure Waits!</b></font></h2><div><font size=\"5\"><b><br></b></font></div>&#10;      <p>Created by the talented " +
                "team of Ubisoft Montr&#233;al using the UbiArt Framework, Child of Light is an RPG inspired by fairy tales. Take an extraordinary" +
                " journey through the vast world of Lemuria and explore its mythical environments, interact with its inhabitants as you discover" +
                " new locations and their secrets.</p><p><br></p>&#10;      <h2><b><font size=\"5\">The Breathing World of Lemuria</font></b></h2>" +
                "<div><b><font size=\"5\"><br></font></b></div>&#10;      <p>Across your experience through Lemuria you will meet encounters" +
                " that you will remember, from friendly fairies and gnomes to vile wolves and dark dragons.</p><p><br></p>&#10;      " +
                "<h2><b><font size=\"5\">Fight Monsters and Evil Mythical Creatures</font></b></h2><div><b><font size=\"5\"><br></font></b>" +
                "</div>&#10;      <p>Aurora has the power to fight creatures from the dark and to restore the Stolen Lights. Fight alongside the " +
                "Igniculus in Active Time Battle Systems. Your firefly ally can be controlled by another player, so you can live this adventure" +
                " with your friends.</p>&#10;   </div>&#10;&#10;");

            var go4 = new GameOverview(gamesIds[3], "<h1><b>Step into a world of adventure</b></h1>&#10;&#9;        " +
                "&#10;&#9;        <div >&#10;&#9;            &#10;&#9;&#10;&#10;&#9;            &#10;&#9;            " +
                "<p>Forget everything you know about The Legend of Zelda games. Step into a world of discovery, " +
                "exploration, and adventure in The Legend of Zelda: Breath of the Wild, a boundary-breaking new game in the acclaimed series. " +
                "Travel across vast fields, through forests, and to mountain peaks as you discover what has become of the kingdom of Hyrule In" +
                " this stunning Open-Air Adventure. Now on Nintendo Switch, your journey is freer and more open than ever. Take your system" +
                " anywhere, and adventure as Link any way you like.</p>&#10;&#9;<p>Features:</p>&#10;&#9;<ul>&#10;&#9;<li><b>Explore the wilds" +
                " of Hyrule any way you like&#8212;anytime, anywhere!</b> <br> Climb up towers and mountain peaks in search of new destinations, " +
                "then set your own path to get there and plunge into the wilderness. Along the way, you'll battle towering enemies, hunt wild " +
                "beasts and gather ingredients for the food and elixirs you'll make to sustain you on your journey. With Nintendo Switch, you can" +
                " literally take your journey anywhere.</li>&#10;&#9;<li><b>More than 100 Shrines of Trials to discover and explore</b> <br>" +
                " Shrines dot the landscape, waiting to be discovered in any order you want. Search for them in various ways, and solve a variety " +
                "of puzzles inside. The tasks you must perform in each Shrine varies, and you'll never expect the challenges you'll face until you" +
                " enter. Some will involve realistic physics, and some will require you to harness the power of nature, including electricity, wind," +
                " fire, and more. Work your way through the traps and devices inside, utilizing your runes and think outside the box to earn " +
                "special items and other rewards that will help you on your adventure.</li>&#10;&#9;<li><b>Be prepared and properly equipped</b> " +
                "<br> With an entire world waiting to be explored, you'll need a variety of outfits and gear to reach every corner. You may need to" +
                " bundle up with warmer clothes or change into something better suited to the desert heat. Some clothing even has special effects " +
                "that, for example, can make you faster or stealthier.</li>&#10;&#9;<li><b>Battling enemies requires strategy</b> <br> The world is" +
                " inhabited with enemies of all shapes and sizes. Each one has its own attack method and weaponry, so you must think quickly and " +
                "develop the right strategies to defeat them.</li>&#10;&#9;<li><b>amiibo compatibility</b> <br> The Wolf Link amiibo from Twilight" +
                " Princess HD, the Zelda 30th Anniversary series amiibo, and The Legend of Zelda: Breath of the Wild series amiibo are all " +
                "compatible with this game. Tap the Wolf Link amiibo (sold separately) to make Wolf Link appear in the game. Wolf Link will" +
                " attack enemies on his own and help you find items you&#8217;re searching for. Tap a Zelda 30th Anniversary series amiibo to " +
                "receive helpful in-game items or even a treasure chest!</li>&#10;&#9;</ul></div>");

            context.GamesOverview.AddRange(new GameOverview[] { go1, go2, go3, go4 });

            context.SaveChanges();
        }
    }
}