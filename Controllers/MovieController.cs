    using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieHistory.Models;
using Microsoft.Extensions.Configuration;
using MovieHistory.Services;
using Microsoft.Extensions.Options;
using MovieHistory.Data;
using Microsoft.AspNetCore.Identity;
using MovieHistory.Models.MovieViewModels;
using Microsoft.EntityFrameworkCore;

namespace MovieHistory.Controllers
{
    public class MovieController : Controller
    {
        private readonly IApplicationConfiguration _appSettings;
        private ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public MovieController(IApplicationConfiguration appSettings, ApplicationDbContext ctx, UserManager<ApplicationUser> userManager)
        {
            _appSettings = appSettings;
            _context = ctx;
            _userManager = userManager;
        }

        // This task retrieves the currently authenticated user
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        public async Task<IActionResult> ListTracked ()
        {
            ApplicationUser user = await GetCurrentUserAsync();

            var model = new TrackedMoviesViewModel();
            model.TrackedUserMovies = GetUserTrackedMovies(user);

            return View(model);
        }

        public async Task<IActionResult> Track(string apiId, string title, string img)
        {
            //gets the current user
            ApplicationUser user = await GetCurrentUserAsync();

            if (IsMovieTracked(Int32.Parse(apiId), user))
            {
                return RedirectToActionPermanent("ListTracked");
            }

            //add movie to database
            Movie movie = new Movie
            {
                ApiId = Int32.Parse(apiId),
                Title = title,
                ImgUrl = img
            };

            _context.Add(movie);


            //track that movie for the current user
            var trackMovie = new MovieUser
            {
                User = user,
                MovieId = movie.MovieId
            };


            _context.Add(trackMovie);
            await _context.SaveChangesAsync();

            return RedirectToActionPermanent("ListTracked");
        }

        public ICollection<TrackedMovie> GetUserTrackedMovies (ApplicationUser user)
        {
            return (from m in _context.Movie
             join mu in _context.MovieUser
               on m.MovieId equals mu.MovieId
             where mu.User == user
             select new TrackedMovie
             {
                 MovieUserId = mu.MovieUserId,
                 Title = m.Title,
                 ImageURL = m.ImgUrl,
                 Genre = mu.Genre,
                 Favorited = mu.Favorited,
                 Watched = mu.Watched
             }).ToList();
        }

        public bool IsMovieTracked (int movieId, ApplicationUser user)
        {
            var isTracked = _context.MovieUser
                .Include("Movie")
                .Where(mu => mu.Movie.ApiId == movieId && mu.User == user)
                .FirstOrDefault();

            if (isTracked == null)
            {
                return false;
            }

            return true;
        }

        public async Task<IActionResult> Update([FromRoute] int id, TrackedMovie trackedMovie)
        {
            var userMovie = _context.MovieUser.Single(m => m.MovieUserId == id);

            userMovie.Favorited = trackedMovie.Favorited;
            userMovie.Genre = trackedMovie.Genre;
            userMovie.Watched = trackedMovie.Watched;

            _context.Update(userMovie);
            await _context.SaveChangesAsync();

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
