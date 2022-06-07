using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.AspNetCore.Identity;

namespace API.Data
{
    public static class DbInitializer
    {
        public static async Task Initialize(StoreContext context, UserManager<User> userManager) {
           



            if(!userManager.Users.Any()) {
                var user = new User 
                {
                    UserName="Ratik",
                    Email="ratik@test.com"
                };
                await userManager.CreateAsync(user, "Pa$$w0rd");
                await userManager.AddToRoleAsync(user, "Member");

                var adminUser = new User 
                {
                    UserName="admin",
                    Email="admin@test.com"
                };
                await userManager.CreateAsync(adminUser, "Pa$$w0rd");
                await userManager.AddToRolesAsync(adminUser, new[]{"Member", "Admin"});
            }

            if(context.Products.Any()) return;
           
            var products = new List<Product> {
                new Product
                {
                    Name = "Matt Stafford Jersey",
                    Description =
                        "A playmaker who can make things happen in a hurry. Possesses a big arm and very strong hands, helping him make all kinds of throws easily (from over-the top strikes to sidearm rockets). Has good mobility. Displays strong instincts and field vision, as well as confidence and cool.",
                    Price = 20000,
                    Picture = "/images/products/rams.jpg",
                    Brand = "Los Angeles Rams",
                    Type = "Jerseys",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Los Angeles Rams T-Shirt",
                    Description =
                        "The Los Angeles Rams are a professional American football team based in the Los Angeles metropolitan area. The Rams compete in the National Football League (NFL) as a member of the National Football Conference (NFC) West division. The Rams play their home games at SoFi Stadium in Inglewood, which they share with the Los Angeles Chargers.",
                    Price = 10000,
                    Picture = "/images/tshirts/rams.jpg",
                    Brand = "Los Angeles Rams",
                    Type = "T-shirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Los Angeles Rams Sweatshirt",
                    Description =
                        "The Los Angeles Rams are a professional American football team based in the Los Angeles metropolitan area. The Rams compete in the National Football League (NFL) as a member of the National Football Conference (NFC) West division. The Rams play their home games at SoFi Stadium in Inglewood, which they share with the Los Angeles Chargers.",
                    Price = 15000,
                    Picture = "/images/sweatshirts/rams.jpg",
                    Brand = "Los Angeles Rams",
                    Type = "Sweatshirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Los Angeles Rams Hat",
                    Description =
                        "The Los Angeles Rams are a professional American football team based in the Los Angeles metropolitan area. The Rams compete in the National Football League (NFL) as a member of the National Football Conference (NFC) West division. The Rams play their home games at SoFi Stadium in Inglewood, which they share with the Los Angeles Chargers.",
                    Price = 07599,
                    Picture = "/images/hats/rams.jpg",
                    Brand = "Los Angeles Rams",
                    Type = "Hats",
                    QuantityInStock = 200
                },
                new Product
                {
                    Name = "Josh Allen Jersey",
                    Description = "Pretty mobile in the pocket for his size. He's ideally tall for the pocket, towering over the line. His long arms help him throw over defenders. Possesses big mitts for both holding onto and throwing the football. Can make some plays with his feet. Fairly quick-footed when getting out of trouble.",
                    Price = 15000,
                    Picture = "/images/products/bills.jpg",
                    Brand = "Buffalo Bills",
                    Type = "Jerseys",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Buffalo Bills T-Shirt",
                    Description = "The Buffalo Bills are a professional American football team based in the Buffalo metropolitan area. The Bills compete in the National Football League (NFL) as a member club of the league's American Football Conference (AFC) East division. The team plays its home games at Highmark Stadium in Orchard Park, New York.",
                    Price = 10000,
                    Picture = "/images/tshirts/bills.jpg",
                    Brand = "Buffalo Bills",
                    Type = "T-shirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Buffalo Bills Sweatshirt",
                    Description = "The Buffalo Bills are a professional American football team based in the Buffalo metropolitan area. The Bills compete in the National Football League (NFL) as a member club of the league's American Football Conference (AFC) East division. The team plays its home games at Highmark Stadium in Orchard Park, New York.",
                    Price = 14995,
                    Picture = "/images/sweatshirts/bills.jpg",
                    Brand = "Buffalo Bills",
                    Type = "Sweatshirts",
                    QuantityInStock = 75
                },
                new Product
                {
                    Name = "Buffalo Bills Hat",
                    Description = "The Buffalo Bills are a professional American football team based in the Buffalo metropolitan area. The Bills compete in the National Football League (NFL) as a member club of the league's American Football Conference (AFC) East division. The team plays its home games at Highmark Stadium in Orchard Park, New York.",
                    Price = 07599,
                    Picture = "/images/hats/bills.jpg",
                    Brand = "Buffalo Bills",
                    Type = "Hats",
                    QuantityInStock = 150
                },
                new Product
                {
                    Name = "TJ Watt Jersey",
                    Description =
                        "Super-productive as a source of sacks and terrorizes QB's. Has the frame needed to succeed as an NFL end, and enough speed to regularly make plays in space (and is a productive tackler). Also highly explosve as a leaper (making him an asset in pass coverage) and strong enough physically to execute as a pro pass rusher.",
                    Price = 18000,
                    Picture = "/images/products/steelers.jpg",
                    Brand = "Pittsburgh Steelers",
                    Type = "Jerseys",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Pittsburgh Steelers T-Shirt",
                    Description =
                        "The Pittsburgh Steelers are a professional American football team based in Pittsburgh. The Steelers compete in the National Football League (NFL) as a member club of the American Football Conference (AFC) North division. Founded in 1933, the Steelers are the seventh-oldest franchise in the NFL, and the oldest franchise in the AFC.",
                    Price = 10000,
                    Picture = "/images/tshirts/steelers.jpg",
                    Brand = "Pittsburgh Steelers",
                    Type = "T-shirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Pittsburgh Steelers Sweatshirt",
                    Description = "The Pittsburgh Steelers are a professional American football team based in Pittsburgh. The Steelers compete in the National Football League (NFL) as a member club of the American Football Conference (AFC) North division. Founded in 1933, the Steelers are the seventh-oldest franchise in the NFL, and the oldest franchise in the AFC.",
                    Price = 14995,
                    Picture = "/images/sweatshirts/steelers.jpg",
                    Brand = "Pittsburgh Steelers",
                    Type = "Sweatshirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Pittsburgh Steelers Hat",
                    Description = "The Pittsburgh Steelers are a professional American football team based in Pittsburgh. The Steelers compete in the National Football League (NFL) as a member club of the American Football Conference (AFC) North division. Founded in 1933, the Steelers are the seventh-oldest franchise in the NFL, and the oldest franchise in the AFC.",
                    Price = 07599,
                    Picture = "/images/hats/steelers.jpg",
                    Brand = "Pittsburgh Steelers",
                    Type = "Hats",
                    QuantityInStock = 84
                },
                new Product
                {
                    Name = "Jonathan Taylor Jersey",
                    Description =
                        "His ferocious college workload recalls the legendary power backs of the past, something seldom seen in the modern NFL game. The former high school track star smashed through the Big Ten leaving a trail of broken records, including consecutive 2,000-yard seasons and 50 rushing touchdowns in three years. Combines sprinter speed with endurance, vision and instincts as a turf-eating terror.",
                    Price = 30000,
                    Picture = "/images/products/colts.jpg",
                    Brand = "Indianapolis Colts",
                    Type = "Jerseys",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Indianapolis Colts T-Shirt",
                    Description =
                        "The Indianapolis Colts are a professional American football team based in Indianapolis. The Colts compete in the National Football League (NFL) as a member club of the league's American Football Conference (AFC) South division. Since the 2008 season, the Colts have played their games in Lucas Oil Stadium. Previously, the team had played for over two decades (1984–2007) at the RCA Dome. Since 1987, the Colts have served as the host team for the NFL Scouting Combine.",
                    Price = 15000,
                    Picture = "/images/tshirts/colts.jpg",
                    Brand = "Indianapolis Colts",
                    Type = "T-shirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Indianapolis Colts Sweatshirt",
                    Description = "The Indianapolis Colts are a professional American football team based in Indianapolis. The Colts compete in the National Football League (NFL) as a member club of the league's American Football Conference (AFC) South division. Since the 2008 season, the Colts have played their games in Lucas Oil Stadium. Previously, the team had played for over two decades (1984–2007) at the RCA Dome. Since 1987, the Colts have served as the host team for the NFL Scouting Combine.",
                    Price = 10000,
                    Picture = "/images/sweatshirts/colts.jpg",
                    Brand = "Indianapolis Colts",
                    Type = "Sweatshirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Indianapolis Colts Hat",
                    Description = "The Indianapolis Colts are a professional American football team based in Indianapolis. The Colts compete in the National Football League (NFL) as a member club of the league's American Football Conference (AFC) South division. Since the 2008 season, the Colts have played their games in Lucas Oil Stadium. Previously, the team had played for over two decades (1984–2007) at the RCA Dome. Since 1987, the Colts have served as the host team for the NFL Scouting Combine.",
                    Price = 07599,
                    Picture = "/images/hats/colts.jpg",
                    Brand = "Indianapolis Colts",
                    Type = "Hats",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Lamar Jackson Jersey",
                    Description =
                        "Shows a strong arm and a knack for hitting deep targets for big gains. Simply electric running with the ball in his hands, and he can dominate when he calls his own number. Long arms give him a nice reach advantage and extension.",
                    Price = 25000,
                    Picture = "/images/products/ravens.jpg",
                    Brand = "Baltimore Ravens",
                    Type = "Jerseys",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Baltimore Ravens T-Shirt",
                    Description =
                        "The Baltimore Ravens are a professional American football team based in Baltimore. The Ravens compete in the National Football League (NFL) as a member club of the American Football Conference (AFC) North division. The team plays its home games at M&T Bank Stadium and is headquartered in Owings Mills, Maryland.",
                    Price = 10000,
                    Picture = "/images/tshirts/ravens.jpg",
                    Brand = "Baltimore Ravens",
                    Type = "T-shirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Baltimore Ravens Sweatshirt",
                    Description = "The Baltimore Ravens are a professional American football team based in Baltimore. The Ravens compete in the National Football League (NFL) as a member club of the American Football Conference (AFC) North division. The team plays its home games at M&T Bank Stadium and is headquartered in Owings Mills, Maryland.",
                    Price = 10000,
                    Picture = "/images/sweatshirts/ravens.jpg",
                    Brand = "Baltimore Ravens",
                    Type = "Sweatshirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Baltimore Ravens Hat",
                    Description = "The Baltimore Ravens are a professional American football team based in Baltimore. The Ravens compete in the National Football League (NFL) as a member club of the American Football Conference (AFC) North division. The team plays its home games at M&T Bank Stadium and is headquartered in Owings Mills, Maryland.",
                    Price = 07599,
                    Picture = "/images/hats/ravens.jpg",
                    Brand = "Baltimore Ravens",
                    Type = "Hats",
                    QuantityInStock = 65
                },
                new Product
                {
                    Name = "JJ Watt Jersey",
                    Description =
                        "An all-round defensive dominator: elite as a sack artist, logs fantastic tackle totals, and gets his hands up in passing lanes. Freakishly athletic and exposive, yet also boasts superb size, intensity, and football smarts. Highly aware and a constant playmaker. A great ambassador for the game.",
                    Price = 12000,
                    Picture = "/images/products/texans.jpg",
                    Brand = "Houston Texans",
                    Type = "Jerseys",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Houston Texans T-Shirt",
                    Description = "The Houston Texans are a professional American football team based in Houston. The Texans compete in the National Football League (NFL) as a member club of the American Football Conference (AFC) South division, and play their home games at NRG Stadium.",
                    Price = 10000,
                    Picture = "/images/tshirts/texans.jpg",
                    Brand = "Houston Texans",
                    Type = "T-shirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Houston Texans Sweatshirt",
                   Description = "The Houston Texans are a professional American football team based in Houston. The Texans compete in the National Football League (NFL) as a member club of the American Football Conference (AFC) South division, and play their home games at NRG Stadium.",
                    Price = 10000,
                    Picture = "/images/sweatshirts/texans.jpg",
                    Brand = "Houston Texans",
                    Type = "Sweatshirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Houston Texans Hat",
                   Description = "The Houston Texans are a professional American football team based in Houston. The Texans compete in the National Football League (NFL) as a member club of the American Football Conference (AFC) South division, and play their home games at NRG Stadium.",
                    Price = 07599,
                    Picture = "/images/hats/texans.jpg",
                    Brand = "Houston Texans",
                    Type = "Hats",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Mac Jones Jersey",
                    Description =
                        "Mac Jones is the prototypical cerebral pocket-passing quarterback. His arm and mobility are average but he makes up for his deficiencies with his quick processing ability, great decision-making, and his elite anticipation.",
                    Price = 15000,
                    Picture = "/images/products/patriots.jpg",
                    Brand = "New England Patriots",
                    Type = "Jerseys",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "New England Patriots T-Shirt",
                    Description = "The New England Patriots are a professional American football team based in the Greater Boston area. They compete in the National Football League (NFL) as a member club of the league's American Football Conference (AFC) East division. The Patriots play home games at Gillette Stadium in Foxborough, Massachusetts, which is 22 miles (35 km) southwest of downtown Boston.",
                    Price = 10000,
                    Picture = "/images/tshirts/patriots.jpg",
                    Brand = "New England Patriots",
                    Type = "T-shirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "New England Patriots Sweatshirt",
                   Description = "The New England Patriots are a professional American football team based in the Greater Boston area. They compete in the National Football League (NFL) as a member club of the league's American Football Conference (AFC) East division. The Patriots play home games at Gillette Stadium in Foxborough, Massachusetts, which is 22 miles (35 km) southwest of downtown Boston.",
                    Price = 10000,
                    Picture = "/images/sweatshirts/patriots.jpg",
                    Brand = "New England Patriots",
                    Type = "Sweatshirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "New England Patriots Hat",
                   Description = "The New England Patriots are a professional American football team based in the Greater Boston area. They compete in the National Football League (NFL) as a member club of the league's American Football Conference (AFC) East division. The Patriots play home games at Gillette Stadium in Foxborough, Massachusetts, which is 22 miles (35 km) southwest of downtown Boston.",
                    Price = 07599,
                    Picture = "/images/hats/patriots.jpg",
                    Brand = "New England Patriots",
                    Type = "Hats",
                    QuantityInStock = 75
                },
                new Product
                {
                    Name = "Tua Tagovailoa Jersey",
                    Description =
                        "Is flush with the qualities required of a franchise-caliber quarterback, including command of the huddle, field vision and poise under pressure. Thrives when in motion with the athleticism to slide in the pocket, sprint out to scan for targets and extend plays. A left-hander, he has the arm strength to keep defenses honest and the extreme accuracy while throwing on the run.",
                    Price = 15000,
                    Picture = "/images/products/dolphins.jpg",
                    Brand = "Miami Dolphins",
                    Type = "Jerseys",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Miami Dolphins T-Shirt",
                    Description =
                        "The Miami Dolphins are a professional American football team based in the Miami metropolitan area. They compete in the National Football League (NFL) as a member team of the league's American Football Conference (AFC) East division. The team plays its home games at Hard Rock Stadium, located in the northern suburb of Miami Gardens, Florida.",
                    Price = 10000,
                    Picture = "/images/tshirts/dolphins.jpg",
                    Brand = "Miami Dolphins",
                    Type = "T-shirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Miami Dolphins Sweatshirt",
                   Description = 
                    "The Miami Dolphins are a professional American football team based in the Miami metropolitan area. They compete in the National Football League (NFL) as a member team of the league's American Football Conference (AFC) East division. The team plays its home games at Hard Rock Stadium, located in the northern suburb of Miami Gardens, Florida.",
                    Price = 10000,
                    Picture = "/images/sweatshirts/dolphins.jpg",
                    Brand = "Miami Dolphins",
                    Type = "Sweatshirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Miami Dolphins Hat",
                   Description = 
                    "The Miami Dolphins are a professional American football team based in the Miami metropolitan area. They compete in the National Football League (NFL) as a member team of the league's American Football Conference (AFC) East division. The team plays its home games at Hard Rock Stadium, located in the northern suburb of Miami Gardens, Florida.",
                    Price = 07599,
                    Picture = "/images/hats/dolphins.jpg",
                    Brand = "Miami Dolphins",
                    Type = "Hats",
                    QuantityInStock = 123
                },
                new Product
                {
                    Name = "Drew Brees Jersey",
                    Description =
                        "A truly prolific and consummate pro who took control of the game and was fearless with all of his passes. Was an exceptional touch passer with great timing and accuracy on short throws. Had outstanding pocket presence and moved and slid very well. Was also a clutch team leader and a winner. He was consistently productive. ",
                    Price = 15000,
                    Picture = "/images/products/saints.jpg",
                    Brand = "New Orleans Saints",
                    Type = "Jerseys",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "New Orleans Saints T-Shirt",
                    Description =
                        "The New Orleans Saints are a professional American football team based in New Orleans. The Saints compete in the National Football League (NFL) as a member of the league's National Football Conference (NFC) South division. Since 1975, the team plays its home games at Caesars Superdome[6] after utilizing Tulane Stadium during its first eight seasons.",
                    Price = 10000,
                    Picture = "/images/tshirts/saints.jpg",
                    Brand = "New Orleans Saints",
                    Type = "T-shirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "New Orleans Saints Sweatshirt",
                   Description = 
                   "The New Orleans Saints are a professional American football team based in New Orleans. The Saints compete in the National Football League (NFL) as a member of the league's National Football Conference (NFC) South division. Since 1975, the team plays its home games at Caesars Superdome[6] after utilizing Tulane Stadium during its first eight seasons.",
                    Price = 10000,
                    Picture = "/images/sweatshirts/saints.jpg",
                    Brand = "New Orleans Saints",
                    Type = "Sweatshirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "New Orleans Saints Hat",
                   Description = 
                   "The New Orleans Saints are a professional American football team based in New Orleans. The Saints compete in the National Football League (NFL) as a member of the league's National Football Conference (NFC) South division. Since 1975, the team plays its home games at Caesars Superdome[6] after utilizing Tulane Stadium during its first eight seasons.",
                    Price = 07599,
                    Picture = "/images/hats/saints.jpg",
                    Brand = "New Orleans Saints",
                    Type = "Hats",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Patrick Mahomes Jersey",
                    Description =
                        "Has the swagger and confidence teams love. Proven as a high-volume passer, and has shown he can really air it out on a regular basis. Does a nice job of limiting his interceptions too, and is accurate overall despite his high volume of attempts. Possesses superb short-area quickness for making plays with his feet.",
                    Price = 25000,
                    Picture = "/images/products/chiefs.jpg",
                    Brand = "Kansas City Chiefs",
                    Type = "Jerseys",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Kansas City Chiefs T-Shirt",
                    Description =
                        "The Kansas City Chiefs are a professional American football team based in Kansas City, Missouri. The Chiefs compete in the National Football League (NFL) as a member club of the league's American Football Conference (AFC) West division.",
                    Price = 10000,
                    Picture = "/images/tshirts/chiefs.jpg",
                    Brand = "Kansas City Chiefs",
                    Type = "T-shirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Kansas City Chiefs Sweatshirt",
                   Description = 
                   "The Kansas City Chiefs are a professional American football team based in Kansas City, Missouri. The Chiefs compete in the National Football League (NFL) as a member club of the league's American Football Conference (AFC) West division.",
                    Price = 10000,
                    Picture = "/images/sweatshirts/chiefs.jpg",
                    Brand = "Kansas City Chiefs",
                    Type = "Sweatshirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Kansas City Chiefs Hats",
                   Description = 
                   "The Kansas City Chiefs are a professional American football team based in Kansas City, Missouri. The Chiefs compete in the National Football League (NFL) as a member club of the league's American Football Conference (AFC) West division.",
                    Price = 07599,
                    Picture = "/images/hats/chiefs.jpg",
                    Brand = "Kansas City Chiefs",
                    Type = "Hats",
                    QuantityInStock = 90
                },
                new Product
                {
                    Name = "Derek Carr Jersey",
                    Description =
                        "Polished and well-rounded as a passer. Smart, high-character, and a leader. Has a good arm and the ability to make deep throws, mid-range passes with touch, and short routes on the run. Pretty athletic, with good scrambling instincts and the speed to make plays with his feet.",
                    Price = 15000,
                    Picture = "/images/products/raiders.jpg",
                    Brand = "Las Vegas Raiders",
                    Type = "Jerseys",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Las Vegas Raiders T-Shirt",
                    Description =
                        "The Las Vegas Raiders are a professional American football team based in the Las Vegas metropolitan area. The Raiders compete in the National Football League (NFL) as a member club of the league's American Football Conference (AFC) West division. The club plays its home games at Allegiant Stadium in Paradise, Nevada, and is headquartered in Henderson, Nevada.",
                    Price = 10000,
                    Picture = "/images/tshirts/raiders.jpg",
                    Brand = "Las Vegas Raiders",
                    Type = "T-shirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Las Vegas Raiders Sweatshirt",
                   Description = 
                    "The Las Vegas Raiders are a professional American football team based in the Las Vegas metropolitan area. The Raiders compete in the National Football League (NFL) as a member club of the league's American Football Conference (AFC) West division. The club plays its home games at Allegiant Stadium in Paradise, Nevada, and is headquartered in Henderson, Nevada.",
                    Price = 10000,
                    Picture = "/images/sweatshirts/raiders.jpg",
                    Brand = "Las Vegas Raiders",
                    Type = "Sweatshirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Las Vegas Raiders Hats",
                   Description = 
                    "The Las Vegas Raiders are a professional American football team based in the Las Vegas metropolitan area. The Raiders compete in the National Football League (NFL) as a member club of the league's American Football Conference (AFC) West division. The club plays its home games at Allegiant Stadium in Paradise, Nevada, and is headquartered in Henderson, Nevada.",
                    Price = 07599,
                    Picture = "/images/hats/raiders.jpg",
                    Brand = "Las Vegas Raiders",
                    Type = "Hats",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Justin Herbert Jersey",
                    Description =
                        "He brings good athleticism to the position, evidenced in his ability to escape danger and deliver the football with accuracy on the move. He demonstrates very good poise while under duress. He has very good pocket presence and uses his internal clock when the pocket has collapsed on him. He generally shows good footwork in his drop and his good base help him deliver the football with velocity and accuracy. ",
                    Price = 15000,
                    Picture = "/images/products/chargers.jpg",
                    Brand = "Los Angeles Chargers",
                    Type = "Jerseys",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Los Angeles Chargers T-Shirt",
                    Description =
                        "The Los Angeles Chargers are a professional American football team based in the Los Angeles metropolitan area. The Chargers compete in the National Football League (NFL) as a member of the American Football Conference (AFC) West division, and play their home games at SoFi Stadium in Inglewood, California, which they share with the Los Angeles Rams.",
                    Price = 10000,
                    Picture = "/images/tshirts/chargers.jpg",
                    Brand = "Los Angeles Chargers",
                    Type = "T-shirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Los Angeles Chargers Sweatshirt",
                   Description = 
                    "The Los Angeles Chargers are a professional American football team based in the Los Angeles metropolitan area. The Chargers compete in the National Football League (NFL) as a member of the American Football Conference (AFC) West division, and play their home games at SoFi Stadium in Inglewood, California, which they share with the Los Angeles Rams.",
                    Price = 10000,
                    Picture = "/images/sweatshirts/chargers.jpg",
                    Brand = "Los Angeles Chargers",
                    Type = "Sweatshirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Los Angeles Chargers Hat",
                   Description = 
                    "The Los Angeles Chargers are a professional American football team based in the Los Angeles metropolitan area. The Chargers compete in the National Football League (NFL) as a member of the American Football Conference (AFC) West division, and play their home games at SoFi Stadium in Inglewood, California, which they share with the Los Angeles Rams.",
                    Price = 07599,
                    Picture = "/images/hats/chargers.jpg",
                    Brand = "Los Angeles Chargers",
                    Type = "Hats",
                    QuantityInStock = 95
                },
                new Product
                {
                    Name = "Jerry Jeudy Jersey",
                    Description =
                        "A decorated college star, he owns elite tools and is the top playmaker of his draft class. Showcases superb route-running skills and body control; he can manipulate defenders to create space and elevate to high-point the ball. Is plenty fast and boasts the play speed and quickness to create separation and break long gains.",
                    Price = 15000,
                    Picture = "/images/products/broncos.jpg",
                    Brand = "Denver Broncos",
                    Type = "Jerseys",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Denver Broncos T-Shirt",
                    Description =
                        "The Denver Broncos are a professional American football franchise based in Denver. The Broncos compete in the National Football League (NFL) as a member club of the league's American Football Conference (AFC) West division. The team is headquartered in Dove Valley, Colorado and plays home games at Empower Field at Mile High in Denver, Colorado.",
                    Price = 10000,
                    Picture = "/images/tshirts/broncos.jpg",
                    Brand = "Denver Broncos",
                    Type = "T-shirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Denver Broncos Sweatshirt",
                   Description = 
                    "The Denver Broncos are a professional American football franchise based in Denver. The Broncos compete in the National Football League (NFL) as a member club of the league's American Football Conference (AFC) West division. The team is headquartered in Dove Valley, Colorado and plays home games at Empower Field at Mile High in Denver, Colorado.",
                    Price = 10000,
                    Picture = "/images/sweatshirts/broncos.jpg",
                    Brand = "Denver Broncos",
                    Type = "Sweatshirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Denver Broncos Hat",
                   Description = 
                    "The Denver Broncos are a professional American football franchise based in Denver. The Broncos compete in the National Football League (NFL) as a member club of the league's American Football Conference (AFC) West division. The team is headquartered in Dove Valley, Colorado and plays home games at Empower Field at Mile High in Denver, Colorado.",
                    Price = 07599,
                    Picture = "/images/hats/broncos.jpg",
                    Brand = "Denver Broncos",
                    Type = "Hats",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Joe Burrow Jersey",
                    Description =
                        "The author of perhaps the greatest season ever by a college quarterback, he won a national title and the Heisman Trophy while throwing for 60 scores in his senior year. Exhibits premier leadership traits, pocket poise and savvy decision-making skills. Can fit accurate throws into tight windows. Has an instinctive feel for pressure but will stand in and take a hit. Is unafraid to tuck the ball and has sufficient speed to outrun linemen. Intelligent, he has shown progression in making downfield reads and in refining his deep ball touch with solid arm strength.",
                    Price = 18000,
                    Picture = "/images/products/bengals.jpg",
                    Brand = "Cincinnati Benglas",
                    Type = "Jerseys",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Cincinnati Benglas T-Shirt",
                    Description =
                        "The Cincinnati Bengals are a professional American football team based in Cincinnati. The Bengals compete in the National Football League (NFL) as a member club of the league's American Football Conference (AFC) North division. The club's home games are held in downtown Cincinnati at Paul Brown Stadium.",
                    Price = 10000,
                    Picture = "/images/tshirts/bengals.jpg",
                    Brand = "Cincinnati Benglas",
                    Type = "T-shirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Cincinnati Benglas Sweatshirt",
                   Description = 
                     "The Cincinnati Bengals are a professional American football team based in Cincinnati. The Bengals compete in the National Football League (NFL) as a member club of the league's American Football Conference (AFC) North division. The club's home games are held in downtown Cincinnati at Paul Brown Stadium.",
                    Price = 10000,
                    Picture = "/images/sweatshirts/bengals.jpg",
                    Brand = "Cincinnati Benglas",
                    Type = "Sweatshirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Cincinnati Benglas Hat",
                   Description = 
                     "The Cincinnati Bengals are a professional American football team based in Cincinnati. The Bengals compete in the National Football League (NFL) as a member club of the league's American Football Conference (AFC) North division. The club's home games are held in downtown Cincinnati at Paul Brown Stadium.",
                    Price = 07599,
                    Picture = "/images/hats/bengals.jpg",
                    Brand = "Cincinnati Benglas",
                    Type = "Hats",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Myles Garrett Jersey",
                    Description =
                        "Brings the super-elite physical gifts NFL teams covet in a pass rusher: supreme quickness and explosiveness off the snap, fantastic fluidity and flexibility, plus superb foot-speed and above-average strength and length. Gets leverage on his blocker almost immediately, can change direction around the edge on a dime (often with a sweet spin move), and is very hard to lock up. Must be blocked hard from the snap, and battles to the whistle.",
                    Price = 18999,
                    Picture = "/images/products/browns.jpg",
                    Brand = "Cleveland Browns",
                    Type = "Jerseys",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Cleveland Browns T-Shirt",
                    Description =
                        "The Cleveland Browns are a professional American football team based in Cleveland. Named after original coach and co-founder Paul Brown, they compete in the National Football League (NFL) as a member club of the American Football Conference (AFC) North division. The Browns play their home games at FirstEnergy Stadium, which opened in 1999,[9][10] with administrative offices and training facilities in Berea, Ohio.",
                    Price = 10000,
                    Picture = "/images/tshirts/browns.jpg",
                    Brand = "Cleveland Browns",
                    Type = "T-shirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Cleveland Browns Sweatshirt",
                   Description = 
                     "The Cleveland Browns are a professional American football team based in Cleveland. Named after original coach and co-founder Paul Brown, they compete in the National Football League (NFL) as a member club of the American Football Conference (AFC) North division. The Browns play their home games at FirstEnergy Stadium, which opened in 1999,[9][10] with administrative offices and training facilities in Berea, Ohio.",
                    Price = 10000,
                    Picture = "/images/sweatshirts/browns.jpg",
                    Brand = "Cleveland Browns",
                    Type = "Sweatshirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Cleveland Browns Hat",
                   Description = 
                     "The Cleveland Browns are a professional American football team based in Cleveland. Named after original coach and co-founder Paul Brown, they compete in the National Football League (NFL) as a member club of the American Football Conference (AFC) North division. The Browns play their home games at FirstEnergy Stadium, which opened in 1999,[9][10] with administrative offices and training facilities in Berea, Ohio.",
                    Price = 07599,
                    Picture = "/images/hats/browns.jpg",
                    Brand = "Cleveland Browns",
                    Type = "Hats",
                    QuantityInStock = 43
                },
                new Product
                {
                    Name = "DeAndre Hopkins Jersey",
                    Description =
                        "Dominant in the possession game: uses his strong leaping ability, toughness, and crisp route-running to pile up receptions. Brings an array of nice fakes, and his long arms and large hands help him play even bigger than his solid size. Shows a nice burst after the catch. Able to be highly consistent and prolifically productive. Won't overwhelm many d-backs with his deep speed, and doesn't have very consistent hands.",
                    Price = 19999,
                    Picture = "/images/products/cardinals.jpg",
                    Brand = "Arizona Cardinals",
                    Type = "Jerseys",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Arizona Cardinals T-Shirt",
                    Description =
                        "The Arizona Cardinals are a professional American football team based in the Phoenix metropolitan area. The Cardinals compete in the National Football League (NFL) as a member of the National Football Conference (NFC) West division, and play their home games at State Farm Stadium in the northwestern suburb of Glendale.",
                    Price = 10000,
                    Picture = "/images/tshirts/cardinals.jpg",
                    Brand = "Arizona Cardinals",
                    Type = "T-shirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Arizona Cardinals Sweatshirt",
                   Description = 
                     "The Arizona Cardinals are a professional American football team based in the Phoenix metropolitan area. The Cardinals compete in the National Football League (NFL) as a member of the National Football Conference (NFC) West division, and play their home games at State Farm Stadium in the northwestern suburb of Glendale.",
                    Price = 10000,
                    Picture = "/images/sweatshirts/cardinals.jpg",
                    Brand = "Arizona Cardinals",
                    Type = "Sweatshirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Arizona Cardinals Hat",
                   Description = 
                     "The Arizona Cardinals are a professional American football team based in the Phoenix metropolitan area. The Cardinals compete in the National Football League (NFL) as a member of the National Football Conference (NFC) West division, and play their home games at State Farm Stadium in the northwestern suburb of Glendale.",
                    Price = 07599,
                    Picture = "/images/hats/cardinals.jpg",
                    Brand = "Arizona Cardinals",
                    Type = "Hats",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "George Kittle Jersey",
                    Description = "A highly productive tight end with superior blocking and receiving skills, he is well-proportioned physically with the mass to manhandle defenders while still agile enough to run a full range of patterns and get downfield in a hurry. Is an enthusiastic and technically astute blocker with lineman-esque strength. Excels at finding seams in the defense and turning short completions into long gains.",
                    Price = 15000,
                    Picture = "/images/products/sanfran.jpg",
                    Brand = "San Fransisco 49ers",
                    Type = "Jerseys",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "San Fransisco 49ers T-Shirt",
                    Description =
                        "The San Francisco 49ers (also written as the San Francisco Forty Niners) are a professional American football team based in the San Francisco Bay Area. The 49ers compete in the National Football League (NFL) as a member of the league's National Football Conference (NFC) West division, and play their home games at Levi's Stadium in Santa Clara, California, located 38 miles (61 km) southeast of San Francisco. The team is named after the prospectors who arrived in Northern California in the 1849 Gold Rush.",
                    Price = 10000,
                    Picture = "/images/tshirts/49ers.jpg",
                    Brand = "San Fransisco 49ers",
                    Type = "T-shirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "San Fransisco 49ers Sweatshirt",
                   Description = 
                    "The San Francisco 49ers (also written as the San Francisco Forty Niners) are a professional American football team based in the San Francisco Bay Area. The 49ers compete in the National Football League (NFL) as a member of the league's National Football Conference (NFC) West division, and play their home games at Levi's Stadium in Santa Clara, California, located 38 miles (61 km) southeast of San Francisco. The team is named after the prospectors who arrived in Northern California in the 1849 Gold Rush.",
                    Price = 10000,
                    Picture = "/images/sweatshirts/49ers.jpg",
                    Brand = "San Fransisco 49ers",
                    Type = "Sweatshirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "San Fransisco 49ers Hat",
                   Description = 
                    "The San Francisco 49ers (also written as the San Francisco Forty Niners) are a professional American football team based in the San Francisco Bay Area. The 49ers compete in the National Football League (NFL) as a member of the league's National Football Conference (NFC) West division, and play their home games at Levi's Stadium in Santa Clara, California, located 38 miles (61 km) southeast of San Francisco. The team is named after the prospectors who arrived in Northern California in the 1849 Gold Rush.",
                    Price = 07599,
                    Picture = "/images/hats/49ers.jpg",
                    Brand = "San Fransisco 49ers",
                    Type = "Hats",
                    QuantityInStock = 120
                },
                new Product
                {
                    Name = "Russell Wilson Jersey",
                    Description =
                        "A confident, gutsy leader. An exceptional athlete with very good speed and uncommonly large hands. Uses those mitts to zip mid-range passes accurately to his receivers. Exceptional when plays break down, as he has superb mobility as a scrambler in the open field and can make big plays on the run.",
                    Price = 18000,
                    Picture = "/images/products/seahawks.jpg",
                    Brand = "Seattle Seahawks",
                    Type = "Jerseys",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Seattle Seahawks T-Shirt",
                    Description =
                        "The Seattle Seahawks are a professional American football team based in Seattle. The Seahawks compete in the National Football League (NFL) as a member club of the league's National Football Conference (NFC) West, which they joined in 2002. The club entered the NFL as an expansion team in 1976. From 1977 to 2001, Seattle was assigned to the American Football Conference (AFC) West. They have played their home games at Lumen Field in Seattle's SoDo neighborhood since 2002, having previously played home games in the Kingdome (1976–1999) and Husky Stadium (1994 and 2000–2001).[a] The Seahawks are currently coached by Pete Carroll.",
                    Price = 10000,
                    Picture = "/images/tshirts/seahawks.jpg",
                    Brand = "Seattle Seahawks",
                    Type = "T-shirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Seattle Seahawks Sweatshirt",
                   Description = 
                   "The Seattle Seahawks are a professional American football team based in Seattle. The Seahawks compete in the National Football League (NFL) as a member club of the league's National Football Conference (NFC) West, which they joined in 2002. The club entered the NFL as an expansion team in 1976. From 1977 to 2001, Seattle was assigned to the American Football Conference (AFC) West. They have played their home games at Lumen Field in Seattle's SoDo neighborhood since 2002, having previously played home games in the Kingdome (1976–1999) and Husky Stadium (1994 and 2000–2001).[a] The Seahawks are currently coached by Pete Carroll.",
                    Price = 10000,
                    Picture = "/images/sweatshirts/seahawks.jpg",
                    Brand = "Seattle Seahawks",
                    Type = "Sweatshirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Seattle Seahawks Hat",
                   Description = 
                   "The Seattle Seahawks are a professional American football team based in Seattle. The Seahawks compete in the National Football League (NFL) as a member club of the league's National Football Conference (NFC) West, which they joined in 2002. The club entered the NFL as an expansion team in 1976. From 1977 to 2001, Seattle was assigned to the American Football Conference (AFC) West. They have played their home games at Lumen Field in Seattle's SoDo neighborhood since 2002, having previously played home games in the Kingdome (1976–1999) and Husky Stadium (1994 and 2000–2001).[a] The Seahawks are currently coached by Pete Carroll.",
                    Price = 07599,
                    Picture = "/images/hats/seahawks.jpg",
                    Brand = "Seattle Seahawks",
                    Type = "Hats",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Trevor Lawrence Jersey",
                    Description =
                        "Lawrence is a pro-ready passer. His accuracy is exceptional, and he can consistently place the ball perfectly downfield. Lawrence can fit passes into windows the size of a shoe box, and he can drop in strikes past defensive backs.",
                    Price = 18000,
                    Picture = "/images/products/jaguars.jpg",
                    Brand = "Jacksonville Jaguars",
                    Type = "Jerseys",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Jacksonville Jaguars T-Shirt",
                    Description =
                        "The Jacksonville Jaguars are a professional American football team based in Jacksonville, Florida. The Jaguars compete in the National Football League (NFL) as a member club of the American Football Conference (AFC) South division. The team plays its home games at TIAA Bank Field. Founded alongside the Carolina Panthers in 1995 as an expansion team, the Jaguars originally competed in the AFC Central until they were realigned to the AFC South in 2002. The franchise is owned by Shahid Khan, who purchased the team from original majority owner Wayne Weaver in 2012.",
                    Price = 10000,
                    Picture = "/images/tshirts/jaguars.jpg",
                    Brand = "Jacksonville Jaguars",
                    Type = "T-shirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Jacksonville Jaguars Sweatshirt",
                   Description = 
                    "The Jacksonville Jaguars are a professional American football team based in Jacksonville, Florida. The Jaguars compete in the National Football League (NFL) as a member club of the American Football Conference (AFC) South division. The team plays its home games at TIAA Bank Field. Founded alongside the Carolina Panthers in 1995 as an expansion team, the Jaguars originally competed in the AFC Central until they were realigned to the AFC South in 2002. The franchise is owned by Shahid Khan, who purchased the team from original majority owner Wayne Weaver in 2012.",
                    Price = 10000,
                    Picture = "/images/sweatshirts/jaguars.jpg",
                    Brand = "Jacksonville Jaguars",
                    Type = "Sweatshirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Jacksonville Jaguars Hat",
                   Description = 
                    "The Jacksonville Jaguars are a professional American football team based in Jacksonville, Florida. The Jaguars compete in the National Football League (NFL) as a member club of the American Football Conference (AFC) South division. The team plays its home games at TIAA Bank Field. Founded alongside the Carolina Panthers in 1995 as an expansion team, the Jaguars originally competed in the AFC Central until they were realigned to the AFC South in 2002. The franchise is owned by Shahid Khan, who purchased the team from original majority owner Wayne Weaver in 2012.",
                    Price = 07599,
                    Picture = "/images/hats/jaguars.jpg",
                    Brand = "Jacksonville Jaguars",
                    Type = "Hats",
                    QuantityInStock = 80
                },
                new Product
                {
                    Name = "Derrick Henry Jersey",
                    Description =
                        "Truly jumbo-sized for the NFL running back position, and has enough speed to handle the featured role. Uncommonly strong and physical (even for his size), and capable of running through and over second-level defenders. Shows superb field vision and patience, following his blocking then rumbling downhill. A regular factor for big yardage and a true asset at the goal-line. Has immense upside as a blocker.",
                    Price = 18000,
                    Picture = "/images/products/titans.jpg",
                    Brand = "Tennessee Titans",
                    Type = "Jerseys",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Tennessee Titans T-Shirt",
                    Description =
                        "The Tennessee Titans are a professional American football team based in Nashville, Tennessee. The Titans compete in the National Football League (NFL) as a member club of the American Football Conference (AFC) South division, and play their home games at Nissan Stadium.",
                    Price = 10000,
                    Picture = "/images/tshirts/titans.jpg",
                    Brand = "Tennessee Titans",
                    Type = "T-shirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Tennessee Titans Sweatshirt",
                   Description = 
                     "The Tennessee Titans are a professional American football team based in Nashville, Tennessee. The Titans compete in the National Football League (NFL) as a member club of the American Football Conference (AFC) South division, and play their home games at Nissan Stadium.",
                    Price = 10000,
                    Picture = "/images/sweatshirts/titans.jpg",
                    Brand = "Tennessee Titans",
                    Type = "Sweatshirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Tennessee Titans Hat",
                   Description = 
                     "The Tennessee Titans are a professional American football team based in Nashville, Tennessee. The Titans compete in the National Football League (NFL) as a member club of the American Football Conference (AFC) South division, and play their home games at Nissan Stadium.",
                    Price = 07599,
                    Picture = "/images/hats/titans.jpg",
                    Brand = "Tennessee Titans",
                    Type = "Hats",
                    QuantityInStock = 32
                },
                new Product
                {
                    Name = "Tom Brady Jersey",
                    Description =
                        "The definition of an elite quarterback: a leader, a winner, and a true clutch performer. Always well-prepared, has great vision of the field, and unequalled timing. Throws an effortless deep ball. Mobile enough to evade sacks. Never gives up, and is a good leader on and off the field.",
                    Price = 18000,
                    Picture = "/images/products/bucs.jpg",
                    Brand = "Tampa Bay Buccaneers",
                    Type = "Jerseys",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Tampa Bay Buccaneers T-Shirt",
                    Description =
                        "The Tampa Bay Buccaneers are a professional American football team based in Tampa, Florida. The Buccaneers compete in the National Football League (NFL) as a member club of the league's National Football Conference (NFC) South division.",
                    Price = 10000,
                    Picture = "/images/tshirts/bucs.jpg",
                    Brand = "Tampa Bay Buccaneers",
                    Type = "T-shirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Tampa Bay Buccaneers Sweatshirt",
                   Description = 
                     "The Tampa Bay Buccaneers are a professional American football team based in Tampa, Florida. The Buccaneers compete in the National Football League (NFL) as a member club of the league's National Football Conference (NFC) South division.",
                    Price = 10000,
                    Picture = "/images/sweatshirts/bucs.jpg",
                    Brand = "Tampa Bay Buccaneers",
                    Type = "Sweatshirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Tampa Bay Buccaneers Hat",
                   Description = 
                     "The Tampa Bay Buccaneers are a professional American football team based in Tampa, Florida. The Buccaneers compete in the National Football League (NFL) as a member club of the league's National Football Conference (NFC) South division.",
                    Price = 07599,
                    Picture = "/images/hats/bucs.jpg",
                    Brand = "Tampa Bay Buccaneers",
                    Type = "Hats",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Aaron Rodgers Jersey",
                    Description =
                        "He possesses outstanding arm strength. Ability to make necessary throws in the NFL. Has the ability to fit the ball in tight spots and has great fundamentals and mechanics. He can lay the ball between linebackers and safeties in coverage with the ability to throw accurate deep passes.",
                    Price = 18000,
                    Picture = "/images/products/packers.jpg",
                    Brand = "Green Bay Packers",
                    Type = "Jerseys",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Green Bay Packers T-Shirt",
                    Description =
                        "The Green Bay Packers are a professional American football team based in Green Bay, Wisconsin. The Packers compete in the National Football League (NFL) as a member club of the National Football Conference (NFC) North division. It is the third-oldest franchise in the NFL, dating back to 1919, and is the only non-profit, community-owned major league professional sports team based in the United States.",
                    Price = 10000,
                    Picture = "/images/tshirts/packers.jpg",
                    Brand = "Green Bay Packers",
                    Type = "T-shirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Green Bay Packers Sweatshirt",
                   Description = 
                      "The Green Bay Packers are a professional American football team based in Green Bay, Wisconsin. The Packers compete in the National Football League (NFL) as a member club of the National Football Conference (NFC) North division. It is the third-oldest franchise in the NFL, dating back to 1919, and is the only non-profit, community-owned major league professional sports team based in the United States.",
                    Price = 10000,
                    Picture = "/images/sweatshirts/packers.jpg",
                    Brand = "Green Bay Packers",
                    Type = "Sweatshirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Green Bay Packers Hat",
                   Description = 
                      "The Green Bay Packers are a professional American football team based in Green Bay, Wisconsin. The Packers compete in the National Football League (NFL) as a member club of the National Football Conference (NFC) North division. It is the third-oldest franchise in the NFL, dating back to 1919, and is the only non-profit, community-owned major league professional sports team based in the United States.",
                    Price = 07599,
                    Picture = "/images/hats/packers.jpg",
                    Brand = "Green Bay Packers",
                    Type = "Hats",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Kyle Pitts Jersey",
                    Description =
                        "While the player comparison for the purposes of this scouting report is Darren Waller, Pitts may have the traits and talent to create mismatches similar to those created by Calvin Johnson and Tyreek Hill. His rare blend of size, athleticism and ball skills are reminiscent of Megatron’s. His ability as a pass-catching tight end could force defenses in his division to alter the way they construct their roster. He’s a tough matchup for most linebackers and too big for most cornerbacks. He offers offensive coordinators the ability to align him all over the field and, like Waller, can become a highly targeted, highly productive pass catcher from the tight end position.",
                    Price = 18000,
                    Picture = "/images/products/falcons.jpg",
                    Brand = "Atlanta Falcons",
                    Type = "Jerseys",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Atlanta Falcons T-Shirt",
                    Description =
                        "The Atlanta Falcons are a professional American football team based in Atlanta. The Falcons compete in the National Football League (NFL) as a member club of the league's National Football Conference (NFC) South division.",
                    Price = 10000,
                    Picture = "/images/tshirts/falcons.jpg",
                    Brand = "Atlanta Falcons",
                    Type = "T-shirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Atlanta Falcons Sweatshirt",
                   Description = 
                       "The Atlanta Falcons are a professional American football team based in Atlanta. The Falcons compete in the National Football League (NFL) as a member club of the league's National Football Conference (NFC) South division.",
                    Price = 10000,
                    Picture = "/images/sweatshirts/falcons.jpg",
                    Brand = "Atlanta Falcons",
                    Type = "Sweatshirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Atlanta Falcons Hat",
                   Description = 
                       "The Atlanta Falcons are a professional American football team based in Atlanta. The Falcons compete in the National Football League (NFL) as a member club of the league's National Football Conference (NFC) South division.",
                    Price = 07599,
                    Picture = "/images/hats/falcons.jpg",
                    Brand = "Atlanta Falcons",
                    Type = "Hats",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Penei Sewell",
                    Description =
                        "Rare-breed tackle with good size and the elite foot quickness to make the most challenging move blocks the game has to offer. He’s an explosive athlete who is better at moving forward than backward at this point, and his tape shows an ability to single-handedly spring touchdown runs (both long and short) with wow blocks. He possesses average balance and core strength, but he has trouble protecting his edges when rushers get into his frame. Improvements in technique and strength should be expected, though. While block-finishing needs to be upgraded, his initial snap quickness gives him the ability to take early leads in positioning as both a run and pass blocker.",
                    Price = 18000,
                    Picture = "/images/products/lions.jpg",
                    Brand = "Detroit Lions",
                    Type = "Jerseys",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Detroit Lions T-Shirt",
                    Description =
                        "The Detroit Lions are a professional American football team based in Detroit. The Lions compete in the National Football League (NFL) as a member of the National Football Conference (NFC) North Division. The team plays its home games at Ford Field in Downtown Detroit.",
                    Price = 10000,
                    Picture = "/images/tshirts/lions.jpg",
                    Brand = "Detroit Lions",
                    Type = "T-shirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Detroit Lions Sweatshirt",
                   Description = 
                        "The Detroit Lions are a professional American football team based in Detroit. The Lions compete in the National Football League (NFL) as a member of the National Football Conference (NFC) North Division. The team plays its home games at Ford Field in Downtown Detroit.",
                    Price = 10000,
                    Picture = "/images/sweatshirts/lions.jpg",
                    Brand = "Detroit Lions",
                    Type = "Sweatshirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Detroit Lions Hat",
                   Description = 
                        "The Detroit Lions are a professional American football team based in Detroit. The Lions compete in the National Football League (NFL) as a member of the National Football Conference (NFC) North Division. The team plays its home games at Ford Field in Downtown Detroit.",
                    Price = 07599,
                    Picture = "/images/hats/lions.jpg",
                    Brand = "Detroit Lions",
                    Type = "Hats",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Justin Fields Jersey",
                    Description =
                        "Like Dak Prescott before him, Fields enters the league with dual-threat capabilities but is more of a pocket passer with the ability to extend plays or win with his legs when needed. He was up and down in 2020, but a bounce-back performance against Clemson -- including an impressive second half after suffering an injury -- said a lot about his toughness and leadership. He sees the field fairly well inside the Buckeyes’ quarterback-friendly offense but needs to become a full-field reader and prevent his eyes from becoming transfixed on primary targets. He sticks open throws with accuracy and velocity thanks to a sturdy platform and good drive mechanics. He’s also comfortable throwing into intermediate holes of a zone. A slower operation time and a lack of a twitchy trigger will require him to work with better anticipation and pressure recognition pre- and post-snap. ",
                    Price = 18000,
                    Picture = "/images/products/bears.jpg",
                    Brand = "Chicago Bears",
                    Type = "Jerseys",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Chicago Bears T-Shirt",
                    Description =
                        "The Chicago Bears are a professional American football team based in Chicago. The Bears compete in the National Football League (NFL) as a member club of the league's National Football Conference (NFC) North division. The Bears have won nine NFL Championships, including one Super Bowl, and hold the NFL record for the most enshrinees in the Pro Football Hall of Fame and the most retired jersey numbers. The Bears have also recorded more victories than any other NFL franchise.",
                    Price = 10000,
                    Picture = "/images/tshirts/bears.jpg",
                    Brand = "Chicago Bears",
                    Type = "T-shirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Chicago Bears Sweatshirt",
                   Description = 
                        "The Chicago Bears are a professional American football team based in Chicago. The Bears compete in the National Football League (NFL) as a member club of the league's National Football Conference (NFC) North division. The Bears have won nine NFL Championships, including one Super Bowl, and hold the NFL record for the most enshrinees in the Pro Football Hall of Fame and the most retired jersey numbers. The Bears have also recorded more victories than any other NFL franchise.",
                    Price = 10000,
                    Picture = "/images/sweatshirts/bears.jpg",
                    Brand = "Chicago Bears",
                    Type = "Sweatshirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Chicago Bears Hat",
                   Description = 
                        "The Chicago Bears are a professional American football team based in Chicago. The Bears compete in the National Football League (NFL) as a member club of the league's National Football Conference (NFC) North division. The Bears have won nine NFL Championships, including one Super Bowl, and hold the NFL record for the most enshrinees in the Pro Football Hall of Fame and the most retired jersey numbers. The Bears have also recorded more victories than any other NFL franchise.",
                    Price = 07599,
                    Picture = "/images/hats/bears.jpg",
                    Brand = "Chicago Bears",
                    Type = "Hats",
                    QuantityInStock = 75
                },
                new Product
                {
                    Name = "Terry McLaurin Jersey",
                    Description =
                        "The ex-Ohio State Buckeye brings plenty of route-running savvy and top-end speed in a solid, pro-sized frame. His high football IQ shows in a nuanced ability to shift gears, throw defenders off his trail or create a cushion to get completions in the middle of the field. Catches the ball close to his body, wins a majority of contested throws and commands respect as a deep threat on go routes.",
                    Price = 18000,
                    Picture = "/images/products/washington.jpg",
                    Brand = "Washington Commanders",
                    Type = "Jerseys",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Washington Commanders T-Shirt",
                    Description =
                        "The Washington Commanders are a professional American football team based in the Washington metropolitan area. The Commanders compete in the National Football League (NFL) as a member club of the league's National Football Conference (NFC) East division. The team plays its home games at FedExField in Landover, Maryland; its headquarters and training facility are in Ashburn, Virginia.",
                    Price = 10000,
                    Picture = "/images/tshirts/washington.jpg",
                    Brand = "Washington Commanders",
                    Type = "T-shirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Washington Commanders Sweatshirt",
                   Description = 
                        "The Washington Commanders are a professional American football team based in the Washington metropolitan area. The Commanders compete in the National Football League (NFL) as a member club of the league's National Football Conference (NFC) East division. The team plays its home games at FedExField in Landover, Maryland; its headquarters and training facility are in Ashburn, Virginia.",
                    Price = 10000,
                    Picture = "/images/sweatshirts/washington.jpg",
                    Brand = "Washington Commanders",
                    Type = "Sweatshirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Washington Commanders Hat",
                   Description = 
                        "The Washington Commanders are a professional American football team based in the Washington metropolitan area. The Commanders compete in the National Football League (NFL) as a member club of the league's National Football Conference (NFC) East division. The team plays its home games at FedExField in Landover, Maryland; its headquarters and training facility are in Ashburn, Virginia.",
                    Price = 07599,
                    Picture = "/images/hats/washington.jpg",
                    Brand = "Washington Commanders",
                    Type = "Hats",
                    QuantityInStock = 89
                },
                new Product
                {
                    Name = "Christian McCaffery Jersey",
                    Description =
                        "A gifted multi-purpose player: downright explosive as a running back, return man, and receiver. Has supreme quickness and elite change-of-direction skills, and easily evades tackles. Fast, and pretty patient in general (helping him pile up chunk yards). Shows good ability to punch it in at the goal-line too.",
                    Price = 18000,
                    Picture = "/images/products/panthers.jpg",
                    Brand = "Carolina Panthers",
                    Type = "Jerseys",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Carolina Panthers T-Shirt",
                    Description =
                        "The Carolina Panthers are a professional American football team based in Charlotte, North Carolina. The Panthers compete in the National Football League (NFL), as a member club of the league's National Football Conference (NFC) South division. The team is headquartered in Bank of America Stadium in Uptown Charlotte; the stadium also serves as the team's home field.",
                    Price = 10000,
                    Picture = "/images/tshirts/panthers.jpg",
                    Brand = "Carolina Panthers",
                    Type = "T-shirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Carolina Panthers Sweatshirt",
                   Description = 
                        "The Carolina Panthers are a professional American football team based in Charlotte, North Carolina. The Panthers compete in the National Football League (NFL), as a member club of the league's National Football Conference (NFC) South division. The team is headquartered in Bank of America Stadium in Uptown Charlotte; the stadium also serves as the team's home field.",
                    Price = 10000,
                    Picture = "/images/sweatshirts/panthers.jpg",
                    Brand = "Carolina Panthers",
                    Type = "Sweatshirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Carolina Panthers Hat",
                   Description = 
                        "The Carolina Panthers are a professional American football team based in Charlotte, North Carolina. The Panthers compete in the National Football League (NFL), as a member club of the league's National Football Conference (NFC) South division. The team is headquartered in Bank of America Stadium in Uptown Charlotte; the stadium also serves as the team's home field.",
                    Price = 07599,
                    Picture = "/images/hats/panthers.jpg",
                    Brand = "Carolina Panthers",
                    Type = "Hats",
                    QuantityInStock = 25
                },
                new Product
                {
                    Name = "Jalen Hurts Jersey",
                    Description =
                        "A highly accomplished, winning quarterback exalted for his toughness and leadership qualities, his college resume includes playoff experience with two major programs and elite dual-threat production as a mobile, pocket passer with running back attributes. Is well versed in the run/pass option; he can extend plays with his legs and is adept at making off-balance throws. Ultracompetitive, he thrives under pressure and covets the big stage.",
                    Price = 18000,
                    Picture = "/images/products/eagles.jpg",
                    Brand = "Philadelphia Eagles",
                    Type = "Jerseys",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Philadelphia Eagles T-Shirt",
                    Description =
                        "The Philadelphia Eagles are a professional American football team based in Philadelphia. The Eagles compete in the National Football League (NFL) as a member club of the league's National Football Conference (NFC) East division. The team plays its home games at Lincoln Financial Field.",
                    Price = 10000,
                    Picture = "/images/tshirts/eagles.jpg",
                    Brand = "Philadelphia Eagles",
                    Type = "T-shirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Philadelphia Eagles Sweatshirt",
                   Description = 
                        "The Philadelphia Eagles are a professional American football team based in Philadelphia. The Eagles compete in the National Football League (NFL) as a member club of the league's National Football Conference (NFC) East division. The team plays its home games at Lincoln Financial Field.",
                    Price = 10000,
                    Picture = "/images/sweatshirts/eagles.jpg",
                    Brand = "Philadelphia Eagles",
                    Type = "Sweatshirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Philadelphia Eagles Hat",
                   Description = 
                        "The Philadelphia Eagles are a professional American football team based in Philadelphia. The Eagles compete in the National Football League (NFL) as a member club of the league's National Football Conference (NFC) East division. The team plays its home games at Lincoln Financial Field.",
                    Price = 07599,
                    Picture = "/images/hats/eagles.jpg",
                    Brand = "Philadelphia Eagles",
                    Type = "Hats",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Saquon Barkley Jersey",
                    Description =
                        "A productive ball-carrier who can be a go-to guy. Consistently posts very good yardage. Has shown he can regularly get into the end zone too. Provides added value as a kick returner. Does a great job on kick returns, piling up yards. He's uncommonly polished as a receiver out of the backfield, and can be used as another wideout. Powerfully-built in height and weight to run the ball inside. His foot-speed is above-average for a pro running back.",
                    Price = 18000,
                    Picture = "/images/products/giants.jpg",
                    Brand = "New York Giants",
                    Type = "Jerseys",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "New York Giants T-Shirt",
                    Description =
                        "The New York Giants are a professional American football team based in the New York metropolitan area. The Giants compete in the National Football League (NFL) as a member club of the league's National Football Conference (NFC) East division. The team plays its home games at MetLife Stadium (shared with the New York Jets) in East Rutherford, New Jersey, 5 miles (8 km) west of New York City. The Giants hold their summer training camp at the Quest Diagnostics Training Center at the Meadowlands Sports Complex.",
                    Price = 10000,
                    Picture = "/images/tshirts/giants.jpg",
                    Brand = "New York Giants",
                    Type = "T-shirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "New York Giants Sweatshirt",
                   Description = 
                        "The New York Giants are a professional American football team based in the New York metropolitan area. The Giants compete in the National Football League (NFL) as a member club of the league's National Football Conference (NFC) East division. The team plays its home games at MetLife Stadium (shared with the New York Jets) in East Rutherford, New Jersey, 5 miles (8 km) west of New York City. The Giants hold their summer training camp at the Quest Diagnostics Training Center at the Meadowlands Sports Complex.",
                    Price = 10000,
                    Picture = "/images/sweatshirts/giants.jpg",
                    Brand = "New York Giants",
                    Type = "Sweatshirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "New York Giants Hat",
                   Description = 
                        "The New York Giants are a professional American football team based in the New York metropolitan area. The Giants compete in the National Football League (NFL) as a member club of the league's National Football Conference (NFC) East division. The team plays its home games at MetLife Stadium (shared with the New York Jets) in East Rutherford, New Jersey, 5 miles (8 km) west of New York City. The Giants hold their summer training camp at the Quest Diagnostics Training Center at the Meadowlands Sports Complex.",
                    Price = 07599,
                    Picture = "/images/hats/giants.jpg",
                    Brand = "New York Giants",
                    Type = "Hats",
                    QuantityInStock = 40
                },
                new Product
                {
                    Name = "Justin Jefferson Jersey",
                    Description =
                        "A shrewd and instinctive operator, he thrived in a feature role in college showing the clutch traits and flexibility to be a difference maker. Size, play strength and clock times work in his favor on a variety of routes, both from the slot and on the outside. Combines change of speeds with body control to win separation and closes the deal with quick, strong hands at the point of the catch.",
                    Price = 18000,
                    Picture = "/images/products/vikings.jpg",
                    Brand = "Minnesota Vikings",
                    Type = "Jerseys",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Minnesota Vikings T-Shirt",
                    Description =
                        "The Minnesota Vikings are a professional American football team based in Minneapolis. They compete in the National Football League (NFL) as a member club of the National Football Conference (NFC) North division.[5] Founded in 1960 as an expansion team, the team began play the following year. They are named after the Vikings of ancient Scandinavia, reflecting the prominent Scandinavian American culture of Minnesota.",
                    Price = 10000,
                    Picture = "/images/tshirts/vikings.jpg",
                    Brand = "Minnesota Vikings",
                    Type = "T-shirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Minnesota Vikings Sweatshirt",
                   Description = 
                        "The Minnesota Vikings are a professional American football team based in Minneapolis. They compete in the National Football League (NFL) as a member club of the National Football Conference (NFC) North division.[5] Founded in 1960 as an expansion team, the team began play the following year. They are named after the Vikings of ancient Scandinavia, reflecting the prominent Scandinavian American culture of Minnesota.",
                    Price = 10000,
                    Picture = "/images/sweatshirts/vikings.jpg",
                    Brand = "Minnesota Vikings",
                    Type = "Sweatshirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Minnesota Vikings Hat",
                   Description = 
                        "The Minnesota Vikings are a professional American football team based in Minneapolis. They compete in the National Football League (NFL) as a member club of the National Football Conference (NFC) North division.[5] Founded in 1960 as an expansion team, the team began play the following year. They are named after the Vikings of ancient Scandinavia, reflecting the prominent Scandinavian American culture of Minnesota.",
                    Price = 07599,
                    Picture = "/images/hats/vikings.jpg",
                    Brand = "Minnesota Vikings",
                    Type = "Hats",
                    QuantityInStock = 63
                },
                new Product
                {
                    Name = "Dak Prescott Jersey",
                    Description =
                        "Brings a nice combination of athleticism and accuracy to the pocket. Plays bigger than his size thanks to an overhand delivery. Decides quickly, and gets rid of the ball in a hurry (helping him avoid both sacks and pickoffs, since he doesn't telegraph many passes). Can also regularly make plays with his feet.",
                    Price = 18000,
                    Picture = "/images/products/cowboys.jpg",
                    Brand = "Dallas Cowboys",
                    Type = "Jerseys",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Dallas Cowboys T-Shirt",
                    Description =
                        "The Dallas Cowboys are a professional American football team based in the Dallas–Fort Worth metroplex. The Cowboys compete in the National Football League (NFL) as a member club of the league's National Football Conference (NFC) East division. The team is headquartered in Frisco, Texas, and has been playing its home games at AT&T Stadium in Arlington, Texas, since its opening in 2009.",
                    Price = 10000,
                    Picture = "/images/tshirts/cowboys.jpg",
                    Brand = "Dallas Cowboys",
                    Type = "T-shirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Dallas Cowboys Sweatshirt",
                   Description = 
                        "The Dallas Cowboys are a professional American football team based in the Dallas–Fort Worth metroplex. The Cowboys compete in the National Football League (NFL) as a member club of the league's National Football Conference (NFC) East division. The team is headquartered in Frisco, Texas, and has been playing its home games at AT&T Stadium in Arlington, Texas, since its opening in 2009.",
                    Price = 10000,
                    Picture = "/images/sweatshirts/cowboys.jpg",
                    Brand = "Dallas Cowboys",
                    Type = "Sweatshirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Dallas Cowboys Hat",
                   Description = 
                        "The Dallas Cowboys are a professional American football team based in the Dallas–Fort Worth metroplex. The Cowboys compete in the National Football League (NFL) as a member club of the league's National Football Conference (NFC) East division. The team is headquartered in Frisco, Texas, and has been playing its home games at AT&T Stadium in Arlington, Texas, since its opening in 2009.",
                    Price = 07599,
                    Picture = "/images/hats/cowboys.jpg",
                    Brand = "Dallas Cowboys",
                    Type = "Hats",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "Zach Wilson Jersey",
                    Description =
                        "Ascending quarterback prospect who possesses the swagger and arm talent to create explosive plays inside and outside the pocket. The gunslinger’s mentality and improvised release points are clearly patterned off of one of his favorite players, Aaron Rodgers.",
                    Price = 18000,
                    Picture = "/images/products/jets.jpg",
                    Brand = "New York Jets",
                    Type = "Jerseys",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "New York Jets T-Shirt",
                    Description =
                        "The New York Jets are a professional American football team based in the New York metropolitan area. The Jets compete in the National Football League (NFL) as a member club of the league's American Football Conference (AFC) East division. The Jets play their home games at MetLife Stadium (shared with the New York Giants) in East Rutherford, New Jersey, 5 miles (8.0 km) west of New York City.",
                    Price = 10000,
                    Picture = "/images/tshirts/jets.jpg",
                    Brand = "New York Jets",
                    Type = "T-shirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "New York Jets Sweatshirt",
                   Description = 
                        "The New York Jets are a professional American football team based in the New York metropolitan area. The Jets compete in the National Football League (NFL) as a member club of the league's American Football Conference (AFC) East division. The Jets play their home games at MetLife Stadium (shared with the New York Giants) in East Rutherford, New Jersey, 5 miles (8.0 km) west of New York City.",
                    Price = 10000,
                    Picture = "/images/sweatshirts/jets.jpg",
                    Brand = "New York Jets",
                    Type = "Sweatshirts",
                    QuantityInStock = 50
                },
                new Product
                {
                    Name = "New York Jets Hat",
                   Description = 
                        "The New York Jets are a professional American football team based in the New York metropolitan area. The Jets compete in the National Football League (NFL) as a member club of the league's American Football Conference (AFC) East division. The Jets play their home games at MetLife Stadium (shared with the New York Giants) in East Rutherford, New Jersey, 5 miles (8.0 km) west of New York City.",
                    Price = 07599,
                    Picture = "/images/hats/jets.jpg",
                    Brand = "New York Jets",
                    Type = "Hats",
                    QuantityInStock = 50
                },
            };

            foreach (var product in products)
            {
                context.Products.Add(product);
            }
            context.SaveChanges();
        }
    }
}