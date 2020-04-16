using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC2_Lab2.Models;
using MVC2_Lab2.Service;
using MVC2_Lab2.ViewModels;
using static MVC2_Lab2.ViewModels.MovieListViewModel;

namespace MVC2_Lab2.Controllers
{
    public class MovieController : Controller
    {
        private IMovieRepository _context;
        private readonly int PageSize = 100;

        public MovieController(IMovieRepository context)
        {
            _context = context;
        }
        public IActionResult ShowMovies(string sortcolumn, string sortorder, string page)
        {
            //var model = new MovieListViewModel();

            //var items = _context.Film.Include(order => order.FilmId).Select(o => new MovieListViewModel.MovieViewModel)
            //{
            //    CustomerName = o.Customer.CompanyName,
            //    OrderDate = o.OrderDate,
            //    OrderId = o.OrderId
            //});

            //var filmer = _context.Film.ToList();
            //var movies = filmer;

            //if (string.IsNullOrEmpty(sortcolumn))
            //    sortcolumn = "id";

            //if (string.IsNullOrEmpty(sortorder))
            //{
            //    sortorder = "asc";
            //}

            //if (sortcolumn == "datum")
            //{
            //    if (sortorder == "asc")
            //        movies = filmer.OrderBy(p => p.ReleaseYear).ToList();
            //    else
            //        movies = filmer.OrderByDescending(p => p.ReleaseYear).ToList();
            //}
            //else if (sortcolumn == "id")
            //{
            //    if (sortorder == "asc")
            //        movies = filmer.OrderBy(p => p.FilmId).ToList();
            //    else
            //        movies = filmer.OrderByDescending(p => p.FilmId).ToList();

            //}
            //else
            //{
            //    if (sortorder == "asc")
            //        movies = filmer.OrderBy(p => p.Title).ToList();
            //    else
            //        movies = filmer.OrderByDescending(p => p.Title).ToList();

            //    sortcolumn = "namn";
            //}



            //int currentPage = string.IsNullOrEmpty(page) ? 1 : Convert.ToInt32(page);

            ///*
            // * OFFSET  (@Page-1)*25 ROWS       -- skip 120 rows
            //FETCH NEXT 25 ROWS ONLY; -- take 10 rows
            // *
            // */
            //var pageCount = (double)movies.Count() / PageSize;
            //model.PagingViewModel.MaxPages = (int)Math.Ceiling(pageCount);

            //movies = movies.Skip((currentPage - 1) * PageSize).Take(PageSize).ToList();

            ////Hur många sidor???               100 / 25
            ////int totalNumberOfPages = items.Count()  / PageSize;
            ////result.PageCount = (int)Math.Ceiling(pageCount);


            //model.PagingViewModel.CurrentPage = currentPage;


            //model.filmerna = new Film();
            //model.filmLista = movies;
            //model.SortColumn = sortcolumn;
            //model.SortOrder = sortorder;
            var moviesOrdered = _context.GetAll(sortcolumn, sortorder, page, PageSize);

            return View(moviesOrdered);
        }

        public IActionResult MovieDetails(int id)
        {
            //var listdata = new MovieListViewModel();

            //listdata.filmerna = _context.Film
            //                        .Include(movie => movie.FilmCategory).ThenInclude(cat => cat.Category)
            //                        .Include(movie => movie.FilmActor).ThenInclude(act => act.Actor)
            //                        .Include(movie => movie.Language)
            //                        .Include(movie => movie.Inventory)
            //                        .Where(movie => movie.FilmId == id)
            //                        .ToList();

            //(from m in _context.FilmActor
            //          join p in _context.Actor on m.ActorId equals p.ActorId
            //          join c in _context.Film on m.FilmId equals id
            //          select m).ToList();


            return View(_context.GetFilm(id));
        }

        
    }
}