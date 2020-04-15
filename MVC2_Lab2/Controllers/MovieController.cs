using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC2_Lab2.Models;
using MVC2_Lab2.ViewModels;

namespace MVC2_Lab2.Controllers
{
    public class MovieController : Controller
    {
        private readonly sakilaContext _context;

        public MovieController(sakilaContext context)
        {
            _context = context;
        }
        public IActionResult ShowMovies(string sortcolumn, string sortorder)
        {
            var model = new MovieListViewModel();
            
            var filmer = _context.Film.ToList();
            var movies = filmer;

            if (string.IsNullOrEmpty(sortorder))
            {
                sortorder = "asc";
            }

            if (sortcolumn == "datum")
            {
                if (sortorder == "asc")
                    movies = filmer.OrderBy(p => p.ReleaseYear).ToList();
                else
                    movies = filmer.OrderByDescending(p => p.ReleaseYear).ToList();
            }
            else if (sortcolumn == "id")
            {
                if (sortorder == "asc")
                    movies = filmer.OrderBy(p => p.FilmId).ToList();
                else
                    movies = filmer.OrderByDescending(p => p.FilmId).ToList();

            }
            else
            {
                if (sortorder == "asc")
                    movies = filmer.OrderBy(p => p.Title).ToList();
                else
                    movies = filmer.OrderByDescending(p => p.Title).ToList();

                sortcolumn = "namn";
            }

            model.filmerna = new Film();
            model.filmLista = movies;
            model.SortColumn = sortcolumn;
            model.SortOrder = sortorder;
            return View(model);
        }

        public IActionResult MovieDetails(int id)
        {
            var listdata = new MovieListViewModel();

            listdata.filmLista = _context.Film
                                    .Include(movie => movie.FilmCategory).ThenInclude(cat => cat.Category)
                                    .Include(movie => movie.FilmActor).ThenInclude(act => act.Actor)
                                    .Include(movie => movie.Language)
                                    .Include(movie => movie.Inventory)
                                    .Where(movie => movie.FilmId == id)
                                    .ToList();

            //(from m in _context.FilmActor
            //          join p in _context.Actor on m.ActorId equals p.ActorId
            //          join c in _context.Film on m.FilmId equals id
            //          select m).ToList();

            
            return View(listdata);
        }
    }
}