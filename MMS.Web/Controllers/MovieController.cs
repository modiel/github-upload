using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;

using MMS.Data.Models;
using MMS.Data.Services;
using MMS.Web.Models;

namespace MMS.Web.Controllers
{
    public class MovieController : BaseController
    {
        private IMovieService svc;

        public MovieController(IMovieService ms)
        { 
            //create dependency injection
            svc = ms;
        }


        public IActionResult IndexTitle()
        {       
            //display all movies ordered by title taking user input from the view
            var movieTitle= svc.GetAllMovies("Title");

            return View (movieTitle);

        }

        public IActionResult IndexDirector()
        {   
            //display all movies ordered by director taking user input from the view
            var movieDirector= svc.GetAllMovies("Director");
            
            return View (movieDirector);
        }

        public IActionResult IndexYear()
        {   
            //display all movies ordered by director taking user input from the view
            var movieYear= svc.GetAllMovies("Year");
            
            return View (movieYear);
        }



        // GET /movie- default index page which orders movie by Id
        public IActionResult Index()
        { 
            var m =  svc.GetAllMovies();
           
            return View(m);

        }

        // GET /movie/details/{id}
        public IActionResult Details(int id)
        {
            // retrieve the movie with specified id from the service
            var m = svc.GetMovieById(id);

            // TBC check if m is null and return NotFound()
            if (m == null)
            {     
                Alert($"Sorry! No such movie ", AlertType.warning);          
                return RedirectToAction(nameof(Index));
            }

            // pass movie as parameter to the view
            return View(m);
        }

        // GET: /movie/create
        public IActionResult Create()
        {
            // display blank form to create a movie
            var m = new Movie();
            return View(m);
        }

        // POST /movie/create
        [HttpPost]
        public IActionResult Create(Movie m)
        {
            
            // complete POST action to add movie
            if (ModelState.IsValid)
            {
                // TBC pass data to service to store 
                svc.AddMovie(m);
                 Alert($"Movie {m.Title} created successfully", AlertType.info);

                return RedirectToAction(nameof(Index));
            }
           
            // redisplay the form for editing as there are validation errors
            return View(m);
        }

        // GET /movie/edit/{id}
        public IActionResult Edit(int id) {
           
            var m = svc.GetMovieById(id); // load the movie using the service            
            
            if (m == null)  {           // check if s is null and alert
               
                Alert($"No such movie {m.Title}", AlertType.warning);          
                
                return RedirectToAction(nameof(Index));
 
            }
            return View(m); 
        }

        // POST /movie/edit/{id}
        [HttpPost]
        public IActionResult Edit( int id, Movie m)
        {
            
            // complete POST action to save movie changes
            if (ModelState.IsValid)
            {
                // Pass data to service to update
                
                svc.UpdateMovie(m);
                Alert($"Movie details {m.Title} saved", AlertType.info);

                return RedirectToAction(nameof(Index));     
            }
            // redisplay the form for editing as there are validation errors
            return View(m);
        }

        // GET / movie/delete/{id}
        public IActionResult Delete(int id)
        {
            // load the movie using the service
            var m = svc.GetMovieById(id);
            // check the returned movie is not null and if so alert
            if (m == null)
            {
                Alert($"Oops! No such movie {id}", AlertType.warning);          
                return RedirectToAction(nameof(Index));
            }     
            
            // pass movie to view for deletion confirmation
            return View(m);
        }

        // POST /movie/delete/{id}
        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            // delete movie via service
           svc.DeleteMovie(id);
         
            Alert($"Movie {id} deleted successfully", AlertType.success);
            // redirect to the index view
            return RedirectToAction(nameof(Index));
            
        }

        // GET /movie/createreview
        public IActionResult CreateReview(int id)
        {
            var m = svc.GetMovieById(id);
             // check the returned movie is not null and if so alert
            if (m == null)
            {
                Alert($"Sorry! No such movie {id}", AlertType.warning);          
                return RedirectToAction(nameof(Index));
            }  
            // create the review and populate the MovieId property
            var r = new Review {
                MovieId = id
            };
 
            return View("CreateReview", r);
        }

        // POST /movie/createreview
        [HttpPost]
        public IActionResult CreateReview (Review r)
        {
            var m = svc.GetMovieById(r.MovieId);
             // check the returned movie is not null and if so alert
            if (m == null)
            {
                Alert($"No such movie {r.MovieId}", AlertType.warning);          
                return RedirectToAction(nameof(Details));
            }  
            
            Alert($"Review for {m.Title} created successfully", AlertType.success);   
            // create the review view model and populate the MovieId property
            svc.AddReview(r);
 
            return RedirectToAction("Details", new { Id = r.MovieId });
        }

           // GET / review/delete/{id}
        public IActionResult DeleteReview(int id)
        {
            // load the student using the service
            var r = svc.GetReviewById(id);
            // check the returned student is not null and if so alert
            if (r == null)
            {
                Alert($"No such review {r.MovieId}", AlertType.warning);          
                return RedirectToAction(nameof(Index));
            }     
            
            // pass review to view for deletion confirmation
            return View(r);
        }

        // POST /review/delete/{id}
        [HttpPost]
        public IActionResult DeleteReviewConfirm(int id)
        {
            // delete review via service
             svc.DeleteReview(id);
         
            Alert($"Review {id} deleted successfully", AlertType.success);
            
            // redirect to the details view
           return RedirectToAction(nameof(Index));
            
        
        }


    }
}