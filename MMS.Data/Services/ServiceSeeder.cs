using System;
using System.Text;
using System.Collections.Generic;
using MMS.Data.Models;

namespace MMS.Data.Services
{
    public static class ServiceSeeder
    {

        // use this class to seed the database with dummy 
        // test data using an IMovieService 
        public static void Seed(IMovieService svc)
        {
            svc.Initialise();
            
            // add movies
            var m1 = new Movie
            {
                
                Title = "John Wick",
                Director = "Chad Stahelski",
                Year = 2014,
                Duration = 101,
                Budget = 20,
                PosterUrl = "https://www.themoviedb.org/t/p/w1280/fZPSd91yGE9fCcCe6OoQr6E3Bev.jpg",
                Genre = Genre.Action,
                Cast = "Keanu Reeves, Michael Nyqvist, Alfie Allen",
                Plot = "Ex-hitman John Wick comes out of retirement to track down the gangsters that took everything from him."
            };
            svc.AddMovie(m1);

            var m2 = new Movie
            {
                
                Title = "Bill and Ted's Excellent Adventure",
                Director = "Stephen Herek",
                Year = 1989,
                Duration = 90,
                Budget = 10,
                PosterUrl = "https://www.themoviedb.org/t/p/w1280/tV25lGWGWGEqUe3U0xjQTBgilSx.jpg",
                Genre = Genre.Comedy,
                Cast = "Keanu Reeves, Alex Winter, George Carlin",
                Plot = "Bill and Ted are high school buddies starting a band. They are also about to fail their history class—which means Ted would be sent to military school—but receive help from Rufus, a traveller from a future where their band is the foundation for a perfect society. With the use of Rufus' time machine, Bill and Ted travel to various points in history, returning with important figures to help them complete their final history presentation."
            };
            svc.AddMovie(m2);

            var m3 = new Movie
            {
                
                Title = "Toy Story 4",
                Director = "Josh Cooley",
                Year = 2019,
                Duration = 100,
                Budget = 175,
                PosterUrl = "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/w9kR8qbmQ01HwnvK4alvnQ2ca0L.jpg",
                Genre = Genre.Family,
                Cast = "Tom Hanks, Tim Allen, Annie Potts, Keanu Reeves",
                Plot = "Woody has always been confident about his place in the world and that his priority is taking care of his kid, whether that's Andy or Bonnie. But when Bonnie adds a reluctant new toy called 'Forky to her room, a road trip adventure alongside old and new friends will show Woody how big the world can be for a toy."
            };
            svc.AddMovie(m3);


            var m4 = new Movie
            {
                
                Title = "Bram Stoker's Dracula",
                Director = "Francis Ford Coppola",
                Year = 1992,
                Duration = 122,
                Budget = 10,
                PosterUrl = "https://www.themoviedb.org/t/p/w1280/n39glC4GkBeCbwdenES8ZBodim8.jpg",
                Genre = Genre.Horror,
                Cast = "Gary Oldman, Winona Ryder,Anthony Hopkins, Keanu Reeves",
                Plot = "When Dracula leaves the captive Jonathan Harker and Transylvania for London in search of Mina Harker, the reincarnation of Dracula's long-dead wife Elisabeta, obsessed vampire hunter Dr. Van Helsing sets out to end the madness."
            };
            svc.AddMovie(m4);
            
            var m5 = new Movie
            {
                
                Title = "The Lake House",
                Director = "Alejandro Agresti",
                Year = 2006,
                Duration = 99,
                Budget = 40,
                PosterUrl = "https://www.themoviedb.org/t/p/w1280/tHpc1118dYWLnHZleGhwZxRbpae.jpg",
                Genre = Genre.Action,
                Cast = "Keanu Reeves, Sandra Bullock",
                Plot = "A lonely doctor who once occupied an unusual lakeside home begins exchanging love letters with its former resident, a frustrated architect. They must try to unravel the mystery behind their extraordinary romance before it's too late."
            };
            svc.AddMovie(m5);

            var m6 = new Movie
            {
                
                Title = "The Matrix",
                Director = "Lilly and Lana Wachowski",
                Year = 1999,
                Duration = 136,
                Budget = 63,
                PosterUrl = "https://www.themoviedb.org/t/p/w1280/f89U3ADr1oiB1s9GkdPOEpXUk5H.jpg",
                Genre = Genre.SciFi,
                Cast = "Keanu Reeves, Laurence Fishburne, Carrie-Anne Moss",
                Plot = "Set in the 22nd century, The Matrix tells the story of a computer hacker who joins a group of underground insurgents fighting the vast and powerful computers who now rule the earth."
            };
            svc.AddMovie(m6);

            var m7 = new Movie
            {
                
                Title = "Speed",
                Director = "Jan de Bont",
                Year = 1994,
                Duration = 116,
                Budget = 63,
                PosterUrl = "https://www.themoviedb.org/t/p/w1280/o1Zs7VaS9y2GYH9CLeWxaVLWd3x.jpg",
                Genre = Genre.Thriller,
                Cast = "Keanu Reeves, Sandra Bullock",
                Plot = "Los Angeles SWAT cop Jack Traven is up against bomb expert Howard Payne, who's after major ransom money. First it's a rigged elevator in a very tall building. Then it's a rigged bus--if it slows, it will blow, bad enough any day, but a nightmare in LA traffic. And that's still not the end."
            };
            svc.AddMovie(m7);

            var m8 = new Movie
            {
                
                Title = "A Walk in the Clouds",
                Director = "Alfonso Aráu",
                Year = 1995,
                Duration = 136,
                Budget = 63,
                PosterUrl = "https://www.themoviedb.org/t/p/w1280/tIvDOmWlbQYiFdwQXel5on5qjR9.jpg",
                Genre = Genre.War,
                Cast = "Keanu Reeves, Aitana Sánchez-Gijón",
                Plot = "World War II vet Paul Sutton falls for a pregnant and unwed woman who persuades him -- during their first encounter -- to pose as her husband so she can face her family."
            };
            svc.AddMovie(m8);

            var m9 = new Movie
            {
                
                Title = "The Matrix Reloaded",
                Director = "Lilly and Lana Wachowski",
                Year = 2003,
                Duration = 138,
                Budget = 150,
                PosterUrl = "https://www.themoviedb.org/t/p/w1280/8xEVAe84zlL9rkfYT6dZXero4KK.jpg",
                Genre = Genre.SciFi,
                Cast = "Keanu Reeves, Laurence Fishburne, Carrie-Anne Moss",
                Plot = "Six months after the events depicted in The Matrix, Neo has proved to be a good omen for the free humans, as more and more humans are being freed from the matrix and brought to Zion, the one and only stronghold of the Resistance. Neo himself has discovered his superpowers including super speed, ability to see the codes of the things inside the matrix and a certain degree of pre-cognition. But a nasty piece of news hits the human resistance: 250,000 machine sentinels are digging to Zion and would reach them in 72 hours"
            };
            svc.AddMovie(m9);

            var m10 = new Movie
            {
                
                Title = "The SpongeBob Movie: Sponge on the Run",
                Director = "Tim Hill",
                Year = 2020,
                Duration = 135,
                Budget = 60,
                PosterUrl = "https://www.themoviedb.org/t/p/w1280/jlJ8nDhMhCYJuzOw3f52CP1W8MW.jpg",
                Genre = Genre.Family,
                Cast = "Tom Kenny, Bill Fagerbakke, Keanu Reeves",
                Plot = "When his best friend Gary is suddenly snatched away, SpongeBob takes Patrick on a madcap mission far beyond Bikini Bottom to save their pink-shelled pal."
            };
            svc.AddMovie(m10);

           
            // seed reviews for each movie 
            var r1 = new Review
            {
                Name = "Shreyance Parakh",
                CreatedOn = DateTime.Now,
                Comment = "Pure unadulterated action",
                Rating = 4,
                MovieId = 1,
                Movie = m1
            };

            svc.AddReview(r1);

            var r2 = new Review
            {
                Name = "Peter M",
                CreatedOn = DateTime.Now,
                Comment = "Another one of those movies I first watched a few years after it came out, and just watched again this week. It is still very funny to me in many places during their adventure. Their reaction to stuff that happens is hilarious sometimes, and just the speech patterns they use is witty. Little things like referring to Joan of Arc as Miss of Arc, for example. Remiscent of the valley girl language in Clueless, not so much what happens Is funny as it is how they respond to it. It is an amusing fun ride.",
                Rating = 3,
                MovieId = 2,
                Movie = m2
            };

            svc.AddReview(r2); 

            
             var r3 = new Review
            {
                Name = "SWITCH",
                CreatedOn = DateTime.Now,
                Comment = @"Rather than offering an even more potent ending, ""Toy Story 4"" ends up being an unnecessary epilogue, offering little to enrich the overall narrative of the series and never cashing in on the actual possibilities it offers. This could have worked if it had explored a new story in the ""Toy Story"" universe, and Forky certainly makes it clear that such a move could have worked beautifully. Instead, we have a film that feels tired and forced, lacking in clarity or inspiration, serving neither its classic characters or its new ones, and ultimately never justifying its existence.",
                Rating = 3,
                MovieId = 3,
                Movie = m3
            };

            svc.AddReview(r3); 

            var r4 = new Review
            {
                Name = "John Chard",
                CreatedOn = DateTime.Now,
                Comment = "Gets worse on repeat viewings.",
                Rating = 1,
                MovieId = 4,
                Movie = m4
            };
            svc.AddReview(r4); 

            var r5 = new Review
            {
                Name = "Andres Gomez",
                CreatedOn = DateTime.Now,
                Comment = "This is the stereotypical romantic drama which tries to use the successful mix from Speed between Bullock and Reeves. It doesn't really work",
                Rating = 3,
                MovieId = 5,
                Movie = m5
            };
            svc.AddReview(r5); 

            var r6 = new Review
            {
                Name = "Wuchak",
                CreatedOn = DateTime.Now,
                Comment = "Brainy, entertaining and iconic, but too cool",
                Rating = 3,
                MovieId = 6,
                Movie = m6
            };
            svc.AddReview(r6); 

                
            var r7 = new Review
            {
                Name = "Tim Greeves",
                CreatedOn = DateTime.Now,
                Comment = "A Rollercoaster of a movie - who knew buses could be this interesting",
                Rating = 4,
                MovieId = 7,
                Movie = m7
            };
            svc.AddReview(r7); 
 

            var r8 = new Review
            {  
                Name = "Sarah Vernon",
                CreatedOn = DateTime.Now,
                Comment = "I just wanted it to end. You will too.",
                Rating = 2,
                MovieId = 8,
                Movie = m8
                
            };
            svc.AddReview(r8); 

             var r9 = new Review
            {
              
                Name = "NeoBrowsers",
                CreatedOn = DateTime.Now,
                Comment = "Commander Lock: 'Not everyone believes what you believe.' Morpheus: 'My beliefs do not require that they do.' Characters are always talking like this in 'The Matrix Reloaded,' which plays like a collaboration involving a geek, a comic book and the smartest kid in Philosophy 101. ",
                Rating = 5,
                MovieId = 9,
                Movie = m9
            };
            svc.AddReview(r9); 

            var r10 = new Review
            {  
                Name = "SWITCH",
                CreatedOn = DateTime.Now,
                Comment = "Thanks to its meme resurgence, a surprisingly successful musical, three spinoff shows in the works and the thirteenth season currently airing, there is no slowing down Bikini Bottom's finest. As a fan, it was nice to spend some time with these characters who I haven't seen in a while - but the original movie and first few seasons are still superior in every way. ",
                Rating = 3,
                MovieId = 10,
                Movie = m10
                
            };

            svc.AddReview(r10);
        }
    }
}
