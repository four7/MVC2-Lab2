using Microsoft.EntityFrameworkCore;
using MVC2_Lab2.Models;
using MVC2_Lab2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC2_Lab2.Service
{
    
        public interface IMovieRepository
        {
            MovieListViewModel GetAll(string sortColumn, string sortOrder, string page, int PageSize);
            MovieListViewModel GetFilm(int id);
        }
        public class MovieRepository : IMovieRepository
        {
            private sakilaContext _context;
            public MovieRepository(sakilaContext context)
            {
                _context = context;
            }

            public MovieListViewModel GetFilm(int id)
            {

                var Model = new MovieListViewModel();

                Model.filmerna = _context.Film
                                .Include(movie => movie.FilmCategory).ThenInclude(cat => cat.Category)
                                .Include(movie => movie.FilmActor).ThenInclude(act => act.Actor)
                                .Include(movie => movie.Language)
                                .Include(movie => movie.Inventory)
                                .Where(movie => movie.FilmId == id)
                                .SingleOrDefault();

                return Model;
            }
            public MovieListViewModel GetAll(string sortColumn, string sortOrder, string page, int PageSize)
            {
                //var items = _context.GetAll();
                var model = new MovieListViewModel();
                var items = _context.Film.Select(o => new MovieListViewModel.MovieViewModel
                {
                    MovieId = o.FilmId,
                    MovieName = o.Title,
                    ReleaseYear = o.ReleaseYear
                });

                if (string.IsNullOrEmpty(sortOrder))
                    sortOrder = "asc";

                items = AddSorting(items, ref sortColumn, ref sortOrder);

                int currentPage = string.IsNullOrEmpty(page) ? 1 : Convert.ToInt32(page);

                /*
                 * OFFSET  (@Page-1)*25 ROWS       -- skip 120 rows
                    FETCH NEXT 25 ROWS ONLY; -- take 10 rows
                 *
                 */
                var pageCount = (double)items.Count() / PageSize;
                model.PagingViewModel.MaxPages = (int)Math.Ceiling(pageCount);

                items = items.Skip((currentPage - 1) * PageSize).Take(PageSize);

                model.PagingViewModel.CurrentPage = currentPage;

                model.Items = items.ToList();
                model.SortColumn = sortColumn;
                model.SortOrder = sortOrder;

                return model;
            }

            private IQueryable<MovieListViewModel.MovieViewModel> AddSorting(IQueryable<MovieListViewModel.MovieViewModel> items, ref string sortcolumn, ref string sortorder)
            {
                if (string.IsNullOrEmpty(sortcolumn))
                    sortcolumn = "id";
                if (string.IsNullOrEmpty(sortorder))
                    sortorder = "asc";


                if (sortcolumn == "date")
                {
                    if (sortorder == "asc")
                        items = items.OrderBy(p => p.ReleaseYear);
                    else
                        items = items.OrderByDescending(p => p.ReleaseYear);
                }
                else if (sortcolumn == "id")
                {
                    if (sortorder == "asc")
                        items = items.OrderBy(p => p.MovieId);
                    else
                        items = items.OrderByDescending(p => p.MovieId);

                }
                else
                {
                    if (sortorder == "asc")
                        items = items.OrderBy(p => p.MovieName);
                    else
                        items = items.OrderByDescending(p => p.MovieName);

                    sortcolumn = "title";
                }

                return items;

            }
        }
    
}
