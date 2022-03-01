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
                    Name = "Aaron Rodgers Jersey",
                    Description =
                        "Truly jumbo-sized for the NFL running back position, and has enough speed to handle the featured role. Uncommonly strong and physical (even for his size), and capable of running through and over second-level defenders. Shows superb field vision and patience, following his blocking then rumbling downhill. A regular factor for big yardage and a true asset at the goal-line. Has immense upside as a blocker.",
                    Price = 18000,
                    Picture = "/images/products/packers.jpg",
                    Brand = "Greeny Bay Packers",
                    Type = "Jerseys",
                    QuantityInStock = 100
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
                    Name = "Terry McLaurin Jersey",
                    Description =
                        "The ex-Ohio State Buckeye brings plenty of route-running savvy and top-end speed in a solid, pro-sized frame. His high football IQ shows in a nuanced ability to shift gears, throw defenders off his trail or create a cushion to get completions in the middle of the field. Catches the ball close to his body, wins a majority of contested throws and commands respect as a deep threat on go routes.",
                    Price = 18000,
                    Picture = "/images/products/washington.jpg",
                    Brand = "Washington Football Team",
                    Type = "Jerseys",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Christian McCaffery Jersey",
                    Description =
                        "A gifted multi-purpose player: downright explosive as a running back, return man, and receiver. Has supreme quickness and elite change-of-direction skills, and easily evades tackles. Fast, and pretty patient in general (helping him pile up chunk yards). Shows good ability to punch it in at the goal-line too.",
                    Price = 18000,
                    Picture = "/images/products/panthers.jpg",
                    Brand = "Caroline Panthers",
                    Type = "Jerseys",
                    QuantityInStock = 100
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
                    Name = "Zach Wilson Jersey",
                    Description =
                        "Ascending quarterback prospect who possesses the swagger and arm talent to create explosive plays inside and outside the pocket. The gunslinger’s mentality and improvised release points are clearly patterned off of one of his favorite players, Aaron Rodgers.",
                    Price = 18000,
                    Picture = "/images/products/jets.jpg",
                    Brand = "New York Jets",
                    Type = "Jerseys",
                    QuantityInStock = 100
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