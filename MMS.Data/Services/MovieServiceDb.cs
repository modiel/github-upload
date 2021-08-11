using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using MMS.Data.Models;
using MMS.Data.Repositories;
using MMS.Data.Services;


namespace MMS.Data.Services
{
    // create IMovieService implementation called MovieServiceDb
    // using the provided Entityframework Repository (MovieDbContext)

    public class MovieServiceDb : IMovieService
    {
        private readonly MovieDbContext db;

        public MovieServiceDb()
        {
            db = new MovieDbContext();
        }

        public void Initialise()
        {
            db.Initialise();
        }



        // ------------- Movie Related Operations -----------------//

        //retrieve list of Movies

        public IList<Movie> GetAllMovies(string order = null)
        {

            

            // retrieve list of movies from database
            var movies = db.Movies.ToList();

            //order by Director, Title or year
            if (order == "Title")
            {
                return movies.OrderBy(m => m.Title).ToList();
            }

            else if (order == "Director")
            {
                return movies.OrderBy(m => m.Director).ToList();
            }

            else if (order == "Year")
            {
                return movies.OrderBy(m => m.Year).ToList();
            }

            //return the collection as a (default order by Id)
            else
                return movies;

        }

        public Movie GetMovieById(int id)
        {
            return db.Movies.Include(mm => mm.Reviews)
            .FirstOrDefault(mm => mm.Id == id);

        }
        public bool DeleteMovie(int id)
        {
            // Delete the movie identified by Id returning true if deleted and false if not found
            var s = GetMovieById(id);

            if (s == null)
            {
                return false;
            }

            db.Movies.Remove(s);
            db.SaveChanges(); // write to database
            return true;
        }

        public bool UpdateMovie(Movie m)
        {
            //verify movie exists if not found return false
            var movie = GetMovieById(m.Id);

            if (movie == null)
            {
                return false;
            }

            //update properties for movie

            movie.Title = m.Title;
            movie.Director = m.Director;
            movie.Year = m.Year;
            movie.Duration = m.Duration;
            movie.Budget = m.Budget;
            movie.PosterUrl = m.PosterUrl;
            movie.Genre = m.Genre;
            movie.Cast = m.Cast;
            movie.Plot = m.Plot;

            var movieU= GetMovieById(movie.Id);
            db.SaveChanges();
            return movieU != null;
            //return updated movie if not empty

        }
        public Movie AddMovie(Movie m)
        {
            //check if movie already exists in the database

            var existing = GetMovieById(m.Id);

            if (existing != null)
            {
                return null; //id is already in database so movie cannot be added
            }

            //unique id allows movie to be added

            var mm = new Movie
            {

                Title = m.Title,
                Director = m.Director,
                Year = m.Year,
                Duration = m.Duration,
                Budget = m.Budget,
                PosterUrl = m.PosterUrl,
                Genre = m.Genre,
                Cast = m.Cast,
                Plot = m.Plot,

            };
            db.Movies.Add(mm);
            db.SaveChanges(); //write to database
            return mm; // return newly added movie
        }

        // ------------- Review Related Operations -----------------//
        public Review GetReviewById(int id)
        {
            return db.Reviews
                        .Include(r => r.Movie)
                        .FirstOrDefault(r => r.Id == id);
        }

        public Review AddReview(Review r)
        {   
            //retrieve movie from database
            var movie = GetMovieById(r.MovieId);

            // if movie does not exist return null
            if (movie == null) return null;

            var review = new Review
            {
                Name = r.Name,
                CreatedOn = DateTime.Now,
                Comment = r.Comment,
                Rating = r.Rating,
                MovieId = r.MovieId,
                Movie = r.Movie
            };
            //add review to movie
            movie.Reviews.Add(review);

            //write to database
            db.SaveChanges();
            return review;//return new review to movie
        }

        public bool DeleteReview(int id)
        {
            // find ticket
            var review = GetReviewById(id);
            if (review == null) return false;

            // remove review from movie
            var result = review.Movie.Reviews.Remove(review);
            
            //write to database
            db.SaveChanges();

            return result;
        }


    }

}