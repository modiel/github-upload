using System;
using System.Linq;
using Xunit;

using MMS.Data.Models;
using MMS.Data.Services;

namespace MMS.Test
{
    public class TestMovieService
    {
        private readonly IMovieService svc;

        public TestMovieService()
        {
            // create and initialise MovieServiceDb service

            svc = new MovieServiceDb();
            svc.Initialise();

        }

        // add tests here - test should ensure your service implementation works

        //-------------------------- Movie Tests ---------------------------------//

        [Fact]
        public void Movie_GetMoviesWhenNone_ShouldReturnNone()
        {
            //arrange

            //act
            var movies = svc.GetAllMovies(); //database should be empty
            var count = movies.Count;

            //assert 
            Assert.Equal(0, count);
        }

        [Fact]
        public void Movie_GetMovieWhenDoesNotExist_ShouldReturnNull()
        {
            //arrange

            //act
            var movie = svc.GetMovieById(1); //non existent movie

            //assert
            Assert.Null(movie);
        }

        [Fact]
        public void Movie_GetMovieWhenOrderByTitle_ShouldReturnMovies()
        {
            //arrange

            //act - pass in Title parameter to GetAllMovies
            var movies = svc.GetAllMovies("Title");

            //assert
            Assert.NotNull(movies);
        }

        [Fact]
        public void Movie_GetMovieWhenOrderByDirector_ShouldReturnMovies()
        {
            //arrange

            //act - pass in Title parameter to GetAllMovies
            var movies = svc.GetAllMovies("Director");

            //assert
            Assert.NotNull(movies);
        }

        [Fact]
        public void Movie_GetMovieWhenOrderByYear_ShouldReturnMovies()
        {
            //arrange

            //act - pass in Title parameter to GetAllMovies
            var movies = svc.GetAllMovies("Year");

            //assert
            Assert.NotNull(movies);
        }

        [Fact]
        public void Movie_GetMovieThatExists_ShouldReturnMovie()
        {
            //arrange
            //create dummy movie to add to the service
            var m = new Movie
            {
                Id = 1,
                Title = "XXX",
                Director = "Tim Burton",
                Year = 2001,
                Duration = 140,
                Budget = 400,
                PosterUrl = "https://photo.com",
                Genre = Genre.War,
                Cast = "Keanu Reeves",
                Plot = "Keanu saves the day"
            };
            var movie = svc.AddMovie(m);

            //act
            var nmovie = svc.GetMovieById(movie.Id);

            //assert
            Assert.NotNull(movie);
            Assert.Equal(movie.Id, nmovie.Id);

        }
        [Fact]
        public void Movie_DeleteMovieThatExists_ShouldReturnTrue()
        {
            //arrange
            //create dummy movie to add to the service
            var m = new Movie
            {
                Id = 1,
                Title = "XXX",
                Director = "Tim Burton",
                Year = 2001,
                Duration = 140,
                Budget = 400,
                PosterUrl = "https://photo.com",
                Genre = Genre.War,
                Cast = "Keanu Reeves",
                Plot = "Keanu saves the day"
            };
            var movie = svc.AddMovie(m);

            //act
            var deleted = svc.DeleteMovie(movie.Id);
            var movie1 = svc.GetMovieById(movie.Id); //attempt to get the movie

            //asert
            Assert.True(deleted); //delete movie should return true
            Assert.Null(movie1); // movie1 should be null (as does not exist)

        }

        [Fact]
        public void Movie_DeleteMovieThatExists_ShouldReduceMovieCountByOne()
        {
            //arrange
            //create dummy movie to add to the service
            var m = new Movie
            {
                Id = 1,
                Title = "XXX",
                Director = "Tim Burton",
                Year = 2001,
                Duration = 140,
                Budget = 400,
                PosterUrl = "https://photo.com",
                Genre = Genre.War,
                Cast = "Keanu Reeves",
                Plot = "Keanu saves the day"
            };
            var movie = svc.AddMovie(m);

            //act
            var deleted = svc.DeleteMovie(movie.Id);
            var movies = svc.GetAllMovies(); //retrieve list of movies to confirm movie is deleted

            //assert
            Assert.Equal(0, movies.Count); //confirm movies count is 0

        }

        [Fact]
        public void Movie_DeleteMovieThatDoesntExist_ShouldNotChangeMovieCount()
        {
            // arrange
            //create dummy movie to add to the service
            var m = new Movie
            {
                Id = 1,
                Title = "XXX",
                Director = "Tim Burton",
                Year = 2001,
                Duration = 140,
                Budget = 400,
                PosterUrl = "https://photo.com",
                Genre = Genre.War,
                Cast = "Keanu Reeves",
                Plot = "Keanu saves the day"
            };
            var movie = svc.AddMovie(m);

            // act 	
            svc.DeleteMovie(0);               // delete non existent Movie
            var Movies = svc.GetAllMovies();   // retrieve list of Movies

            // assert
            Assert.Equal(1, Movies.Count);    // should be 1 Movie
        }

        [Fact]
        public void Movie_DeleteMovie_WhenDeleted_ShouldAlsoDeleteReview()
        
        {
            //arrange
            //create dummy movie to add to the service
            var m = new Movie
            {
                Id = 1,
                Title = "XXX",
                Director = "Tim Burton",
                Year = 2001,
                Duration = 140,
                Budget = 400,
                PosterUrl = "https://photo.com",
                Genre = Genre.War,
                Cast = "Keanu Reeves",
                Plot = "Keanu saves the day"
            };
            var movie = svc.AddMovie(m);

            //create test review amnd add to database
            var r = new Review
            {
                Id = 1,
                Name = "Joe Bloggs",
                CreatedOn = DateTime.Now,
                Comment = "The movie sucked",
                Rating = 3,
                MovieId = 1,
                Movie = m

            };

            var mr = svc.AddReview(r);

            //act 
            //delete movie from database
            var deleted = svc.DeleteMovie(movie.Id);
      
            //attempt to retrieve review from database
            var mr1 = svc.GetReviewById(mr.Id);
            
            //assert

            Assert.True(deleted);
            Assert.Null(mr1);


        }

        [Fact]
        public void Movie_UpdateWhenExists_ShouldSetAllProperties()
        {
            //arrange - create test movie
            var m = new Movie
            {
                Id = 1,
                Title = "XXX",
                Director = "Tim Burton",
                Year = 2001,
                Duration = 140,
                Budget = 400,
                PosterUrl = "https://photo.com",
                Genre = Genre.War,
                Cast = "Ryan Renolds",
                Plot = "Ryan saves the day"
            };
            
            m = svc.AddMovie(m);

            //update test movie
            
            //act - overwrite the attributes
            m.Title = "ZZZ";
            m.Director = "Spielberg";
            m.Year = 2000;
            m.Duration = 110;
            m.Budget = 40;
            m.PosterUrl = "https://xxx.com";
            m.Genre = Genre.Horror;
            m.Cast = "Keanu Reeves";
            m.Plot = "Keanu saves the day ";

          
            svc.UpdateMovie(m);

            //assert
            Assert.NotNull(m);
            Assert.Equal("ZZZ", m.Title);
            Assert.Equal("Spielberg", m.Director);
            Assert.Equal(2000, m.Year);
            Assert.Equal(110, m.Duration);
            Assert.Equal(40, m.Budget);
            Assert.Equal(Genre.Horror, m.Genre);
            Assert.Equal("Keanu Reeves", m.Cast);
            Assert.Equal("Keanu saves the day ", m.Plot);

        }

        [Fact]
        public void Movie_GetMoviesWhenTwoAdded_ShouldReturnTwo()
        {
            //arrange - create test movie
            var m = new Movie
            {
                Id = 1,
                Title = "XXX",
                Director = "Tim Burton",
                Year = 2001,
                Duration = 140,
                Budget = 400,
                PosterUrl = "https://photo.com",
                Genre = Genre.War,
                Cast = "Ryan Renolds",
                Plot = "Ryan saves the day"
            };
            var movie = svc.AddMovie(m);

            //add second movie
            var m2 = new Movie
            {
                Title = "ZZZ",
                Director = "Spielberg",
                Year = 2000,
                Duration = 110,
                Budget = 40,
                PosterUrl = "https://xxx.com",
                Genre = Genre.Horror,
                Cast = "Keanu Reeves",
                Plot = "Keanu saves the day "

            };

            var movie2 = svc.AddMovie(m2);

            //act
            var movies = svc.GetAllMovies();
            var count = movies.Count;

            //assert
            Assert.Equal(2, count);

        }


        // =================  Review Tests ===========================

        [Fact]
        public void Review_CreateReviewForExistingMovie_ShouldReturnReview()
        {
            // arrange
            // create test movie
            var m = new Movie
            {
                Id = 1,
                Title = "XXX",
                Director = "Tim Burton",
                Year = 2001,
                Duration = 140,
                Budget = 400,
                PosterUrl = "https://photo.com",
                Genre = Genre.War,
                Cast = "Ryan Renolds",
                Plot = "Ryan saves the day"
            };
            var movie = svc.AddMovie(m);

            //create test review
            var r = new Review
            {
                Id = 1,
                Name = "Joe Bloggs",
                CreatedOn = DateTime.Now,
                Comment = "The movie sucked",
                Rating = 3,
                MovieId = 1,
                Movie = m

            };

            //act
            //get movie and add review
            var movie1 = svc.GetMovieById(m.Id);
            var mr = svc.AddReview(r);

            // assert
            Assert.NotNull(r);
            Assert.Equal(r.Id, mr.Id);

        }

        [Fact]
        public void Review_DeleteReviewWhenExists_ShouldReturnNull()
        {
            // arrange
            // create test movie
            var m = new Movie
            {
                Id = 1,
                Title = "XXX",
                Director = "Tim Burton",
                Year = 2001,
                Duration = 140,
                Budget = 400,
                PosterUrl = "https://photo.com",
                Genre = Genre.War,
                Cast = "Ryan Renolds",
                Plot = "Ryan saves the day"
            };

            var movie = svc.AddMovie(m);

            //create test review
            var r = new Review
            {
                Id = 1,
                Name = "Joe Bloggs",
                CreatedOn = DateTime.Now,
                Comment = "The movie sucked",
                Rating = 3,
                MovieId = 1,
                Movie = m

            };

            //act
            //get movie and add review
            var movie1 = svc.GetMovieById(m.Id);
            var mr = svc.AddReview(r);

            //delete review and confirm deleted
            var deleted = svc.DeleteReview(mr.Id);
            var mr1 = svc.GetReviewById(mr.Id);

            // assert
            Assert.True(deleted);
            Assert.Null(mr1);

        }

        [Fact]
        public void Review_DeleteWhenDoesNotExist_ShouldReturNull()
        {
            //arrange

            //act
            var notexist = svc.GetReviewById(0); //non existent review

            //assert
            Assert.Null(notexist);

        }      


        [Fact]
        public void Review_WhenTwoReviewsAdded_Should_ReturnTwo()
        {

            // arrange
            // create test movie
            var m = new Movie
            {
                Id = 1,
                Title = "XXX",
                Director = "Tim Burton",
                Year = 2001,
                Duration = 140,
                Budget = 400,
                PosterUrl = "https://photo.com",
                Genre = Genre.War,
                Cast = "Ryan Renolds",
                Plot = "Ryan saves the day"
            };

            var movie = svc.AddMovie(m);

            //create test review
            var r = new Review
            {
                Id = 1,
                Name = "Joe Bloggs",
                CreatedOn = DateTime.Now,
                Comment = "The movie sucked",
                Rating = 3,
                MovieId = 1,
                Movie = m

            };

            //create another review

            var r2 = new Review
            {
                Id = 2,
                Name = "Jane Bloggs",
                CreatedOn = DateTime.Now,
                Comment = "The movie was awesome",
                Rating = 8,
                MovieId = 1,
                Movie = m

            };

            //act

            //get movie and add reviews
            var movie1 = svc.GetMovieById(m.Id);
            var mr = svc.AddReview(r);
            var mr2 = svc.AddReview(r2);

            //assert
            Assert.NotNull(mr);
            Assert.NotNull(mr2);

        }
        [Fact]
        public void Review_WhenTwoReviewsAddedAndOneDeleted_Should_ReturnOne()
        {

            // arrange
            // create test movie
            var m = new Movie
            {
                Id = 1,
                Title = "XXX",
                Director = "Tim Burton",
                Year = 2001,
                Duration = 140,
                Budget = 400,
                PosterUrl = "https://photo.com",
                Genre = Genre.War,
                Cast = "Ryan Renolds",
                Plot = "Ryan saves the day"
            };

            var movie = svc.AddMovie(m);

            //create test review
            var r = new Review
            {
                Id = 1,
                Name = "Joe Bloggs",
                CreatedOn = DateTime.Now,
                Comment = "The movie sucked",
                Rating = 3,
                MovieId = 1,
                Movie = m

            };

            //create another review

            var r2 = new Review
            {
                Id = 2,
                Name = "Jane Bloggs",
                CreatedOn = DateTime.Now,
                Comment = "The movie was awesome",
                Rating = 8,
                MovieId = 1,
                Movie = m

            };

            //act

            //get movie and add reviews
            var movie1 = svc.GetMovieById(m.Id);
            var mr = svc.AddReview(r);
            var mr2 = svc.AddReview(r2);

            //delete one review
            var deleted = svc.DeleteReview(mr.Id);

            // assert
            Assert.True(deleted);
            Assert.NotNull(mr2);

        }

        [Fact]
        public void Review_WhenDeleted_ShouldReduceReviewCountBy_One()
        {

            //arrange
            //create dummy movie to add to the service
            var m = new Movie
            {
                Id = 1,
                Title = "XXX",
                Director = "Tim Burton",
                Year = 2001,
                Duration = 140,
                Budget = 400,
                PosterUrl = "https://photo.com",
                Genre = Genre.War,
                Cast = "Keanu Reeves",
                Plot = "Keanu saves the day"
            };

            var movie = svc.AddMovie(m);

            //create test review
            var r = new Review
            {
                Id = 1,
                Name = "Joe Bloggs",
                CreatedOn = DateTime.Now,
                Comment = "The movie sucked",
                Rating = 3,
                MovieId = 1,
                Movie = m

            };

            //act
            //get movie and add review
            var movie1 = svc.GetMovieById(m.Id);
            var mr = svc.AddReview(r);


            //delete review and try then to retreive 
            var deleted = svc.DeleteReview(mr.Id);
            var reviews = svc.GetReviewById(mr.Id);

            //assert
            Assert.Equal(0, movie.Reviews.Count); //confirm reviews count is 0

        }

    

    }
}
